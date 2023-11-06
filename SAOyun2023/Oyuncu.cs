using System;
using SFMLResim;

namespace SAOyun2023
{
    class Oyuncu
    {
        static private int resim;
        static private int canResmi;

        public float x { get; private set; }
        public float y { get; private set; }
        public float r { get; private set; }

        private float mermiZamani;
        public int can { get; private set; }

        static Oyuncu()
        {
            resim = Resim.Ekle("res\\Oyuncu\\1.png");
            canResmi = Resim.Ekle("res\\Oyuncu\\can.png");
        }

        public Oyuncu(float r)
        {
            can = 10;

            this.r = r;
            x = 400;
            y = 300;

            mermiZamani = 0;
        }

        public void Hesapla(float t)
        {
            mermiZamani += t;
        }

        public void Ciz()
        {
            Resim.Ciz(resim, x - r, y - r, 2 * r, 2 * r);

            for (int i = 0; i < can; i++)
                Resim.Ciz(canResmi, 20*i, 0, 50, 50);
        }

        private void Git(float x, float y)
        {
            if (x < r)
                x = r;
            else if (x > 800 - r)
                x = 800 - r;

            this.x = x;

            if (y < r)
                y = r;
            else if (y > 600 - r)
                y = 600 - r;

            this.y = y;
        }

        private void AtesEt(int tip=0)
        {
            if (mermiZamani > 0.2)
            {
                Mermiler.Ekle(x, y - r, tip);
                mermiZamani = 0;
            }
        }

        public void FareKontrol()
        {
            Git(Resim.FarePos.X, Resim.FarePos.Y);

            if (Resim.FareSolBasili == true)
                AtesEt(0);
            else if (Resim.FareSagBasili == true)
                AtesEt(1);
        }

        public void CanAzalt()
        {
            can--;
            if (can < 0)
                can = 0;
        }



    }
}
