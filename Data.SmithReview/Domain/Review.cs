namespace Data.SmithReview.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public partial class Review : BaseDomainModel
    {

        [Required]
        [StringLength(280)]
        public string Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        public int Reviewing { get; set; }

        public virtual ReviewableItem Item { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
