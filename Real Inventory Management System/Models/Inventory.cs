using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
	[Table("Inventory")] // Maps the C# model to the SQL table named "Inventory"
	public class Inventory
	{
		[Key] // Marks ItemID as the primary key
		public int ItemID { get; set; } // Matches the SQL column "ItemID"

		[Required] // Ensures ItemName cannot be null
		[StringLength(100)] // Matches NVARCHAR(100) in SQL
		public string ItemName { get; set; }

		[Required] // Ensures Quantity cannot be null
		public int Quantity { get; set; }

		[Required] // Ensures Price cannot be null
		[Column(TypeName = "decimal(10, 2)")]
		public decimal Price { get; set; }

	}
}

