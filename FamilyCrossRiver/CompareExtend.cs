using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyCrossRiver
{
    public static class CompareExtend
    {
        public static int CompareStatus(object x, object y)
        {
            // Ép kiểu 2 object truyền vào về Status.
            Status p1 = x as Status;
            Status p2 = y as Status;

            if (p1 == null || p2 == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (p1.BoatSide == 0 && p2.BoatSide == 1)
                {
                    // Các trường hợp trái qua phải.
                    if (p1.AdultLeft - 1 == p2.AdultLeft)
                    {
                        return 1; // Đưa 1 người lớn từ trái qua phải
                    }
                    else if (p1.ChildrenLeft - 1 == p2.ChildrenLeft)
                    {
                        return 2; // Đưa 1 đứa trẻ từ trái qua phải
                    }
                    else if (p1.ChildrenLeft - 2 == p2.ChildrenLeft)
                    {
                        return 3; // Đưa 2 đứa trẻ từ trái qua phải
                    }
                }
                else
                {
                    // Các trường hợp phải qua trái.
                    if (p1.AdultRight - 1 == p2.AdultRight)
                    {
                        return 4; // Đưa 1 người lớn từ phải qua trái
                    }
                    else if (p1.ChildrenRight - 1 == p2.ChildrenRight)
                    {
                        return 5; // Đưa 1 đứa trẻ từ phải qua trái
                    }
                    else if (p1.ChildrenRight - 2 == p2.ChildrenRight)
                    {
                        return 6; // Đưa 2 đứa trẻ từ phải qua trái
                    }
                    else
                    {
                        return -1;
                    }
                }
                return -1;
            }
        }
    }
}
