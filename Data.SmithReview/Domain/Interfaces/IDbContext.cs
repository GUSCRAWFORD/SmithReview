using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmithReview.Domain.Interfaces {
    public interface IDbContext : IDisposable{   
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity item) where TEntity : class;
        int SaveChanges();
    }
}
