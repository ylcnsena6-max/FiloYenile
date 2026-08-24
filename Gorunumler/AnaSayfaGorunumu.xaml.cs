using FiloYenile.Servisler;
using System.Windows;
using System.Linq;
using System;
using System.Windows.Media;
using FiloYenile.Modeller;
using System.Collections.Generic;

namespace FiloYenile.Gorunumler
{
    public partial class AnaSayfaGorunumu : Window
    {
        public AnaSayfaGorunumu()
        {
            InitializeComponent();
            AnaSayfaBilgileriniYukle();
            BugunText.Text = DateTime.Now.ToString("dd MMMM yyyy");
        }
        private void AnaSayfaBilgileriniYukle()
        {
            AracServisi aracServisi = new AracServisi();
            var araclar = aracServisi.AraclariGetir();
            RadarGuncelle(araclar);

            int toplamArac = araclar.Count;

            int aktifArac = araclar.Count(a => a.AktifMi);
            decimal yillikToplamMaliyet = araclar.Sum(a =>
    a.YillikBakimMaliyeti + a.YillikYakitMaliyeti);

            int bakimda = araclar.Count(a =>
                a.ArizaSayisi >= 3 ||
                a.YillikBakimMaliyeti >= 100000);

            KararDestekServisi kararDestekServisi =
                new KararDestekServisi();

            var kararSonuclari =
                kararDestekServisi.KararSonuclariniGetir();
            YenilemeAdaylariTablosu.ItemsSource =
    kararSonuclari
        .OrderByDescending(x => x.TopsisSkoru)
        .Take(3)
        .ToList();

            int yenilemeAdayi = kararSonuclari.Count(x =>
                x.OncelikSeviyesi == "Kritik" ||
                x.OncelikSeviyesi == "Yüksek");
            if (yenilemeAdayi > 0)
            {
                DikkatText.Text =
                    $"{yenilemeAdayi} araç yenileme değerlendirmesi bekliyor.";
            }
            else
            {
                DikkatText.Text =
                    "Yenileme değerlendirmesi bekleyen araç bulunmuyor.";
            }

            ToplamAracText.Text = toplamArac.ToString();

            AktifAracText.Text = aktifArac.ToString();

            YenilemeAdayiText.Text = yenilemeAdayi.ToString();
            BakimdaText.Text = bakimda.ToString();
            YillikToplamMaliyetText.Text =
    "₺" + yillikToplamMaliyet.ToString("N0");


            int genelFiloSkoru = 100;

            genelFiloSkoru -= araclar.Count(a => a.ArizaSayisi >= 3) * 5;
            genelFiloSkoru -= araclar.Count(a => a.Kilometre >= 200000) * 5;
            genelFiloSkoru -= araclar.Count(a => a.YillikBakimMaliyeti >= 100000) * 5;

            if (genelFiloSkoru < 0)
            {
                genelFiloSkoru = 0;
            }

            GenelFiloSkoruText.Text =
                $"{genelFiloSkoru} / 100";
        }

        private void AraclarButonu_Click(object sender, RoutedEventArgs e)
        {
            AraclarGorunumu araclarSayfasi = new AraclarGorunumu();

            araclarSayfasi.Closed += (s, args) =>
            {
                AnaSayfaBilgileriniYukle();
            };

            araclarSayfasi.Show();
        }


        private void KararOnerileriButonu_Click(object sender, RoutedEventArgs e)
        {
            KararOnerileriGorunumu kararSayfasi =
                new KararOnerileriGorunumu();

            kararSayfasi.Owner = this;

            kararSayfasi.Show();
        }
        private void AnalizlerButonu_Click(object sender, RoutedEventArgs e)
        {
            AnalizlerGorunumu analizSayfasi =
                new AnalizlerGorunumu();

            analizSayfasi.Owner = this;

            analizSayfasi.Show();
        }
        private void BakimPlaniButonu_Click(object sender, RoutedEventArgs e)
        {
            BakimPlaniGorunumu bakimSayfasi =
                new BakimPlaniGorunumu();

            bakimSayfasi.Owner = this;

            bakimSayfasi.Show();
        }

