using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAOyun2023
{
    static class Asteroidler
    {
        static List<Asteroid> asteroidler;

        static Random rnd = new Random();

        static Asteroidler()
        {
            asteroidler = new List<Asteroid>();
        }

        static public void Ekle(int can, float x, float y, float vx, float vy, float r)
        {
            asteroidler.Add( new Asteroid(can, x, y, vx, vy, r) );
        }

        static public void Ekle()
        {
            asteroidler.Add(new Asteroid());
        }


        static public void Hesapla(float t, Oyuncu o)
        {
            foreach (Asteroid a in asteroidler)
                a.Hesapla(t);

            for (int i = asteroidler.Count - 1; i >= 0; i--)
                if (asteroidler[i].x < -asteroidler[i].r ||
                    asteroidler[i].x > 800 + asteroidler[i].r ||
                    asteroidler[i].y < -500 ||
                    asteroidler[i].y > 600 + asteroidler[i].r)
                    asteroidler.RemoveAt(i);

            for (int i = asteroidler.Count - 1; i >= 0; i--)
            {
                if (asteroidler[i].Carpti(o) == true)
                {
                    o.CanAzalt();

                    Patlamalar.Ekle(asteroidler[i].x, asteroidler[i].y, 2 * asteroidler[i].r);
                    asteroidler.RemoveAt(i);
                }
            }

            for (int i = asteroidler.Count - 1; i >= 0; i--)
            {
                if (Mermiler.Vurdu(asteroidler[i]) == true)
                {
                    asteroidler[i].CanAzalt();

                    if (asteroidler[i].can < 1)
                    {
                        Patlamalar.Ekle(asteroidler[i].x, asteroidler[i].y, 2 * asteroidler[i].r);

                        if (asteroidler[i].r > 30)
                            for (int j = 0; j < 10; j++)
                                Ekle(1, asteroidler[i].x, asteroidler[i].y, 
                                        rnd.Next(-150, 150), rnd.Next(-150, 150), 
                                        asteroidler[i].r / 2);

                        asteroidler.RemoveAt(i);
                    }
                }

            }


        }

        static public void Ciz()
        {
            foreach (Asteroid a in asteroidler)
                a.Ciz();
        }

        static public int Say()
        {
            return asteroidler.Count;
        }


    }
}
