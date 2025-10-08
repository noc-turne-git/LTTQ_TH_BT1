using System;
using System.Collections.Generic;

namespace Bai01
{
    class Matrix
    {
        private int row;
        private int col;
        private List<List<int>> m;

        public Matrix()
        {
            m = new List<List<int>>();
        }

        public Matrix(int row, int col)
        {
            this.row = row;
            this.col = col;
            m = new List<List<int>>();
            for (int i = 0; i < row; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < col; j++)
                    temp.Add(0);
                m.Add(temp);
            }
        }

        public void Nhap()
        {
            Console.Write("Nhap so hang cua ma tran: ");
            row = int.Parse(Console.ReadLine());

            Console.Write("Nhap so cot cua ma tran: ");
            col = int.Parse(Console.ReadLine());

            Random rd = new Random();

            for (int i = 0; i < row; i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < col; j++)
                {
                    int x = rd.Next(100);
                    temp.Add(x);
                }
                m.Add(temp);
            }
        }

        public void Xuat(string GhiChu)
        {
            Console.WriteLine(GhiChu);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write($"{m[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        public int SoLonNhat()
        {
            int max = m[0][0];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (max < m[i][j]) max = m[i][j];
                }
            }
            return max;
        }
        public int SoNhoNhat()
        {
            int min = m[0][0];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (min > m[i][j]) min = m[i][j];
                }
            }
            return min;
        }

        public void TimDong_TongMax()
        {
            int TongMax = int.MinValue;
            int DongMax = 0;

            for (int i = 0; i < row; i++)
            {
                int Tong = 0;
                for (int j = 0; j < col; j++)
                    Tong += m[i][j];

                if (Tong > TongMax)
                {
                    TongMax = Tong;
                    DongMax = i;
                }
            }

            Console.WriteLine($"Dong co tong lon nhat la dong thu {DongMax + 1}:");
            for (int j = 0; j < col; j++)
            {
                Console.Write($"{m[DongMax][j]}");
                if (j != col - 1) Console.Write(" + ");
            }
            Console.WriteLine($" = {TongMax}");
        }

        static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public int TongSoKhongNguyenTo()
        {
            int Tong = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (!LaSoNguyenTo(m[i][j]))
                        Tong += m[i][j];
                }
            }
            return Tong;
        }

        public void XoaDong(int k)
        {
            if (k < 0 || k >= row)
            {
                Console.WriteLine("So dong khong hop le!");
                return;
            }

            m.RemoveAt(k);
            row--;
        }

        public void XoaCotChuaMax()
        {
            int max = SoLonNhat();
            SortedSet<int> colsMax =  new SortedSet<int>(); //Tránh giá trị trùng nhau và tự sắp xếp thứ tự

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (max == m[i][j])
                        colsMax.Add(j);
                }
            }

            // xóa từ trái sang phải sẽ làm thay đổi vị trí cột của bảng --> xóa từ phải sang trái
            foreach (var c in colsMax.Reverse())
            {
                for (int i = 0; i < row; i++)
                {
                    m[i].RemoveAt(c);
                }
                col--;
                if (col == 0) return;
            }
        }
    }

    internal static class Program
    {
        static void Main(string[] args)
        {
            Matrix m = new Matrix();
            m.Nhap();
            m.Xuat("Ma tran da nhap: ");

            Console.WriteLine($"So lon nhat: {m.SoLonNhat()}");
            Console.WriteLine($"So nho nhat: {m.SoNhoNhat()}");

            m.TimDong_TongMax();

            Console.WriteLine($"Tong cac so KHONG nguyen to: {m.TongSoKhongNguyenTo()}");

            Console.Write("Nhap dong can xoa: ");
            int dong = int.Parse(Console.ReadLine());
            m.XoaDong(dong - 1);
            m.Xuat("Sau khi xoa dong:");

            m.XoaCotChuaMax();
            m.Xuat("Sau khi xoa cot chua phan tu lon nhat:");
        }
    }
}
