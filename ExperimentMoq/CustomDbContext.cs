using System;
using System.Data.Entity;

namespace ExperimentMoq
{
    public class CustomDbContext : DbContext, IDisposable
    {
        public virtual IDbSet<DbEntity> DbEntities { get; set; }
    }
}
