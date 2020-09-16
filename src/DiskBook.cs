using System.IO;

namespace src
{
    public class DiskBook : book
    {
        
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradedAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
         using (var writer = File.AppendText($"{Name}.txt"))
         {
             writer.WriteLine(grade);
             if (GradeAdded != null)
             {
                 GradeAdded(this, new System.EventArgs());
             }
         }
   
        }

        public override statistics Getstat()
        {
           var result = new statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.add(number);
                    line = reader.ReadLine();
                }
            }

           return result;
        }
    }
}