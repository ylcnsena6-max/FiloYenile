using System.Windows;

namespace FiloYenile.Gorunumler
{
    public partial class GirisGorunumu : Window
    {
        public GirisGorunumu()
        {
            InitializeComponent();
        }

        private void DevamButonu_Click(object sender, RoutedEventArgs e)
        {
            AnaSayfaGorunumu anaSayfa = new AnaSayfaGorunumu();

            anaSayfa.Show();

            this.Close();
        }
    }
}