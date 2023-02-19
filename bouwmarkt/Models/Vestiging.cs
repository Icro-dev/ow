using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace bouwmarkt_API.Models
{
    public class Vestiging
    {

        [Key]
        public int Vestigingsnummer { get; set; }

        [MaxLength (400)]
        public string VestigingsNaam { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(300)]
        public string Plaats { get; set; }

        [MaxLength(20)]
        public string Telefoonnumer { get; set; }

        public ICollection<Koopzondag> Koopzondagen { get; set; }
    }
}
