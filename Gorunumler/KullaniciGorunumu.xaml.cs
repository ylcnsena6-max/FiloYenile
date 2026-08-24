using System.Windows;

namespace FiloYenile.Gorunumler
{
    public partial class KullaniciGorunumu : Window
    {
        public string KullaniciAdi { get; private set; } = "";

        public KullaniciGorunumu()
        {
            InitializeComponent();
        }

        private void KaydetButonu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(KullaniciAdiTextBox.Text))
            {
                MessageBox.Show(
                    "Lütfen kullanıcı adını girin.",
                    "Eksik Bilgi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            KullaniciAdi = KullaniciAdiTextBox.Text.Trim();

            DialogResult = true;
        }
    }
}