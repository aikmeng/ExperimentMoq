
using System;
namespace ExperimentMoq
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new CustomDbContext())
            {
                var processor = new Processor(dbContext);
                var dbEntity = processor.Find(1);
                Console.Write(dbEntity.Id + " " + dbEntity.Name);
            }
        }
    }
}
