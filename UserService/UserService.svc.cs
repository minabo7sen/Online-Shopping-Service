using ClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        public void AddToCart(int Id, string Username)
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            var item = _context.Items.SingleOrDefault(i => i.Id == Id);
            var user = _context.Users.SingleOrDefault(u => u.UserName.Equals(Username));

            if (user.ShoppingCart.SingleOrDefault(i => i.ItemId == Id) == null)
            {
                CartItem cartItem = new CartItem
                {
                    User = user,
                    Item = item,
                    Quantity = 1
                };
                user.ShoppingCart.Add(cartItem);
            }

            else
            {
                CartItem cartItem = user.ShoppingCart.SingleOrDefault(i => i.ItemId == Id);
                cartItem.Quantity++;
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(int Id, string Username)
        {
            throw new NotImplementedException();
        }
    }
}
