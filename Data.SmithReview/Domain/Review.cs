namespace Data.SmithReview.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review : BaseDomainModel
    {

        [Required]
        [StringLength(280)]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        public int Reviewing { get; set; }

        public virtual ReviewableItem Item { get; set; }
    }
}
