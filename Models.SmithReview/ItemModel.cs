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
        public int SampleSize { get; set; }
        public int Highest { get; set; }
        public int Lowest { get; set; }
    }
}
