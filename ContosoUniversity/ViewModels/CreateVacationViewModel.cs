using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace ContosoUniversity.ViewModels
{
    public class CreateVacationViewModel
    {
        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "User")]
        public int SelectedUserId { get; set; }
        public IEnumerable<SelectListItem> UserDropdown { get; set; }
    }
}