using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted) 
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var thresh = (int)Math.Ceiling(Students.Count * 0.2);
            int numBelow = 0;
            
            foreach (Student student in Students)
            {
                if(averageGrade > student.AverageGrade)
                {
                    numBelow++;
                }
            }

            if(numBelow >= (Students.Count - thresh))
            {
                return 'A';
            } else if ((numBelow >= Students.Count - (thresh*2))) {
                return 'B';
            }
            else if ((numBelow >= Students.Count - (thresh * 3)))
            {
                return 'C';
            }
            else if ((numBelow >= Students.Count - (thresh * 4)))
            {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            } 
                base.CalculateStatistics();
            
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);

        }
    }

        
}
