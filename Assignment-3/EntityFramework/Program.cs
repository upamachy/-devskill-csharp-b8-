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
            Console.WriteLine("Insert");
            Insert(context);
            Console.WriteLine("Update");
            Update(context);
            Console.WriteLine("Delete");
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

            var courses = context.Courses.Include(c => c.Enrollments).ThenInclude(e => e.Student).ToList();

            foreach (var a in courses)
            {
          
                Console.WriteLine($"Id: {a.Id}, Course Title: {a.Title}, Fees: {a.Fees}, Duration Hour:  {a.DurationInHours}");
                
                foreach (var q in a.Enrollments)
                {
                    Console.WriteLine($"Id:{q.Student.Id}, Name: {q.Student.Name}, DateofBirth: {q.Student.DateOfBirth.Date}," +
                        $" Address: {q.Student.Address}");
                }
            }


        }
        static void Update(ManyToManyContext context)
        {
           
            var student = context.Students.FirstOrDefault(s => s.Name == "Student1");
            student.DateOfBirth = new DateTime(2005, 2, 5);
            context.Students.Update(student);

            var student3 = new Student { Name = "Murad", Address = "Sylhet", DateOfBirth = new DateTime(2012, 1, 1) };
            context.Students.Add(student3);

            var course = context.Courses.FirstOrDefault(c => c.Title == "Course2");
            course.Title = "Course3";
            course.Enrollments = new List<Enrollment> { new Enrollment { Student = student3 } };
            context.Courses.Update(course);

            context.SaveChanges();

            
            var courses = context.Courses.Include(c => c.Enrollments).ThenInclude(e => e.Student).ToList();
            foreach (var item in courses)
            {
                Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Fees: {item.Fees}, Duration: {item.DurationInHours}");
                foreach (var enroll in item.Enrollments)
                {
                    Console.WriteLine($"Id: {enroll.Student.Id}, Name: {enroll.Student.Name},  DateofBirth: {enroll.Student.DateOfBirth.Date}," +
                        $" Address: {enroll.Student.Address}");
                }
            }


        }
        static void Delete(ManyToManyContext context)
        {

            var course = context.Courses.FirstOrDefault(c => c.Title == "Course3");
            context.Courses.Remove(course);

            var student = context.Students.FirstOrDefault(s => s.Name == "Murad");
            context.Students.Remove(student);

            context.SaveChanges();
            var courses = context.Courses.Include(c => c.Enrollments).ThenInclude(e => e.Student).ToList();
            foreach (var item in courses)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Title}, Fees: {item.Fees}, DurationHour: {item.DurationInHours}");
                foreach (var enroll in item.Enrollments)
                {
                    Console.WriteLine($"Id: {enroll.Student.Id}, Name: {enroll.Student.Name},  DateofBirth: {enroll.Student.DateOfBirth.Date}, Address: {enroll.Student.Address}");
                }
            }
        }
    }
}
