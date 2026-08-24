using FiloYenile.Modeller;
using FiloYenile.Veri;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace FiloYenile.Servisler
{
    public class AracServisi
    {
        public List<Arac> AraclariGetir()
        {
            using var context = new FiloDbContext();

            return context.Araclar
                .AsNoTracking()
                .ToList();
        }

        public void AracEkle(Arac arac)
        {
            using var context = new FiloDbContext();

            context.Araclar.Add(arac);
            context.SaveChanges();
        }

        public void AracGuncelle(Arac arac)
        {
            using var context = new FiloDbContext();

            context.Araclar.Update(arac);
            context.SaveChanges();
        }

        public void AracSil(Arac arac)
        {
            using var context = new FiloDbContext();

            context.Araclar.Remove(arac);
            context.SaveChanges();
        }
    }
}