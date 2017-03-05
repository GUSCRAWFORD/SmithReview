using Data.SmithReview.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SmithReview {
    public class Page<TModel>
        where TModel : BaseBusinessModel {
        public IEnumerable<TModel> Collection { get; set; }
        public int OfTotal { get; set; }
    }
}
