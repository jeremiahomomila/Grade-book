using System;
using System.Collections.Generic;

namespace src
{
    public delegate void GradedAddedDelegate(object sender, EventArgs args);

    public abstract class book : NamedObject, Ibook
    {
        public book(string name) : base(name)
        {
        }

        public abstract event GradedAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract statistics Getstat();
   
    }

        public interface Ibook
        {
            void AddGrade(double grade);
            statistics Getstat();
            string Name { get; }
            event GradedAddedDelegate GradeAdded;
        }
    public class InMemoryBook : book
    {
        public InMemoryBook(string name) : base(name)
        {

            grades = new List<double>();
            Name = name;
        }

        public void AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A': AddGrade(90); break;

                case 'B': AddGrade(80); break;

                case 'C': AddGrade(70); break;

                case 'D': AddGrade(60); break;
                default: AddGrade(0); break;
            }
        }

        public override void AddGrade(double grade)
        {  
            if (grade <= 100 && grade >= 0)
            {
                  grades.Add(grade);
                  if (GradeAdded != null)
                  {
                      GradeAdded(this, new EventArgs());
                  }
            }
            else
            {
                throw new ArgumentException($"invalid {nameof(grade)}");
            }
          
        }

        public override event GradedAddedDelegate  GradeAdded;

        public override statistics Getstat()
        {
            var result = new statistics();
          
           for (var index = 0; index < grades.Count; index++)
            {
                result.add(grades[index]);
            }
                     
            return result; 

        }

        private List<double> grades; 

        public const string CATEGORY = "Science";
    

    }
}