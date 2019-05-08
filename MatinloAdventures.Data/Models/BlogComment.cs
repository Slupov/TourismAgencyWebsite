using System;
using System.ComponentModel.DataAnnotations;

namespace MatinloAdventures.Data.Models
{
    public class BlogComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMMM/YYYY HH:mm:ss}")]
        public DateTime DateAdded { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMMM/YYYY HH:mm:ss}")]
        public DateTime? DateEdited { get; set; }

        [Required]
        public bool IsEdited { get; set; }
    }
}
