using Data.SmithReview.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmithReview {
    public class SmithReviewContextProvider : IDbContextProvider  {
        private IDbContext _instance;
        public IDbContext Instance() {
            return _instance ?? (_instance = new Domain.SmithReviewContext());
        }
    }
}
