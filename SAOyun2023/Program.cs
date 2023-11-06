using System;
using SFMLResim;

namespace SAOyun2023
{
    static class Program
    {
        static void Main()
        {
            //System.Windows.Forms.Cursor.Hide();

            Resim.Yeni(800, 600, "SAOyun2023");
            //Resim.SetFPSLimit(60);

            Oyun.YeniOyun();

            while (Resim.Acik())
            {
                Resim.Baslat();

                Oyun.FareKontrol();
                Oyun.Hesapla(Resim.FrameTime);
                Oyun.Ciz();



                if (Resim.KlavyeAsagi(Resim.Klavye.Escape))
                    Resim.Kapat();

                if (Resim.KlavyeAsagi(Resim.Klavye.Num1))
                    Resim.YeniRes(800, 600, "SAOyun 800x600");

                if (Resim.KlavyeAsagi(Resim.Klavye.Num2))
                    Resim.YeniRes(1200, 900, "SAOyun 1200x900");

                // 1920 1080
                // 960  540
                // 480  270
                // 240  135
                // 80   45

                Resim.Bitir();
            }
        }
    }
}
