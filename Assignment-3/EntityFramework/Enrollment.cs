﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Enrollment
    {
       
        public int StudentId { get; set; }
        public Student Student { get; set; }    
        public int CourseId { get; set; }
        public Course Course { get; set; }      
        public DateTime EnrollDate { get; set; }
    }
}
