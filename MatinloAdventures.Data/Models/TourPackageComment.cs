using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MatinloAdventures.Data.Models
{
    public class TourPackageComment
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue("")]
        public string Username { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
