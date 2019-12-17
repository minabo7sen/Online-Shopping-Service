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
        public ActionResult Delete()
        {
            ShoppingItem WantToDelete = new ShoppingItem();
            return View(WantToDelete);
        }
        [HttpPost]
        public ActionResult Remove(ShoppingItem WantToDelete)
        {
            AdminReference.AdminServiceClient client = new AdminReference.AdminServiceClient();
            client.DeleteItemById(WantToDelete.Id);
            return RedirectToAction("Index");
        }

        public ActionResult Update()
        {
            ShoppingItem Update = new ShoppingItem();
            return View(Update);
        }

        [HttpPost]
        public ActionResult Edit(ShoppingItem Update)
        {
            AdminReference.AdminServiceClient client = new AdminReference.AdminServiceClient();
            client.EditItem(Update.Id, Update.Name, Update.Description, Update.Price, Update.Category);
            return RedirectToAction("Index");
        }

    }
}