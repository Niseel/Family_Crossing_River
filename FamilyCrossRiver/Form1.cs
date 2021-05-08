using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyCrossRiver
{
    public partial class Form1 : Form
    {
        public Connect_Prolog connect;
        public Form1()
        {
            connect = new Connect_Prolog();
            InitializeComponent();
            this.Text = "Family Crossing River";
            this.txtQuery.Text = "Giải bài toán gia đình qua sông";
        }

        private int toInt(char s)
        {
            return (int)Char.GetNumericValue(s);
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Prolog file|*.pl";
            op.ShowDialog();
            String FilePath = op.FileName;
            connect.Load_file(FilePath);

            string fileName = Path.GetFileNameWithoutExtension(FilePath);
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show($"Load file \"{ fileName }\" success !", "Data notifications!", buttons, MessageBoxIcon.Information);

            this.btnQuery.Enabled = true;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var textInner = "";
            if (this.txtQuery.Text.Length > 0)
            {
                String s = connect.Query("q(X).");
                string trimed = String.Concat(s.Where(c => !Char.IsWhiteSpace(c)));
                trimed = trimed.Replace(",", "");
                trimed = trimed.Replace("[", "");
                trimed = trimed.Replace("]", "");
                trimed = trimed.Replace(";", "");
                //this.txtResult.Text = trimed;
                
                ArrayList arrStatus = new ArrayList();

                char[] ca = trimed.ToCharArray();
                for (int i = 0; i < ca.Length; i = i + 5)
                {
                    string rs = "";
                    for (int j = i; j < i+5; j++)
                    {
                        string newStr = ca[j].ToString();
                        rs = String.Concat(rs, newStr);
                        if (rs.Length == 5)
                        {
                            arrStatus.Add(new Status(toInt(rs[0]), toInt(rs[1]), toInt(rs[2]), toInt(rs[3]), toInt(rs[4])));
                        }
                    }
                }
                arrStatus.Reverse();

                Status removeObj = (Status)arrStatus[0];

                ArrayList arrStatus_UseForRs = (ArrayList)arrStatus.Clone();
                arrStatus_UseForRs.Remove(removeObj);

                Console.WriteLine(arrStatus.Count);
                Console.WriteLine(arrStatus_UseForRs.Count);

                Status curr = (Status)arrStatus[0];
                //Status curr1 = (Status)arrStatus[2];
                //var kkk = CompareExtend.CompareStatus(curr, curr1);
                //Console.WriteLine(kkk);
                int index = 1;
                foreach (Status item in arrStatus_UseForRs)
                {
                    int kq = CompareExtend.CompareStatus(curr, item);
                    switch (kq)
                    {
                        case 1:
                            // return 1; // Đưa 1 người lớn từ trái qua phải
                            textInner = "Đưa 1 người lớn từ trái qua phải";
                            break;
                        case 2:
                            // return 2; // Đưa 1 đứa trẻ từ trái qua phải
                            textInner = "Đưa 1 đứa trẻ từ trái qua phải";
                            break;
                        case 3:
                            // return 3; // Đưa 2 đứa trẻ từ trái qua phải
                            textInner = "Đưa 2 đứa trẻ từ trái qua phải";
                            break;
                        case 4:
                            // return 4; // Đưa 1 người lớn từ phải qua trái
                            textInner = "Đưa 1 người lớn từ phải qua trái";
                            break;
                        case 5:
                            // return 5; // Đưa 1 đứa trẻ từ phải qua trái
                            textInner = "Đưa 1 đứa trẻ từ phải qua trái";
                            break;
                        case 6:
                            // return 6; // Đưa 2 đứa trẻ từ phải qua trái
                            textInner = "Đưa 2 đứa trẻ từ phải qua trái";
                            break;
                        case -1:
                            // Exception 
                            textInner = "Đã xảy lỗi hãy kiểm tra hàm trả kết quả";
                            break;
                        default:
                            // Exception 
                            textInner = "Đã xảy lỗi hãy kiểm tra hàm trả kết quả";
                            break;
                    }
                    this.txtResult.AppendText($"Bước {index}: ");
                    this.txtResult.AppendText(textInner.ToString());
                    this.txtResult.AppendText(Environment.NewLine);

                    curr = item;
                    index++;
                }
                this.txtResult.AppendText(Environment.NewLine);
                this.txtResult.AppendText("====================");
                this.txtResult.AppendText(Environment.NewLine);
                this.txtResult.AppendText($"Bài toán kết thúc với {--index} bước");
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                MessageBox.Show($"Please enter query", "Warning!!!", buttons, MessageBoxIcon.Warning);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string defaultPath = @"C:\Users\THANH\source\repos\FamilyCrossRiver\FamilyCrossRiver\family-crossing.pl";
            connect.Load_file(defaultPath);
            string fileName = Path.GetFileNameWithoutExtension(defaultPath);
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show($"Load file \"{ fileName }\" success !", "Data preload notifications!", buttons, MessageBoxIcon.Information);
        }


    }
}
