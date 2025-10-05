using System;

namespace Bai02
{
    internal static class Program
    {
        static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        static void Main()
        {
            int n;
            do
            {
                Console.Write("Nhap so nguyen duong: ");
                n = int.Parse(Console.ReadLine());
            } while (n <= 0);
            long Tong = 0;

            for (int i = 2; i < n; i++)
            {
                if (LaSoNguyenTo(i))
                    Tong += i;
            }

            Console.WriteLine($"Tong cac so nguyen to be hon {n} la: {Tong}");
        }
    }
}
