using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bouwmarkt_API.Models
{
    public class Koopzondag
    {
        [Key]
        public int Id { get; set; }

        public Vestiging Vestiging { get; set; }

        public DateTime Datum { get; set; }
        
        public DateTime StartTijd { get; set; }
       
        public DateTime EindTijd { get; set; }
    }
}
