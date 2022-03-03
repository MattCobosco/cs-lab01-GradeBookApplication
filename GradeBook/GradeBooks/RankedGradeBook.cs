using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Not enough students (<5)");
            
            List<Student> StudentsSorted = Students.OrderByDescending(s => s.AverageGrade).ToList();
            int oneFifth = (int)Math.Ceiling(StudentsSorted.Count *0.2);

            if(StudentsSorted[oneFifth-1] <= averageGrade)
            {

            }

                
        }
    }
}
