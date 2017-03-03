namespace Data.SmithReview.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item : BaseDomainModel
    {

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(50)]
        public string Icon { get; set; }
    }
}
