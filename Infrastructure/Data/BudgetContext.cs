
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions<BudgetContext> options) : base(options)
        {

        }
        public DbSet<Record> Record { get; set; }
        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>()
            .HasOne<Category>(c => c.Category)
                .WithMany(r => r.Records)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Record>()
            .Property(p => p.Value)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Category>()
            .Property(c => c.Id)
            .ValueGeneratedNever();

        }
    }
}