using Microsoft.EntityFrameworkCore;

namespace ASM.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet cho các thực thể
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Combo> Combos { get; set; }
        public DbSet<ComboDetail> ComboDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình các mối quan hệ
            modelBuilder.Entity<ComboDetail>()
                .HasKey(cd => new { cd.ComboID, cd.FoodID }); // Khóa chính cho ComboDetail

            modelBuilder.Entity<BillDetail>()
                .HasKey(bd => new { bd.BillID, bd.FoodID }); // Khóa chính cho BillDetail

            // Quan hệ 1-n giữa Category và Food
            modelBuilder.Entity<Food>()
                .HasOne(f => f.Category)
                .WithMany(c => c.Foods)
                .HasForeignKey(f => f.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ 1-n giữa Customer và Bill
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bills)
                .HasForeignKey(b => b.CustomerID)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ 1-n giữa Bill và BillDetail
            modelBuilder.Entity<BillDetail>()
                .HasOne(bd => bd.Bill)
                .WithMany(b => b.BillDetails)
                .HasForeignKey(bd => bd.BillID)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ 1-n giữa Combo và ComboDetail
            modelBuilder.Entity<ComboDetail>()
                .HasOne(cd => cd.Combo)
                .WithMany(c => c.ComboDetails)
                .HasForeignKey(cd => cd.ComboID)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ 1-n giữa Food và ComboDetail
            modelBuilder.Entity<ComboDetail>()
                .HasOne(cd => cd.Food)
                .WithMany(f => f.ComboDetails)
                .HasForeignKey(cd => cd.FoodID)
                .OnDelete(DeleteBehavior.Cascade);

            // Quan hệ 1-n giữa BillDetail và Food
            modelBuilder.Entity<BillDetail>()
                .HasOne(bd => bd.Food)
                .WithMany(f => f.BillDetails)
                .HasForeignKey(bd => bd.FoodID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
