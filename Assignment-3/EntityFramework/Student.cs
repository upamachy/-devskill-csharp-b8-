using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Student
    {
        public int Id { get; set; }

      
        [StringLength(100)]
        public string Name { get; set; } 
        public DateTime DateOfBirth { get; set; }

        [StringLength(500)]
        public string Address { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
