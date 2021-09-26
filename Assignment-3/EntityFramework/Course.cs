using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Course
    {
        
        public int Id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public decimal Fees { get; set; }

        public int DurationInHours { get; set; }

        public List<Enrollment> Enrollments { get; set; }
    }
}
