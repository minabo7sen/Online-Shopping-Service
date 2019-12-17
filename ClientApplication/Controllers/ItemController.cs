using ClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApplication.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            var ItemsList = _context.Items.ToList();
            return View(ItemsList);
        }
        public ActionResult New()
        {
            ShoppingItem NewItem = new ShoppingItem();
            return View(NewItem);
        }

        [HttpPost]
        public ActionResult Save(ShoppingItem NewItem)
        {
            AdminReference.AdminServiceClient client = new AdminReference.AdminServiceClient();
            client.AddItem(NewItem.Name, NewItem.Description, NewItem.Price, NewItem.Category);
            return RedirectToAction("Index");
        }
    }
}