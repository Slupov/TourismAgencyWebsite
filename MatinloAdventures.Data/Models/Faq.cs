using System.ComponentModel.DataAnnotations;

namespace MatinloAdventures.Data.Models
{
    public class Faq
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
