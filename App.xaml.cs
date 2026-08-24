using FiloYenile.Veri;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace FiloYenile
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (var context = new FiloDbContext())
            {
                context.Database.Migrate();
            }

            base.OnStartup(e);
        }
    }
}