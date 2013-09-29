using System.Linq;

namespace ExperimentMoq
{
    public class Processor
    {
        private readonly CustomDbContext _dbContext;

        public Processor(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbEntity Find(int id)
        {
            return _dbContext.DbEntities.FirstOrDefault(dbEntity => dbEntity.Id == id);
        }
    }
}
