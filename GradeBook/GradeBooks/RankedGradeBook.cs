using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name) 
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
    }
}
