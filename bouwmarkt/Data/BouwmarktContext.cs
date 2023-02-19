using bouwmarkt_API.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace bouwmarkt_API.Data;

public class BouwmarktContext : DbContext
{
    public BouwmarktContext(DbContextOptions<BouwmarktContext> options)
        : base(options)
    {

    }

    public DbSet<Vestiging> Vestigingen { get; set; }
    public DbSet<Koopzondag> Koopzondagen { get; set; }

/*    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Koopzondag>()
            .HasOne(v => v.Vestiging)
            .WithMany(k => k.Koopzondagen)
            .HasForeignKey(vn => vn.Vestigingsnummer);


    }*/
}
