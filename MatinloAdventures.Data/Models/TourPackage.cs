using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MatinloAdventures.Data.Models
{
    public class TourPackage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Destination { get; set; }

        public decimal TransportationPrice { get; set; }

        public decimal AccomodationPrice { get; set; }

        public decimal AdventuresPrice { get; set; }
    }
}