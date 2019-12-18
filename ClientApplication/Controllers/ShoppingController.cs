using ClientApplication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientApplication.Controllers
{
    public class ShoppingController : Controller
    {
        private ApplicationDbContext _context;
        public ShoppingController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Shopping
        public ActionResult Index()
        {
            var AllItems = _context.Items.ToList();
            return View(AllItems);
        }

        public ActionResult Details(int Id)
        {
            var Item = _context.Items.SingleOrDefault(i => i.Id == Id);

            return View(Item);
        }

        public ActionResult AddToCart(int Id)
        {
            UserReference.UserServiceClient client = new UserReference.UserServiceClient();
            client.AddToCart(Id, User.Identity.GetUserName());

            return RedirectToAction("MyCart");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            UserReference.UserServiceClient client = new UserReference.UserServiceClient();
            client.RemoveFromCart(Id, User.Identity.GetUserName());

            return RedirectToAction("MyCart");

        }
        
        public ActionResult MyCart()
        {
            var username = User.Identity.GetUserName();

            var user = _context.Users.SingleOrDefault(u => u.UserName == username);

            return View(user.ShoppingCart);
        }
   
    }
}