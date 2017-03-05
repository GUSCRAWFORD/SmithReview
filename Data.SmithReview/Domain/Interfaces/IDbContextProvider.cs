using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmithReview.Domain.Interfaces {
    public interface IDbContextProvider {
        IDbContext Instance();
    }
}
