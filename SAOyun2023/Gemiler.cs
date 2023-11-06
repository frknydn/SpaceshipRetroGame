using System;
using System.Collections.Generic;

namespace SAOyun2023
{
    static class Gemiler
    {
        static private List<Gemi> gemiler;

        static Gemiler()
        {
            gemiler = new List<Gemi>();
        }

        static public void Ekle(int n = 1)
        {
            for (int i = 0; i < n; i++)
                gemiler.Add( new Gemi() );
        }

        static public void Hesapla(float t, Oyuncu o)
        {
            foreach (Gemi g in gemiler)
                g.Hesapla(t);

            for (int i = gemiler.Count - 1; i >= 0; i--)
            {
                if (gemiler[i].Carpti(o) == true)
                {
                    o.CanAzalt();

                    Patlamalar.Ekle(gemiler[i].x, gemiler[i].y, 3*gemiler[i].r);
                    gemiler.RemoveAt(i);
                }
            }

            for (int i = gemiler.Count - 1; i >= 0; i--)
            {
                if (Mermiler.Vurdu(gemiler[i]) == true)
                {
                    gemiler[i].CanAzalt();

                    if (gemiler[i].can < 1)
                    {
                        Patlamalar.Ekle(gemiler[i].x, gemiler[i].y, 3 * gemiler[i].r);
                        gemiler.RemoveAt(i);
                    }
                }

            }
        }

        static public void Ciz()
        {
            foreach (Gemi g in gemiler)
                g.Ciz();
        }

        static public int Say()
        {
            return gemiler.Count;
        }


    }
}
