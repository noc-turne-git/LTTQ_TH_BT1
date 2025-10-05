using System;

namespace Bai03_04_05
{
    internal static class Program
    {
        static bool LaNamNhuan(int nam)
        {
            return (nam % 400 == 0) || (nam % 4 == 0 && nam % 100 != 0);
        }
        static bool ThoiGianHopLe(int ngay, int thang, int nam)
        {
            if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                if (ngay >= 1 && ngay <= 30) return true;
            }
            else if (thang == 1 || thang == 3 || thang == 5 || thang == 7 ||
                     thang == 8 || thang == 10 || thang == 12)
            {
                if (ngay >= 1 && ngay <= 31) return true;
            }
            else if (thang == 2)
            {
                if (LaNamNhuan(nam))
                {
                    if (ngay >= 1 && ngay <= 29) return true;
                }
                else
                {
                    if (ngay >= 1 && ngay <= 28) return true;
                }
            }
            return false;
        }

        static int SoNgay(int thang, int nam)
        {
            if (thang == 4 || thang == 6 || thang == 9 || thang == 11)
            {
                return 30;
            }
            else if (thang == 1 || thang == 3 || thang == 5 || thang == 7 ||
                     thang == 8 || thang == 10 || thang == 12)
            {
                return 31;
            }
            else if (thang == 2)
            {
                if (LaNamNhuan(nam))
                {
                    return 29;
                }
                else
                {
                    return 28;
                }
            }
            return 0; // TH ngay thang khong hop le
        }
        static long TongSoNgay (int ngay, int thang, int nam)
        {
            long Tong = 0;

            for (int i = 0; i < nam; i++)
            {
                Tong += 365;
                if (LaNamNhuan(nam)) Tong++;
            }

            for (int i = 1; i<thang; i++)
            {
                Tong += SoNgay(i, nam);
            }

            Tong += ngay;
            return Tong;
        }
        static string LaThu(int ngay, int thang, int nam )
        {
            int thu = (int) TongSoNgay(ngay, thang, nam) % 7;
            string[] CacThuTrongTuan = { "Chu Nhat", "Thu Hai", "Thu Ba", "Thu Tu", "Thu Nam", "Thu Sau", "Thu Bay" };
            return CacThuTrongTuan[thu];
        }


        static void Main()
        {
            Console.Write("Nhap ngay: ");
            int ngay = int.Parse(Console.ReadLine());

            Console.Write("Nhap thang: ");
            int thang = int.Parse(Console.ReadLine());

            Console.Write("Nhap nam: ");
            int nam = int.Parse(Console.ReadLine());

            if (!ThoiGianHopLe(ngay, thang, nam)) {
                Console.WriteLine($"Thoi gian KHONG hop le!");
                if (thang < 1 || thang > 12)
                {
                    Console.WriteLine($"Thang {thang} khong hop le!");
                    if (ngay < 1 || ngay > 31)
                        Console.WriteLine($"Ngay {ngay} khong hop le!");
                }
                else
                {
                    Console.WriteLine($"Ngay {ngay} khong hop le!");
                    Console.WriteLine($"Thang {thang}, nam {nam} chi co { SoNgay(thang, nam) } ngay.");
                }
            }
            else
            {
                Console.WriteLine($"Thoi gian hop le!");
                Console.WriteLine($"Thang {thang}, nam {nam} co {SoNgay(thang, nam)} ngay");
                Console.WriteLine($"Ngay {ngay}/{thang}/{nam} la { LaThu(ngay, thang, nam) } ");
            }
        }
    }
}
