using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Linq;
using System.Web.Mvc;
using InventoryManagementSystem.Models;
using System.Web.Helpers;

namespace InventoryManagementSystem.Controllers
{
	public class AccountController : Controller
	{
		private readonly InventoryDbContext _db = new InventoryDbContext();

		public ActionResult Login() => View();

		[HttpPost]
		public ActionResult Login(string username, string password)
		{
			var user = _db.Users.SingleOrDefault(u => u.Username == username);
			if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
			{
				Session["UserID"] = user.UserID;
				Session["Role"] = user.Role;
				return RedirectToAction("Index", "Home");
			}

			ViewBag.Error = "Invalid username or password";
			return View();
		}

		public ActionResult Register() => View();

		[HttpPost]
		public ActionResult Register(User user, string password)
		{
			user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
			_db.Users.Add(user);
			_db.SaveChanges();
			return RedirectToAction("Login");
		}

		public ActionResult Logout()
		{
			Session.Clear();
			return RedirectToAction("Login");
		}
	}
}
