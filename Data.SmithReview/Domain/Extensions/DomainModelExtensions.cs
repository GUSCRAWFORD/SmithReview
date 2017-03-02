using Data.SmithReview.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmithReview.Domain.Extensions {
    public static class DomainModelExtensions {
        public static bool HasEmptyId(this BaseDomainModel model) {
            return model.Id == 0;
        }
    }
}
