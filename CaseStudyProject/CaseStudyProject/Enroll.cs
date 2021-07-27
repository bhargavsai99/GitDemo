using System;
using System.Collections.Generic;
using System.Text;


namespace CaseStudyProject
{
    public class Enroll
    {
        internal Student student { get; set; }
        internal Course course { get; set; }
        internal DateTime enrollmentDate { get; set; }

        internal Enroll(Student student,Course course,DateTime enrollmentDate)
        {

            this.student = student;
            this.course = course;
            this.enrollmentDate = enrollmentDate;
        }
    }
}
    