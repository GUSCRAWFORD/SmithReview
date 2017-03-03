namespace Data.SmithReview.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnalyzedItem : Item
    {

        public int? AverageRating { get; set; }
        public int? ReviewCount { get; set; }
        public int? HighestRating { get; set; }
        public int? LowestRating { get; set; }
    }
}
