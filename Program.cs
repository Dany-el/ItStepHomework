﻿using System;
using Project;

namespace Program
{
    /// <summary>
    /// TODO: hw.2 ,3
    /// </summary>
    internal static class Program
    {
        public static void Main()
        {
            StudentsGroup group = new StudentsGroup(4, "AC-223", "1", "ICS");

            
            
            foreach (var item in group)
            {
                Console.WriteLine(item);
                item.ShowGrades();
            }
            
            // group.Sort();
            //
            // StudentsGroup copy = group.Clone() as StudentsGroup;
            //
            // copy.GroupName = "AC-227";
            //
            // group.Show();
            // copy.Show();

            /*List<StudentsGroup> stream = new List<StudentsGroup>();

            StudentsGroup group223 = new StudentsGroup(1, "AC-223", "1", "ICS");
            StudentsGroup group226 = new StudentsGroup(1, "AC-226", "1", "ICS");
            StudentsGroup group227 = new StudentsGroup(1, "AC-227", "1", "ICS");

            stream.Add(group227);
            stream.Add(group226);
            stream.Add(group223);

            stream.Sort();

            foreach (var item in stream)
            {
                item.Show();
            }*/

            // PostGraduate stud = new();
            // stud.DissertationTopic = "Live on our planet";
            //
            // group[5] = stud;
            // group[5].Name = "Alex";
            // group[5].Surname = "Meronov";
            // group[5].SetBirthday(8,3,2002);


            /*StudentsGroup group2 = new StudentsGroup(4, "AC-221", "1", "ICS");
            
            if (group == group2)
            {
                Console.WriteLine("Group #1 is equal to Group #2");
            }
            else
            {
                Console.WriteLine("Groups are not equal");
            }
            
            // Operators tests 
            
            Student student = new();
            
            if (group.Group[0] == group.Group[1])
            {
                Console.WriteLine("Credits are equal");
            }
            else
            {
                Console.WriteLine("Credits are not equal");
            }

            if (group.Group[0] > group.Group[1])
            {
                Console.WriteLine("#1 has greater avg credit than #2");
            }
            else
            {
                Console.WriteLine("#2 has greater avg credit than #1");
            }
            // Age test
            student.Birthday = new DateTime(1991, 8, 24);

            Console.WriteLine(student.Age);

            // Exceptions test 
            {
                // Group's exceptions
                try
                {
                    group.TestException(1);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                // Student's exceptions
                try
                {
                    student.TestException(4);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }*/
        }
    }
}