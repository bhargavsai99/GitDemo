using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace CaseStudyProject
{

    internal class Student
    {
        //Property
        int Sid { get; set; }

        string name { get; set; }

        DateTime DateofBirth { get; set; }

        //static string CollegeName { get; set; }

        //Student()
        //{
        // CollegeName = "CBIT";
        //}


        internal Student(int Sid, string name, DateTime DateofBirth)
        {

            this.Sid = Sid;
            this.name = name;
            this.DateofBirth = DateofBirth;
        }

        internal class Info
        {

            public static void display(Student student)
            {
                Console.WriteLine(student.Sid + " " + student.name + " " + (student.DateofBirth).ToString("dd/MM/yyyy"));
            }
        }
        /*
        internal class App
        {
            public static void Scenario()
            {
                Student student1 = new Student(1, "Rama", Convert.ToDateTime("12/2/2019"));
                Student student2 = new Student(2, "Ravi", Convert.ToDateTime("04/06/2019"));
                Student student3 = new Student(3, "Krishna", Convert.ToDateTime("06/08/2017"));

                Info info = new Info();
                Info.display(student1);
                Info.display(student2);
                Info.display(student3);


            }

            public static void Scenario2()
            {
                Student[] students = new Student[3];
                students[0] = new Student(1, "Rama", Convert.ToDateTime("12/2/2019"));
                students[1] = new Student(2, "Ravi", Convert.ToDateTime("04/06/2019"));
                students[2] = new Student(3, "Krishna", Convert.ToDateTime("06/08/2017"));
                foreach (Student su in students)
                {
                    Info.display(su);
                }
            }

            public static void Scenario3()
            {
                Console.WriteLine("Enter the Sid");
                int n = Convert.ToInt32(Console.ReadLine());
                Student[] students = new Student[n];
                for (int i = 0; i < students.Length; i++)
                {
                    Console.WriteLine("Enter the RollNo,Name and DateofBirth");
                    int srollnumber = Convert.ToInt32(Console.ReadLine());
                    String name = Console.ReadLine();
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    students[i] = new Student(srollnumber, name, date);
                }
                foreach (Student su in students)
                {
                    Info.display(su);
                }
            }


        }
        public static void Scenario4()
        {
            Console.WriteLine("Enter number of students");
            int n = Convert.ToInt32(Console.ReadLine());
            ArrayList students = new ArrayList();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Roll No, Name, and DOB");
                int id = Convert.ToInt32(Console.ReadLine());
                String name = Console.ReadLine();
                DateTime date = DateTime.Parse(Console.ReadLine());

                students.Add(new Student(id, name, date));

            }
            foreach (Student student in students)
            {
                Info.display(student);
            }
        }
        */

        public static void Main()
        {
            /*App.Scenario();
            App.Scenario2();
            App.Scenario3();*/

            Console.WriteLine("--------------------------------WELCOME SSM-----------------------------");
            Console.WriteLine("1.Admin\n2.Student");
            int option = Convert.ToInt32(Console.ReadLine());
            PersistentAppEngine persistentAppEngine = new PersistentAppEngine();
            switch(option)
            {
                case 1:
                    Console.WriteLine("1.Introduce Course \n2.Register Student\n3.ListCourses\n4.List Students");
                    int Adminchoice = Convert.ToInt32(Console.ReadLine());
                    switch(Adminchoice)
                    {
                        case 1:
                            persistentAppEngine.Introduce();
                            break;
                        case 2:
                            persistentAppEngine.Register();
                            break;
                        case 3:
                            persistentAppEngine.CallDisplayCourses();
                            break;
                        case 4:
                            persistentAppEngine.CallDisplayStudent();
                            break;
                        case 5:
                            persistentAppEngine.CallDisplayEnrollments();
                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine("1.Enroll");
                    int StudChoice = Convert.ToInt32(Console.ReadLine());
                    switch (StudChoice)
                    {
                        case 1:
                            persistentAppEngine.Enroll();
                            break;
                        case 2:

                            break;
                        default:
                            Console.WriteLine("Invalid");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }
}





