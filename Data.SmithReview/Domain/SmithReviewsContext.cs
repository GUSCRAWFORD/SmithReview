namespace Data.SmithReview.Domain {
    using System.Data.Entity;
    using Interfaces;
    public partial class SmithReviewsContext : DbContext, IDbContext {
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
