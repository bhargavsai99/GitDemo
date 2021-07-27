using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudyProject
{

    internal class Course
    {
        internal int id { get; set; }
        internal string name { get; set; }
        internal DateTime duration { get; set; }
        internal double fees { get; set; }

        internal Course(int id, string name, DateTime duration, double fees)
        {
            this.id = id;
            this.name = name;
            this.duration = duration;
            this.fees = fees;
        }

        internal virtual double CalculateMonthlyFee(double fees)
        {
            return fees / 12;
        }
    }

    class DegreeCourse : Course
    {
        internal enum Level
        {
            Bachelors,
            Masters
        };
        internal Level level;
        internal bool isPlacementAvailable;

        internal DegreeCourse(int id, string name, DateTime duration, double fees, string levelp, bool isPlacementAvailable) : base(id, name, duration, fees)
        {
            this.isPlacementAvailable = isPlacementAvailable;
            level = (Level)Enum.Parse(typeof(Level), levelp);
        }
        internal override double CalculateMonthlyFee(double fees)
        {
            return (fees / 12) + (0.1 * (fees / 12));
        }

    }

    class DiplomaCourse : Course
    {
        internal enum Type
        {
            Professional,
            Academic
        };

        internal Type type;

        DiplomaCourse(int id, string name, DateTime duration, double fees, string typep) : base(id, name, duration, fees)
        {
            type = (Type)Enum.Parse(typeof(Type), typep);
        }

        internal override double CalculateMonthlyFee(double fees)
        {
            if (type == (Type)0) { return (fees / 12) + (0.1 * (fees / 12)); }
            else if (type == (Type)1) { return (fees / 12) + (0.05 * (fees / 12)); }
            else return -1;
        }

    }
}


