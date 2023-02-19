using bouwmarkt_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace bouwmarkt_API.Data
{
    public class SeedData
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new BouwmarktContext(
                serviceProvider.GetRequiredService<DbContextOptions<BouwmarktContext>>());

            if (context.Vestigingen != null && !context.Vestigingen.Any())
                context.Vestigingen.AddRange(
                 new Vestiging
                 {
                     VestigingsNaam = "Bouwmarkt Tilburg West",
                     Address = "Hogelaan 23",
                     Plaats = "Tilburg",
                     Telefoonnumer = "+3161234567",
                     Koopzondagen = new List<Koopzondag>
                     {
                         new Koopzondag
                         {
                            Datum = new DateTime(2023, 03, 01, 01, 00, 00),
                            StartTijd = new DateTime(2023, 03, 01, 09, 00, 00),
                            EindTijd = new DateTime(2023, 03, 01, 20, 00, 00)
                        },
                         new Koopzondag
                         {
                            Datum = new DateTime(2023, 04, 01, 01, 00, 00),
                            StartTijd = new DateTime(2023, 04, 01, 09, 00, 00),
                            EindTijd = new DateTime(2023, 04, 01, 20, 00, 00)
                        }
                     }
                 },
                 new Vestiging
                 {
                    VestigingsNaam = "Bouwmarkt Heinloo",
                    Address = "Vierbeuk 1",
                    Plaats = "Heinloo",
                    Telefoonnumer = "+316444444",
                    Koopzondagen = new List<Koopzondag>
                    {
                         new Koopzondag
                         {
                            Datum = new DateTime(2023, 02, 01, 01, 00, 00),
                            StartTijd = new DateTime(2023, 02, 01, 09, 00, 00),
                            EindTijd = new DateTime(2023, 02, 01, 20, 00, 00)
                         },
                         new Koopzondag
                         {
                            Datum = new DateTime(2023, 05, 01, 01, 00, 00),
                            StartTijd = new DateTime(2023, 05, 01, 09, 00, 00),
                            EindTijd = new DateTime(2023, 05, 01, 20, 00, 00)
                         },
                         new Koopzondag
                         {
                            Datum = new DateTime(2023, 06, 01, 01, 00, 00),
                            StartTijd = new DateTime(2023, 06, 01, 09, 00, 00),
                            EindTijd = new DateTime(2023, 06, 01, 20, 00, 00)
                         },
                    }
                 }
                );
            await context.SaveChangesAsync();

        }
    }
}
