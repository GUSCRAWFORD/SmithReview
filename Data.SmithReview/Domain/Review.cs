namespace Data.SmithReview.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Review
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(280)]
        public string Comment { get; set; }

        [Required]
        [StringLength(10)]
        public string Rating { get; set; }

        public int Reviewing { get; set; }

        public virtual Item Item { get; set; }
    }
}
