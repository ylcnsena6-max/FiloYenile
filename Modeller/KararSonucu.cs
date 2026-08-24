namespace FiloYenile.Modeller
{
    public class KararSonucu
    {
        public Arac Arac { get; set; } = new Arac();

        public double TopsisSkoru { get; set; }

        public double YenilemeYuzdesi
        {
            get
            {
                return TopsisSkoru * 100;
            }
        }

        public string OncelikSeviyesi
        {
            get
            {
                if (TopsisSkoru >= 0.75)
                    return "Kritik";

                if (TopsisSkoru >= 0.55)
                    return "Yüksek";

                if (TopsisSkoru >= 0.35)
                    return "Orta";

                return "Düşük";
            }
        }

        public int Sira { get; set; }
    }
}