using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
	public class OrderDetail
	{
		public int OrderDetailID { get; set; }
		public int OrderID { get; set; }
		public int ItemID { get; set; }
		public int Quantity { get; set; }
	}
}
