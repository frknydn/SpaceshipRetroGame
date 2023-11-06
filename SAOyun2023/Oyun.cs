using System;
using SFMLResim;

namespace SAOyun2023
{
    static class Oyun
    {
        static int bgResim;

        static Oyuncu o;

        static Oyun()
        {
            bgResim = Resim.Ekle("res\\bg.png");
        }

        static public void YeniOyun()
        {
            o = new Oyuncu(30);
        }

        static public void Hesapla(float t)
        {
            if (Gemiler.Say() < 5)
                Gemiler.Ekle(1);

            if (Asteroidler.Say() < 3)
                Asteroidler.Ekle();

            Gemiler.Hesapla(t, o);
            Asteroidler.Hesapla(t, o);
            o.Hesapla(t);
            Patlamalar.Hesapla(t);
            Mermiler.Hesapla(t);
        }

        static public void Ciz()
        {
            Resim.Ciz(bgResim, 0, 0, 800, 600);

            Asteroidler.Ciz();
            Gemiler.Ciz();
            Patlamalar.Ciz();
            Mermiler.Ciz();
            o.Ciz();
        }

        static public void FareKontrol()
        {
            o.FareKontrol();
        }
    }
}
