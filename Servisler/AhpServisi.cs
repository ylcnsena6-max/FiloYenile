using System;

namespace FiloYenile.Servisler
{
    public class AhpServisi
    {
        public double[] AgirliklariHesapla()
        {
            double[,] matris =
            {
                { 1.00, 2.00, 0.50, 2.00, 1.00, 3.00 },
                { 0.50, 1.00, 0.50, 2.00, 1.00, 3.00 },
                { 2.00, 2.00, 1.00, 3.00, 2.00, 4.00 },
                { 0.50, 0.50, 0.33, 1.00, 0.50, 2.00 },
                { 1.00, 1.00, 0.50, 2.00, 1.00, 3.00 },
                { 0.33, 0.33, 0.25, 0.50, 0.33, 1.00 }
            };

            int kriterSayisi = matris.GetLength(0);

            double[] sutunToplamlari =
                new double[kriterSayisi];

            for (int sutun = 0; sutun < kriterSayisi; sutun++)
            {
                for (int satir = 0; satir < kriterSayisi; satir++)
                {
                    sutunToplamlari[sutun] +=
                        matris[satir, sutun];
                }
            }

            double[,] normalizeMatris =
                new double[kriterSayisi, kriterSayisi];

            for (int satir = 0; satir < kriterSayisi; satir++)
            {
                for (int sutun = 0; sutun < kriterSayisi; sutun++)
                {
                    normalizeMatris[satir, sutun] =
                        matris[satir, sutun] /
                        sutunToplamlari[sutun];
                }
            }

            double[] agirliklar =
                new double[kriterSayisi];

            for (int satir = 0; satir < kriterSayisi; satir++)
            {
                double satirToplami = 0;

                for (int sutun = 0; sutun < kriterSayisi; sutun++)
                {
                    satirToplami +=
                        normalizeMatris[satir, sutun];
                }

                agirliklar[satir] =
                    satirToplami / kriterSayisi;
            }

            return agirliklar;
        }

        public double TutarlilikOraniniHesapla()
        {
            double[,] matris =
            {
                { 1.00, 2.00, 0.50, 2.00, 1.00, 3.00 },
                { 0.50, 1.00, 0.50, 2.00, 1.00, 3.00 },
                { 2.00, 2.00, 1.00, 3.00, 2.00, 4.00 },
                { 0.50, 0.50, 0.33, 1.00, 0.50, 2.00 },
                { 1.00, 1.00, 0.50, 2.00, 1.00, 3.00 },
                { 0.33, 0.33, 0.25, 0.50, 0.33, 1.00 }
            };

            double[] agirliklar =
                AgirliklariHesapla();

            int kriterSayisi =
                matris.GetLength(0);

            double[] agirlikliToplam =
                new double[kriterSayisi];

            for (int satir = 0; satir < kriterSayisi; satir++)
            {
                for (int sutun = 0; sutun < kriterSayisi; sutun++)
                {
                    agirlikliToplam[satir] +=
                        matris[satir, sutun] *
                        agirliklar[sutun];
                }
            }

            double lambdaMax = 0;

            for (int i = 0; i < kriterSayisi; i++)
            {
                lambdaMax +=
                    agirlikliToplam[i] /
                    agirliklar[i];
            }

            lambdaMax /= kriterSayisi;

            double tutarlilikIndeksi =
                (lambdaMax - kriterSayisi) /
                (kriterSayisi - 1);

         
            double rassallikIndeksi = 1.24;

            return tutarlilikIndeksi /
                   rassallikIndeksi;
        }
    }
}