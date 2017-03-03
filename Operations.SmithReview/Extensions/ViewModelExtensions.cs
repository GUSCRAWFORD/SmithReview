using Data.SmithReview.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Models.SmithReview;
namespace Operations.SmithReview.Extensions {
    public static class ViewModelExtensions {
        public static bool HasEmptyId(this BaseBusinessModel model) {
            return model.Id == 0;
        }
    }
}
