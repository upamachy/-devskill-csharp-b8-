using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new ManyToManyContext();
            Insert(context);
            Update(context);
            Delete(context);
        }

        static void Insert(ManyToManyContext context)
        {
            context.Add(new Course { Title = "Course1", Fees = 6700.00M, DurationInHours = 35 });
            context.Add(new Course { Title = "Course2", Fees = 5500.00M, DurationInHours = 26 });

            context.Add(new Student { Name = "Student1", Address = "Dhaka", DateOfBirth = new DateTime(2011, 1, 1) });
            context.Add(new Student { Name = "Student2", Address = "Sylhet", DateOfBirth = new DateTime(2001, 01, 1)});


            context.SaveChanges();


            var course1 = context.Courses.FirstOrDefault(c => c.Title == "Course1");
            var course2 = context.Courses.FirstOrDefault(c => c.Title == "Course2");


            var student1 = context.Students.FirstOrDefault(s => s.Name == "Student1");
            var student2 = context.Students.FirstOrDefault(s => s.Name == "Student2");

            course1.Enrollments = new List<Enrollment> { new Enrollment { Student = student1 }, new Enrollment { Student = student2 } };
            student1.Enrollments = new List<Enrollment> { new Enrollment { Course = course2 } };
            context.SaveChanges();

          

          

        }
        static void Update(ManyToManyContext context)
        {
           
            var student = context.Students.FirstOrDefault(s => s.Name == "Student1");
            student.DateOfBirth = new DateTime(2011, 1, 1);
            context.Students.Update(student);

            var student3 = new Student { Name = "Murad", Address = "Sylhet", DateOfBirth = new DateTime(2012, 1, 1) };
            context.Students.Add(student3);

            var course = context.Courses.FirstOrDefault(c => c.Title == "Course2");
            course.Title = "Course3";
            course.Enrollments = new List<Enrollment> { new Enrollment { Student = student3 } };
            context.Courses.Update(course);

            context.SaveChanges();

            
        }
        static void Delete(ManyToManyContext context)
        {

            var course = context.Courses.FirstOrDefault(c => c.Title == "Course3");
            context.Courses.Remove(course);

            var student = context.Students.FirstOrDefault(s => s.Name == "Murad");
            context.Students.Remove(student);

            context.SaveChanges();   
        }
    }
}
