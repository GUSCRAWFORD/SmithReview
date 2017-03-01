namespace Data.SmithReview.Domain {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SmithReviewsContext : DbContext {
        public SmithReviewsContext()
            : base("name=SmithReviewsContext") {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Item>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.Reviewing)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Review>()
                .Property(e => e.Rating)
                .IsFixedLength();
        }
    }
}
