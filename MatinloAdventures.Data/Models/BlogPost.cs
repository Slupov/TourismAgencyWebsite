using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MatinloAdventures.Data.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMMM/YYYY HH:mm:ss}")]
        public DateTime DateCreated { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual ICollection<BlogComment> Comments { get; set; }
    }
}
