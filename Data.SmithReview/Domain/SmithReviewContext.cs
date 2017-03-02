namespace Data.SmithReview.Domain {
    using System.Data.Entity;
    using Interfaces;
    public partial class SmithReviewContext : DbContext, IDbContext {
        public SmithReviewContext(string connectionStringName)
            : base(string.Format("name={0}",connectionStringName)) {
        }
        public SmithReviewContext()
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
        }
    }
}
