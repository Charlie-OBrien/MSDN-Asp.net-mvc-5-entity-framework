using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class BookDetailsViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}