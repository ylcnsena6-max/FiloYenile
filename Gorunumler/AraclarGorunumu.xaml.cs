using FiloYenile.Modeller;
using FiloYenile.Servisler;
using System.Collections.ObjectModel;
using System.Windows;

namespace FiloYenile.Gorunumler
{
    public partial class AraclarGorunumu : Window
    {
        private readonly AracServisi _aracServisi;

        public ObservableCollection<Arac> Araclar { get; set; }

        public AraclarGorunumu()
        {
            InitializeComponent();

            _aracServisi = new AracServisi();

            Araclar = new ObservableCollection<Arac>(
                _aracServisi.AraclariGetir()
            );

            AracTablosu.ItemsSource = Araclar;
        }

        private void YeniAracButonu_Click(object sender, RoutedEventArgs e)
        {
            AracEkleGorunumu pencere = new AracEkleGorunumu();
            pencere.Owner = this;

            bool? sonuc = pencere.ShowDialog();

            if (sonuc == true && pencere.YeniArac != null)
            {
                _aracServisi.AracEkle(pencere.YeniArac);

                Araclar.Add(pencere.YeniArac);
            }
        }

        private void DuzenleButonu_Click(object sender, RoutedEventArgs e)
        {
            if (AracTablosu.SelectedItem is not Arac secilenArac)
            {
                MessageBox.Show("Lütfen düzenlemek istediğiniz aracı seçin.");
                return;
            }

            AracEkleGorunumu pencere =
                new AracEkleGorunumu(secilenArac);

            pencere.Owner = this;

            bool? sonuc = pencere.ShowDialog();

            if (sonuc == true && pencere.YeniArac != null)
            {
                _aracServisi.AracGuncelle(pencere.YeniArac);

                AracTablosu.Items.Refresh();
            }
        }

        private void SilButonu_Click(object sender, RoutedEventArgs e)
        {
            if (AracTablosu.SelectedItem is not Arac secilenArac)
            {
                MessageBox.Show("Lütfen silmek istediğiniz aracı seçin.");
                return;
            }

            MessageBoxResult sonuc = MessageBox.Show(
                $"{secilenArac.Plaka} plakalı aracı silmek istediğinize emin misiniz?",
                "Araç Sil",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (sonuc == MessageBoxResult.Yes)
            {
                _aracServisi.AracSil(secilenArac);

                Araclar.Remove(secilenArac);
            }
        }
    }
}