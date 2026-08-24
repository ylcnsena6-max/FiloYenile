using FiloYenile.Servisler;
using System.Windows;

namespace FiloYenile.Gorunumler
{
    public partial class AnalizlerGorunumu : Window
    {
        private readonly AhpServisi _ahpServisi;

        public AnalizlerGorunumu()
        {
            InitializeComponent();

            _ahpServisi = new AhpServisi();

            AnaliziYukle();
        }

        private void AnaliziYukle()
        {
            double[] agirliklar =
                _ahpServisi.AgirliklariHesapla();

            double tutarlilikOrani =
                _ahpServisi.TutarlilikOraniniHesapla();

            
            double aracYasi = agirliklar[0] * 100;
            double kilometre = agirliklar[1] * 100;
            double bakimMaliyeti = agirliklar[2] * 100;
            double yakitMaliyeti = agirliklar[3] * 100;
            double arizaSayisi = agirliklar[4] * 100;
            double guncelDeger = agirliklar[5] * 100;

      
            AracYasiBar.Value = aracYasi;
            KilometreBar.Value = kilometre;
            BakimMaliyetiBar.Value = bakimMaliyeti;
            YakitMaliyetiBar.Value = yakitMaliyeti;
            ArizaSayisiBar.Value = arizaSayisi;
            GuncelDegerBar.Value = guncelDeger;

        
            AracYasiText.Text = $"%{aracYasi:F1}";
            KilometreText.Text = $"%{kilometre:F1}";
            BakimMaliyetiText.Text = $"%{bakimMaliyeti:F1}";
            YakitMaliyetiText.Text = $"%{yakitMaliyeti:F1}";
            ArizaSayisiText.Text = $"%{arizaSayisi:F1}";
            GuncelDegerText.Text = $"%{guncelDeger:F1}";

     
            TutarlilikOraniText.Text =
                $"%{tutarlilikOrani * 100:F2}";
        }
    }
}