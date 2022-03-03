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
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students");
            }

            int oneFifth = (int)Math.Ceiling(Students.Count * 0.2);
            List<double> studentsSorted = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();

            if (studentsSorted[oneFifth - 1] <= averageGrade)
                return 'A';

            if (studentsSorted[oneFifth * 2 - 1] <= averageGrade)
                return 'B';

            if (studentsSorted[oneFifth * 3 - 1] <= averageGrade)
                return 'C';

            if (studentsSorted[oneFifth * 4 - 1] <= averageGrade)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
