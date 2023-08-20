using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int BookId { get; set; }
        public string ReviewerName { get; set; }
        public string Content { get; set; }
        public DateTime ReviewDate { get; set; }
        // Navigation property
        public virtual Book Book { get; set; }
    }
}