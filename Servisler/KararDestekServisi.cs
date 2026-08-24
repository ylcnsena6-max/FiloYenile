using FiloYenile.Modeller;
using System.Collections.Generic;
using System.Linq;

namespace FiloYenile.Servisler
{
    public class KararDestekServisi
    {
        private readonly AracServisi _aracServisi;
        private readonly TopsisServisi _topsisServisi;

        public KararDestekServisi()
        {
            _aracServisi = new AracServisi();
            _topsisServisi = new TopsisServisi();
        }

        public List<KararSonucu> KararSonuclariniGetir()
        {
  
            List<Arac> araclar = _aracServisi
                .AraclariGetir()
                .Where(a => a.AktifMi)
                .ToList();

            if (araclar.Count == 0)
            {
                return new List<KararSonucu>();
            }

  
            Dictionary<Arac, double> skorlar =
                _topsisServisi.SkorlariHesapla(araclar);

  
            List<KararSonucu> sonuclar =
                skorlar
                    .OrderByDescending(x => x.Value)
                    .Select((x, index) => new KararSonucu
                    {
                        Arac = x.Key,
                        TopsisSkoru = x.Value,
                        Sira = index + 1
                    })
                    .ToList();

            return sonuclar;
        }
    }
}