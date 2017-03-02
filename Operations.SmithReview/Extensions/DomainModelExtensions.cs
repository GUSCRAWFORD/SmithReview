using Data.SmithReview.Domain;
using Models.SmithReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operations.SmithReview.Extensions {
    public static partial class DomainModelExtensions {
        public static ModelType ToBusinessModel<ModelType, DomainType>(this DomainType domain, Func<DomainType,ModelType> transform = null)
                where DomainType : BaseDomainModel
                where ModelType : BaseBusinessModel, new() {
            if (transform != null) return transform(domain);
            return new ModelType {
                Id = domain.Id
            };
        }
        public static IEnumerable<ModelType> ToBusinessModel<ModelType, DomainType>(this IEnumerable<DomainType> domain, Func<DomainType,ModelType> transform = null)
                where DomainType : BaseDomainModel
                where ModelType : BaseBusinessModel, new() {
            List<ModelType> result = new List<ModelType>();
            foreach(var item in domain) {
                result.Add(ToBusinessModel<ModelType, DomainType>(item, transform));
            }
            return result;
        }
    }
}
