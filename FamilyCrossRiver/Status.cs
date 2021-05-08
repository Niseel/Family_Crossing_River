using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyCrossRiver
{
    public class Status
    {
        private int adultLeft;
        private int childrenLeft;
        private int adultRight;
        private int childrenRight;
        private int boatSide;

        public int AdultLeft
        {
            get { return adultLeft; }
            set { adultLeft = value; }
        }

        public int ChildrenLeft
        {
            get { return childrenLeft; }
            set { childrenLeft = value; }
        }

        public int AdultRight
        {
            get { return adultRight; }
            set { adultRight = value; }
        }

        public int ChildrenRight
        {
            get { return childrenRight; }
            set { childrenRight = value; }
        }
        public int BoatSide
        {
            get { return boatSide; }
            set { boatSide = value; }
        }

        public Status(int adL, int chL, int adR, int chR, int bSide)
        {
            this.adultLeft = adL;
            this.childrenLeft = chL;
            this.adultRight = adR;
            this.childrenRight = chR;
            this.boatSide = bSide;
        }

        /// <summary>
        /// Override phương thức ToString để khi cần có thể in thông tin của object ra cho nhanh.
        /// </summary>
        /// <returns></returns>
        public string toDefaultString()
        {
            return $"Status: {adultLeft}{childrenLeft}{adultRight}{childrenRight}{boatSide}";
        }
        public override string ToString()
        {
            var bSide = boatSide == 1 ? "Phải" : "Trái";
            return $"Thuyền ở bên: {bSide}\n";
        }
    }
}
