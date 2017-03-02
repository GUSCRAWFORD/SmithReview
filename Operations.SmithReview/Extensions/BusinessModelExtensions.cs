using Data.SmithReview.Domain;
using Models.SmithReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.SmithReview.Extensions {
    public static partial class BusinessModelExtensions {
        public static DomainType ToDomainModel<ModelType, DomainType>(this ModelType model, Func<ModelType, DomainType> transform = null)
                where DomainType : BaseDomainModel, new()
                where ModelType : BaseBusinessModel {
            if (transform != null) return transform(model);
            return new DomainType {
                Id = model.Id
            };
        }
        public static IEnumerable<DomainType> ToDomainModel<ModelType, DomainType>(this IEnumerable<ModelType> model, Func<ModelType, DomainType> transform = null)
                where DomainType : BaseDomainModel, new ()
                where ModelType : BaseBusinessModel {
            List<DomainType> result = new List<DomainType>();
            foreach(var item in model) {
                result.Add(ToDomainModel<ModelType, DomainType>(item, transform));
            }
            return result;
        }
    }
}
