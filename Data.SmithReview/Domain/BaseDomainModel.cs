using System.ComponentModel.DataAnnotations.Schema;

namespace Data.SmithReview.Domain {
    public abstract class BaseDomainModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
