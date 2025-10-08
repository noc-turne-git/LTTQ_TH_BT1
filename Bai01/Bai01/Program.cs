using System;
using System.Collections.Generic;

namespace Bai01
{
    class Mang
    {
        private List<int> a;
        public Mang()
        {
            a = new List<int>();
        }

        public void Nhap()
        {
            Console.Write("Nhap so phan tu cho mang: ");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Mang gom cac phan tu: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan tu thu {i + 1}: ");
                int x = int.Parse(Console.ReadLine());
                a.Add(x);
            }
        }

        public int TongCacSoLe()
        {
            int Tong = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] % 2 != 0)
                {
                    Tong += a[i];
                }
            }
            return Tong;
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

        public int DemSoNguyenTo()
        {
            int count = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (LaSoNguyenTo(a[i]))
                {
                    count ++;
                }
            }
            return count;
        }
        static bool LaSoChinhPhuong(int n)
        {
            int i = (int)Math.Sqrt(n);
            if (i * i == n) return true;
            return false;
        }
        public int SoChinhPhuongMin()
        {
            int Min = int.MaxValue;
            for (int i = 0; i < a.Count; i++)
            {
                if (LaSoChinhPhuong(a[i]) && a[i] < Min)
                {
                    Min = a[i];
                }
            }
            if (Min == int.MaxValue) return -1;
            return Min;
        }
    }
    internal static class Program
    {
        static void Main(string[] args)
        {
            Mang a = new Mang();
            a.Nhap();
            //a.Xuat();

            Console.WriteLine($"Tong cac so le trong mang : {a.TongCacSoLe()}");
            Console.WriteLine($"So cac nguyen to trong mang : {a.DemSoNguyenTo()}");
            int CP_Min = a.SoChinhPhuongMin();
            if (CP_Min != -1)
            {
                Console.WriteLine($"So cac chinh phuong nho nhat : {CP_Min}");
            }
            else
            {
                Console.WriteLine("Mang KHONG co so chinh phuong");
            }
        }
    }
}
