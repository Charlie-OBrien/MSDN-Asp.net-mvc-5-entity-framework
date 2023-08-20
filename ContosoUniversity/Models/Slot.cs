using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Slot
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string type { get; set; }

        public string InstructorName { get; set; }
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }

    }
}