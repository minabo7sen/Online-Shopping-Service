using ClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApplication.Controllers
{
    [Authorize(Roles = "Admins")]
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

        public ActionResult Edit(int Id)
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            var ItemWeWantToEdit = _context.Items.SingleOrDefault(i => i.Id == Id);

            return View("New", ItemWeWantToEdit);

        }
        
        [HttpPost]
        public ActionResult Save(ShoppingItem NewItem)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
            AdminReference.AdminServiceClient client = new AdminReference.AdminServiceClient();

            if (NewItem.Id == 0)
            {

                client.AddItem(NewItem.Name, NewItem.Description, NewItem.Price, NewItem.Category);
            }
            else
            {
                client.EditItem(NewItem.Id, NewItem.Name, NewItem.Description, NewItem.Price, NewItem.Category);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            AdminReference.AdminServiceClient client = new AdminReference.AdminServiceClient();
            client.DeleteItemById(Id);

            return RedirectToAction("Index");
        }

    }
}