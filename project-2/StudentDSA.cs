using System;
using System.Collections.Generic;
using System.Text;

namespace Phase_1_Practice_project_1
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using System.Linq;
    namespace dover_day3
    {
        class Students
        {
            public int Id { get; set; }
            public string SName { get; set; }
            public int Class { get; set; }
            public string Section { get; set; }
            public Students()
            {

            }
            public Students(int id, string name, int Class, string section)
            {
                this.Id = id;
                this.SName = name;
                this.Class = Class;
                this.Section = section;

            }

            public override string ToString()
            {
                return (this.Id + " " + this.SName + " " + this.Class + " " + this.Section);
            }
        }
        class StudentBO
        {

            public List<Students> students { get; set; }
            public StudentBO()
            {
                students = new List<Students>();
            }

            public void GetAllStudents(string path)
            {

                StreamReader sr = new StreamReader(path);
                Console.WriteLine("ID,Name,Class,Section");
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    List<string> data = line.Split(",", 4).ToList();
                    students.Add(new Students(Convert.ToInt32(data[0]), data[1], Convert.ToInt32(data[2]), data[3]));
                    Console.WriteLine(line);
                }
                sr.Close();

            }
            public void GetByName(string path, string name)
            {
                List<Students> studentsList = new List<Students>();
                StreamReader sr = new StreamReader(path);
                Students student = new Students();
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    List<string> data = line.Split(",", 4).ToList();
                    studentsList.Add(new Students(Convert.ToInt32(data[0]), data[1], Convert.ToInt32(data[2]), data[3]));
                    
                }
                sr.Close();
                try
                {
                    student = studentsList.Single(x => x.SName == name);

                    Console.WriteLine("The student details with name " + name);
                    Console.WriteLine(student.ToString());
                }
                catch(Exception ex) {
                    Console.WriteLine("Student record with name " + name + " does not exist \n" + ex.Message);

                }
  
            }
            public void GetSortedList(string filePath)
            {
                List<Students> studs = new List<Students>();
                FileStream studentDetails = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader sr = null;

                string[] sb = new string[4];
                try
                {
                    sr = new StreamReader(studentDetails);
                    while (sr.Peek() >= 0)
                    {
                        int j = 0;
                        string fileContent = sr.ReadLine();
                        string[] s = fileContent.Split(",", 4, StringSplitOptions.None);

                        foreach (var i in s)
                        {
                            sb[j] = i;
                            j++;
                        }
                        studs.Add(new Students(Convert.ToInt32(sb[0]), sb[1], Convert.ToInt32(sb[2]), sb[3]));
                    }

                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine($"{studentDetails} not exist...");
                }
                sr.Close();
                List<Students> sts = studs.OrderBy(x => x.SName).ToList();
                foreach (Students s in sts)
                {
                    Console.WriteLine(s.ToString());
                }

            }


        }
        class StudentDSA
        {
            static void Main(string[] args)
            {
                
                string filePath = @"C:\Users\11035923\Documents\Student.txt";
                StudentBO StudentObj = new StudentBO();


                while (true)
                {
                    Console.WriteLine("Please Enter the number corresponding to the Operation you want to Perform\n 1 : Get All Students \n 2 : Get sorted list\n 3 : search student by name \n 4 : Close App or Exit");
                    int choice = int.Parse(Console.ReadLine());


                    switch (choice)
                    {
                        case 1:
                            //Display Student Details
                            StudentObj.GetAllStudents(filePath);
                            break;
                        case 2:
                            StudentObj.GetSortedList(filePath);
                            break;
                        case 3:
                            Console.WriteLine("Enter name of student to search from list");
                            string name=Console.ReadLine();
                            StudentObj.GetByName(filePath, name);
                            break;
                        case 4:
                            goto exit;
                    }
                    Console.WriteLine("==========================================================================================");
                }
            exit:
                Console.WriteLine("Thank you! the Process has been completed");

            }
        }
    }

}
