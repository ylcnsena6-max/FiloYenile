using FiloYenile.Modeller;
using FiloYenile.Servisler;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FiloYenile.Gorunumler
{
    public partial class RaporlarGorunumu : Window
    {
        private readonly AracServisi _aracServisi;

        public RaporlarGorunumu()
        {
            InitializeComponent();

            _aracServisi = new AracServisi();

            RaporuYukle();
        }

        private void RaporuYukle()
        {
            List<Arac> araclar =
                _aracServisi.AraclariGetir();

            RaporTablosu.ItemsSource = araclar;

            ToplamAracText.Text =
                araclar.Count.ToString();

            AktifAracText.Text =
                araclar.Count(a => a.AktifMi).ToString();

            decimal toplamBakim =
                araclar.Sum(a => a.YillikBakimMaliyeti);

            decimal toplamYakit =
                araclar.Sum(a => a.YillikYakitMaliyeti);

            ToplamBakimMaliyetiText.Text =
                $"₺{toplamBakim:N0}";

            ToplamYakitMaliyetiText.Text =
                $"₺{toplamYakit:N0}";
        }
    }
}