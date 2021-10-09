using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phase_1_Practice_project_1
{
    class StudentInformation
    {
        public int Id { get; set; }
        public string SName { get; set; }
        public int Class { get; set; }
        public string Section { get; set; }
        public StudentInformation()
        {

        }
        public StudentInformation(int id, string name, int Class, string section)
        {
            this.Id = id;
            this.SName = name;
            this.Class = Class;
            this.Section = section;

        }
    }

    class StudentBO
    {

        public List<StudentInformation> Students { get; set; }
        public StudentBO()
        {
            Students = new List<StudentInformation>();
        }

        public void GetAllStudents(string path)
        {

            StreamReader sr = new StreamReader(path);
            Console.WriteLine("ID,Name,Class,Section");
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                List<string> data = line.Split(",", 4).ToList();
                Students.Add(new StudentInformation(Convert.ToInt32(data[0]), data[1], Convert.ToInt32(data[2]), data[3]));
                Console.WriteLine(line);
            }
            sr.Close();

        }
        

    }


    class StudentDB
    {
        static void Main(string[] args)
        {
            StudentBO StudentObj = new StudentBO();
            string path = @"C:\Users\11035923\Documents\Student.txt";

            while (true)
            {
                Console.WriteLine("Please Enter the number corresponding to the Operation you want to Perform\n 1 : Get All Students \n 2 : Close App or Exit");
                int choice = int.Parse(Console.ReadLine());
             

                switch (choice)
                {
                    case 1:
                        //Display Student Details
                        StudentObj.GetAllStudents(path);
                        break;
                 

                    case 2:
                        goto exit;
                }
                Console.WriteLine("==========================================================================================");
            }
        exit:
            Console.WriteLine("Thank you! the Process has been completed");
        }
    }
}
