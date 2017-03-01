using System.ComponentModel.DataAnnotations.Schema;

namespace Data.SmithReview.Domain {
    public class BaseDomainModel {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
