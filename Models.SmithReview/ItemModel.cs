using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SmithReview {
    public class ItemModel : BaseBusinessModel {
        public string Name { get; set; }
        public string Icon { get; set; }
        public double AverageRating { get; set; }
        public int ReviewCount { get; set; }
        public int HighestRating { get; set; }
        public int LowestRating { get; set; }
    }
}
