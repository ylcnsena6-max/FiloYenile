using FiloYenile.Modeller;
using FiloYenile.Servisler;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FiloYenile.Gorunumler
{
    public partial class BakimPlaniGorunumu : Window
    {
        private readonly AracServisi _aracServisi;

        public BakimPlaniGorunumu()
        {
            InitializeComponent();

            _aracServisi = new AracServisi();

            BakimVerileriniYukle();
        }

        private void BakimVerileriniYukle()
        {
            List<Arac> araclar =
                _aracServisi.AraclariGetir();

            BakimTablosu.ItemsSource = araclar;

            ToplamAracText.Text =
                araclar.Count.ToString();

            int bakimOncelikli =
                araclar.Count(a =>
                    a.ArizaSayisi >= 3 ||
                    a.YillikBakimMaliyeti >= 100000);

            BakimOncelikliText.Text =
                bakimOncelikli.ToString();

            int kritik =
                araclar.Count(a =>
                    a.ArizaSayisi >= 5 ||
                    a.Kilometre >= 300000);

            KritikAracText.Text =
                kritik.ToString();
        }
        private void KontrolEtButonu_Click(object sender, RoutedEventArgs e)
        {
            if (BakimTablosu.SelectedItem is not Arac secilenArac)
            {
                MessageBox.Show(
                    "Lütfen kontrol etmek istediğiniz aracı seçin.",
                    "Araç Seçilmedi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            MessageBox.Show(
                $"Plaka: {secilenArac.Plaka}\n" +
                $"Araç: {secilenArac.Marka} {secilenArac.Model}\n" +
                $"Kilometre: {secilenArac.Kilometre:N0}\n" +
                $"Arıza Sayısı: {secilenArac.ArizaSayisi}\n" +
                $"Yıllık Bakım Maliyeti: ₺{secilenArac.YillikBakimMaliyeti:N0}",
                "Bakım Detayı",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}