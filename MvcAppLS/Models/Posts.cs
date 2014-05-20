using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcAppLS.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
    
        [Display(Name = "Posted Date")]
        public DateTime PostedDate { get; set; }

        public string Category { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
    }
}