using System;
using System.Collections.Generic;
using System.Text;
using CaseStudyProject;

namespace CaseStudyProject
{
    
    class InterfaceAppEg
    {
        interface IAppEngine
        {
            internal void Introduce(Course course);
            
            internal void Register(Student student);

            internal List<Student> ListofStudents();

            internal void Enrolls(Student student, Course course);

            internal List<Enroll> ListOfEnrolls();


        }
       


    }

}

