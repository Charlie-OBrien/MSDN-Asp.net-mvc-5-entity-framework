using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoUniversity.ViewModels
{
    public class VacationViewModel
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; } // to show the user's name in the view

        // Optional: For dropdown in view
        public List<SelectListItem> Users { get; set; }
    }
}