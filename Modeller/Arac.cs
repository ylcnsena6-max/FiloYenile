using System;

namespace FiloYenile.Modeller
{
    public class Arac
    {
        public int Id { get; set; }

        public string Plaka { get; set; } = string.Empty;

        public string Marka { get; set; } = string.Empty;

        public string Model { get; set; } = string.Empty;

        public int ModelYili { get; set; }

        public int Kilometre { get; set; }

        public string YakitTuru { get; set; } = string.Empty;

        public decimal YillikBakimMaliyeti { get; set; }

        public decimal YillikYakitMaliyeti { get; set; }

        public int ArizaSayisi { get; set; }

        public decimal GuncelDeger { get; set; }

        public DateTime KayitTarihi { get; set; } = DateTime.Now;

        public bool AktifMi { get; set; } = true;
    }
}