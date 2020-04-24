using System.Data.Entity;
using vodovoz.Models;

namespace vodovoz.DataBaseClasses
{
    public class ApplicationContext : DbContext
    {
        private static string DBConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\vodovoz\vodovoz\VodovozDB.mdf;Integrated Security=True;Connect Timeout=30";

        public ApplicationContext(): base(DBConnection) { }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().
                Property(p => p.Birthday)
                .HasColumnType("datetime2")
                .HasPrecision(0)
                .IsRequired();
        }
    }
}
