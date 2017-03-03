using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SmithReview {
    public class ReviewModel : BaseBusinessModel {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public ItemModel Reviewing { get; set; }
    }
}
