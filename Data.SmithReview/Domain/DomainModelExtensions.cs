using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SmithReview.Domain {
    public static class DomainModelExtensions {
        public static bool HasEmptyId(this BaseDomainModel model) {
            return model.Id == 0;
        }
    }
}
