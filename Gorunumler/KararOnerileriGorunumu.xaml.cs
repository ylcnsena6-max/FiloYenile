using FiloYenile.Servisler;
using System.Windows;

namespace FiloYenile.Gorunumler
{
    public partial class KararOnerileriGorunumu : Window
    {
        private readonly KararDestekServisi _kararDestekServisi;

        public KararOnerileriGorunumu()
        {
            InitializeComponent();

            _kararDestekServisi = new KararDestekServisi();

            SonuclariYukle();
        }

        private void SonuclariYukle()
        {
            var sonuclar =
                _kararDestekServisi.KararSonuclariniGetir();

            KararTablosu.ItemsSource = sonuclar;
        }
    }
}