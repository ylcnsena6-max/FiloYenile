using FiloYenile.Modeller;
using System;
using System.Collections.Generic;

namespace FiloYenile.Servisler
{
    public class TopsisServisi
    {
        private readonly AhpServisi _ahpServisi;

        public TopsisServisi()
        {
            _ahpServisi = new AhpServisi();
        }

        public Dictionary<Arac, double> SkorlariHesapla(List<Arac> araclar)
        {
            Dictionary<Arac, double> sonuclar = new();

            if (araclar == null || araclar.Count == 0)
            {
                return sonuclar;
            }

            double[] agirliklar = _ahpServisi.AgirliklariHesapla();

            int aracSayisi = araclar.Count;
            int kriterSayisi = 6;

            double[,] kararMatrisi =
                new double[aracSayisi, kriterSayisi];

            for (int i = 0; i < aracSayisi; i++)
            {
                Arac arac = araclar[i];

                int aracYasi = DateTime.Now.Year - arac.ModelYili;

                if (aracYasi < 0)
                {
                    aracYasi = 0;
                }

                kararMatrisi[i, 0] = aracYasi;
                kararMatrisi[i, 1] = arac.Kilometre;
                kararMatrisi[i, 2] = (double)arac.YillikBakimMaliyeti;
                kararMatrisi[i, 3] = (double)arac.YillikYakitMaliyeti;
                kararMatrisi[i, 4] = arac.ArizaSayisi;
                kararMatrisi[i, 5] = (double)arac.GuncelDeger;
            }

        
            double[] sutunBolenleri =
                new double[kriterSayisi];

            for (int sutun = 0; sutun < kriterSayisi; sutun++)
            {
                double karelerToplami = 0;

                for (int satir = 0; satir < aracSayisi; satir++)
                {
                    double deger =
                        kararMatrisi[satir, sutun];

                    karelerToplami += deger * deger;
                }

                sutunBolenleri[sutun] =
                    Math.Sqrt(karelerToplami);
            }

          
            double[,] agirlikliMatris =
                new double[aracSayisi, kriterSayisi];

            for (int satir = 0; satir < aracSayisi; satir++)
            {
                for (int sutun = 0; sutun < kriterSayisi; sutun++)
                {
                    if (sutunBolenleri[sutun] == 0)
                    {
                        agirlikliMatris[satir, sutun] = 0;
                    }
                    else
                    {
                        double normalizeDeger =
                            kararMatrisi[satir, sutun] /
                            sutunBolenleri[sutun];

                        agirlikliMatris[satir, sutun] =
                            normalizeDeger *
                            agirliklar[sutun];
                    }
                }
            }

           
            double[] ideal =
                new double[kriterSayisi];

            double[] negatifIdeal =
                new double[kriterSayisi];

            for (int sutun = 0; sutun < kriterSayisi; sutun++)
            {
                double minimum =
                    agirlikliMatris[0, sutun];

                double maksimum =
                    agirlikliMatris[0, sutun];

                for (int satir = 1; satir < aracSayisi; satir++)
                {
                    if (agirlikliMatris[satir, sutun] < minimum)
                    {
                        minimum =
                            agirlikliMatris[satir, sutun];
                    }

                    if (agirlikliMatris[satir, sutun] > maksimum)
                    {
                        maksimum =
                            agirlikliMatris[satir, sutun];
                    }
                }


                if (sutun == 5)
                {
                    ideal[sutun] = minimum;
                    negatifIdeal[sutun] = maksimum;
                }
                else
                {
                    ideal[sutun] = maksimum;
                    negatifIdeal[sutun] = minimum;
                }
            }

            for (int satir = 0; satir < aracSayisi; satir++)
            {
                double pozitifUzaklikKaresi = 0;
                double negatifUzaklikKaresi = 0;

                for (int sutun = 0; sutun < kriterSayisi; sutun++)
                {
                    double pozitifFark =
                        agirlikliMatris[satir, sutun] -
                        ideal[sutun];

                    double negatifFark =
                        agirlikliMatris[satir, sutun] -
                        negatifIdeal[sutun];

                    pozitifUzaklikKaresi +=
                        pozitifFark * pozitifFark;

                    negatifUzaklikKaresi +=
                        negatifFark * negatifFark;
                }

                double pozitifUzaklik =
                    Math.Sqrt(pozitifUzaklikKaresi);

                double negatifUzaklik =
                    Math.Sqrt(negatifUzaklikKaresi);

                double toplamUzaklik =
                    pozitifUzaklik +
                    negatifUzaklik;

                double skor;

                if (toplamUzaklik == 0)
                {
                    skor = 0;
                }
                else
                {
                    skor =
                        negatifUzaklik /
                        toplamUzaklik;
                }

                sonuclar[araclar[satir]] = skor;
            }

            return sonuclar;
        }
    }
}