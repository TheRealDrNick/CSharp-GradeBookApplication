using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("You need at least 5 students for this operation!");
            }

            Students.Sort((x,y) => x.AverageGrade.CompareTo(y.AverageGrade));
            var first20Percent = Students.Count / 5;
            foreach (var student in Students)
            {
                var studentIndex = Students.IndexOf(student) + 1;
                if(studentIndex <= first20Percent)
                {
                    return 'A';
                }else if(studentIndex <= first20Percent * 2)
                {
                    return 'B';
                }else if(studentIndex <= first20Percent * 3)
                {
                    return 'C';
                }else if(studentIndex <= first20Percent * 4)
                {
                    return 'D';
                }
                
            }
            
            return 'F';
        }
    }
}
