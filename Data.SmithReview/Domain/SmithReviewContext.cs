namespace Data.SmithReview.Domain {
    using System.Data.Entity;
    using Interfaces;
    public partial class SmithReviewContext : DbContext, IDbContext {
        public SmithReviewContext()
            : base("name=SmithReviewsContext") {
        }
        public virtual DbSet<ReviewableItem> Items { get; set; }
        public virtual DbSet<AnalyzedItem> AnalyzedItems { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<ReviewableItem>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Item)
                .HasForeignKey(e => e.Reviewing)
                .WillCascadeOnDelete(false);
        }
    }
}
