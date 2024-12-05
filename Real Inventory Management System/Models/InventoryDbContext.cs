using System.Data.Entity;

namespace InventoryManagementSystem.Models
{
	public class InventoryDbContext : DbContext
	{
		public InventoryDbContext() : base("name=InventoryDbContext") { }

		public DbSet<User> Users { get; set; }
		public DbSet<Inventory> Inventories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		// Ensure this method exists
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Inventory>()
				.Property(i => i.Price)
				.HasColumnType("decimal")
				.HasPrecision(10, 2);  // Ensuring the column uses decimal(10,2)
		}
	}
}
