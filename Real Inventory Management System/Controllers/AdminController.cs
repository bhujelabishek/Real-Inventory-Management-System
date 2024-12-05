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
	public class AdminController : Controller
	{
		private readonly InventoryDbContext _db = new InventoryDbContext();

		public ActionResult Index()
		{
			var inventory = _db.Inventories.ToList();
			return View(inventory);
		}

		public ActionResult AddInventory() => View();

		[HttpPost]
		public ActionResult AddInventory(Inventory inventory)
		{
			_db.Inventories.Add(inventory);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult EditInventory(int id)
		{
			var item = _db.Inventories.Find(id);
			return View(item);
		}

		[HttpPost]
		public ActionResult EditInventory(Inventory inventory)
		{
			_db.Entry(inventory).State = System.Data.Entity.EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult DeleteInventory(int id)
		{
			var item = _db.Inventories.Find(id);
			_db.Inventories.Remove(item);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
