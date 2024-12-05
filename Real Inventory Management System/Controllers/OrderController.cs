using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Linq;
using System.Web.Mvc;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
	public class OrderController : Controller
	{
		private readonly InventoryDbContext _db = new InventoryDbContext();

		public ActionResult Index()
		{
			var orders = _db.Orders.ToList();
			return View(orders);
		}

		public ActionResult CreateOrder()
		{
			var items = _db.Inventories.ToList();
			return View(items);
		}

		[HttpPost]
		public ActionResult CreateOrder(int[] itemIds, int[] quantities)
		{
			var userId = (int)Session["UserID"];
			var order = new Order { UserID = userId, OrderDate = DateTime.Now };
			_db.Orders.Add(order);
			_db.SaveChanges();

			for (int i = 0; i < itemIds.Length; i++)
			{
				_db.OrderDetails.Add(new OrderDetail
				{
					OrderID = order.OrderID,
					ItemID = itemIds[i],
					Quantity = quantities[i]
				});
			}

			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