        private void RaporlarButonu_Click(object sender, RoutedEventArgs e)
        {
            RaporlarGorunumu raporSayfasi =
                new RaporlarGorunumu();

            raporSayfasi.Owner = this;

            raporSayfasi.Show();
        }
        private void HizliYeniAracButonu_Click(object sender, RoutedEventArgs e)
        {
            AracEkleGorunumu pencere = new AracEkleGorunumu();

            bool? sonuc = pencere.ShowDialog();

            if (sonuc == true && pencere.YeniArac != null)
            {
                AracServisi aracServisi = new AracServisi();

                aracServisi.AracEkle(pencere.YeniArac);

                AnaSayfaBilgileriniYukle();
            }
        }
        private void RadarGuncelle(List<Arac> araclar)
        {
            if (araclar.Count == 0)
                return;

            double verimlilik =
                araclar.Count(a => a.AktifMi) * 100.0 / araclar.Count;

            double ortalamaAriza =
                araclar.Average(a => a.ArizaSayisi);

            double guvenilirlik =
                100 - (ortalamaAriza * 20);

            double ortalamaMaliyet =
                araclar.Average(a =>
                    (double)(a.YillikBakimMaliyeti + a.YillikYakitMaliyeti));

            double maliyet =
                (ortalamaMaliyet / 200000) * 100;

            double ortalamaBakim =
                araclar.Average(a =>
                    (double)a.YillikBakimMaliyeti);

            double bakim =
                (ortalamaBakim / 100000) * 100;

            double ortalamaKilometre =
                araclar.Average(a => a.Kilometre);

            double kullanim =
                (ortalamaKilometre / 200000) * 100;

            verimlilik = Math.Clamp(verimlilik, 10, 100);
            guvenilirlik = Math.Clamp(guvenilirlik, 10, 100);
            maliyet = Math.Clamp(maliyet, 10, 100);
            bakim = Math.Clamp(bakim, 10, 100);
            kullanim = Math.Clamp(kullanim, 10, 100);

            Point merkez = new Point(150, 130);

            Point[] disNoktalar =
            {
        new Point(150, 20),
        new Point(270, 105),
        new Point(225, 235),
        new Point(75, 235),
        new Point(30, 105)
    };

            double[] degerler =
            {
        verimlilik,
        guvenilirlik,
        maliyet,
        bakim,
        kullanim
    };

            PointCollection noktalar = new PointCollection();

            for (int i = 0; i < 5; i++)
            {
                double oran = degerler[i] / 100.0;

                double x =
                    merkez.X +
                    (disNoktalar[i].X - merkez.X) * oran;

                double y =
                    merkez.Y +
                    (disNoktalar[i].Y - merkez.Y) * oran;

                noktalar.Add(new Point(x, y));
            }

            RadarDegerPolygon.Points = noktalar;
        }

        private void HizliAnalizButonu_Click(object sender, RoutedEventArgs e)
        {
            KararOnerileriGorunumu pencere = new KararOnerileriGorunumu();
            pencere.Show();
        }

        private void HizliBakimButonu_Click(object sender, RoutedEventArgs e)
        {
            BakimPlaniGorunumu pencere = new BakimPlaniGorunumu();
            pencere.Show();
        }

        private void HizliRaporButonu_Click(object sender, RoutedEventArgs e)
        {
            RaporlarGorunumu pencere = new RaporlarGorunumu();
            pencere.Show();
        }
        private void TumunuGorButonu_Click(object sender, RoutedEventArgs e)
        {
            KararOnerileriGorunumu pencere =
                new KararOnerileriGorunumu();

            pencere.Show();
        }
        private void KullaniciButonu_Click(object sender, RoutedEventArgs e)
        {
            KullaniciGorunumu pencere = new KullaniciGorunumu();

            pencere.Owner = this;

            bool? sonuc = pencere.ShowDialog();

            if (sonuc == true)
            {
                string kullaniciAdi = pencere.KullaniciAdi;

                KullaniciAdiText.Text = kullaniciAdi;

                KarsilamaText.Text =
                    $"Merhaba, {kullaniciAdi}! 👋";

                if (!string.IsNullOrWhiteSpace(kullaniciAdi))
                {
                    KullaniciHarfText.Text =
                        kullaniciAdi.Substring(0, 1).ToUpper();
                }
            }
        }

    }

}