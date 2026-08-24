using FiloYenile.Modeller;
using System.Windows;
using System.Windows.Controls;

namespace FiloYenile.Gorunumler
{
    public partial class AracEkleGorunumu : Window
    {
        private readonly Arac? _duzenlenecekArac;

        public Arac? YeniArac { get; private set; }


        public AracEkleGorunumu()
        {
            InitializeComponent();
        }

       
        public AracEkleGorunumu(Arac duzenlenecekArac)
        {
            InitializeComponent();

            _duzenlenecekArac = duzenlenecekArac;

            Title = "Araç Düzenle";

            PlakaTextBox.Text = duzenlenecekArac.Plaka;
            MarkaTextBox.Text = duzenlenecekArac.Marka;
            ModelTextBox.Text = duzenlenecekArac.Model;
            ModelYiliTextBox.Text = duzenlenecekArac.ModelYili.ToString();
            KilometreTextBox.Text = duzenlenecekArac.Kilometre.ToString();
            BakimMaliyetiTextBox.Text =
                duzenlenecekArac.YillikBakimMaliyeti.ToString();

            YakitMaliyetiTextBox.Text =
                duzenlenecekArac.YillikYakitMaliyeti.ToString();

            ArizaSayisiTextBox.Text =
                duzenlenecekArac.ArizaSayisi.ToString();

            GuncelDegerTextBox.Text =
                duzenlenecekArac.GuncelDeger.ToString();

            
            foreach (ComboBoxItem item in YakitTuruComboBox.Items)
            {
                if (item.Content?.ToString() == duzenlenecekArac.YakitTuru)
                {
                    YakitTuruComboBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void IptalButonu_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void AraciKaydetButonu_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PlakaTextBox.Text) ||
                string.IsNullOrWhiteSpace(MarkaTextBox.Text) ||
                string.IsNullOrWhiteSpace(ModelTextBox.Text))
            {
                MessageBox.Show(
                    "Plaka, marka ve model alanları boş bırakılamaz.",
                    "Eksik Bilgi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            if (!int.TryParse(ModelYiliTextBox.Text, out int modelYili))
            {
                MessageBox.Show("Model yılı sayı olmalıdır.");
                return;
            }

            if (!int.TryParse(KilometreTextBox.Text, out int kilometre))
            {
                MessageBox.Show("Kilometre sayı olmalıdır.");
                return;
            }

            if (!decimal.TryParse(
                BakimMaliyetiTextBox.Text,
                out decimal bakimMaliyeti))
            {
                MessageBox.Show("Bakım maliyeti sayı olmalıdır.");
                return;
            }

            if (!decimal.TryParse(
                YakitMaliyetiTextBox.Text,
                out decimal yakitMaliyeti))
            {
                MessageBox.Show("Yakıt maliyeti sayı olmalıdır.");
                return;
            }

            if (!int.TryParse(
                ArizaSayisiTextBox.Text,
                out int arizaSayisi))
            {
                MessageBox.Show("Arıza sayısı sayı olmalıdır.");
                return;
            }

            if (!decimal.TryParse(
                GuncelDegerTextBox.Text,
                out decimal guncelDeger))
            {
                MessageBox.Show("Güncel araç değeri sayı olmalıdır.");
                return;
            }

            string yakitTuru = "";

            if (YakitTuruComboBox.SelectedItem
                is ComboBoxItem secilenYakit)
            {
                yakitTuru =
                    secilenYakit.Content?.ToString() ?? "";
            }

            if (string.IsNullOrWhiteSpace(yakitTuru))
            {
                MessageBox.Show(
                    "Lütfen yakıt türünü seçin.",
                    "Eksik Bilgi",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            if (_duzenlenecekArac == null)
            {
                YeniArac = new Arac
                {
                    Plaka = PlakaTextBox.Text.Trim(),
                    Marka = MarkaTextBox.Text.Trim(),
                    Model = ModelTextBox.Text.Trim(),
                    ModelYili = modelYili,
                    Kilometre = kilometre,
                    YakitTuru = yakitTuru,
                    YillikBakimMaliyeti = bakimMaliyeti,
                    YillikYakitMaliyeti = yakitMaliyeti,
                    ArizaSayisi = arizaSayisi,
                    GuncelDeger = guncelDeger,
                    AktifMi = true
                };
            }

         
            else
            {
                _duzenlenecekArac.Plaka =
                    PlakaTextBox.Text.Trim();

                _duzenlenecekArac.Marka =
                    MarkaTextBox.Text.Trim();

                _duzenlenecekArac.Model =
                    ModelTextBox.Text.Trim();

                _duzenlenecekArac.ModelYili =
                    modelYili;

                _duzenlenecekArac.Kilometre =
                    kilometre;

                _duzenlenecekArac.YakitTuru =
                    yakitTuru;

                _duzenlenecekArac.YillikBakimMaliyeti =
                    bakimMaliyeti;

                _duzenlenecekArac.YillikYakitMaliyeti =
                    yakitMaliyeti;

                _duzenlenecekArac.ArizaSayisi =
                    arizaSayisi;

                _duzenlenecekArac.GuncelDeger =
                    guncelDeger;

                YeniArac = _duzenlenecekArac;
            }

            DialogResult = true;
        }
    }
}