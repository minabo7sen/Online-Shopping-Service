using ClientApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AdminService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AdminService.svc or AdminService.svc.cs at the Solution Explorer and start debugging.
    public class AdminService : IAdminService
    {
        public int AddItem(string Name, string Description, float Price, string Category)
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            ShoppingItem newItem = new ShoppingItem
            {
                Name = Name,
                Description = Description,
                Price = Price,
                Category = Category
            };
            _context.Items.Add(newItem);

            int Retval = _context.SaveChanges();
            return Retval;
        }

        public int DeleteItemById(int Id)
        {
            ApplicationDbContext _context = new ApplicationDbContext();
             var item = _context.Items.SingleOrDefault(i => i.Id == Id);

            _context.Items.Remove(item);

            int Retval = _context.SaveChanges();
            return Retval;
        }

        public int EditItem(int Id, string Name, string Description, float Price, string Category)
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            var existingItem = _context.Items.SingleOrDefault(i => i.Id == Id);

            existingItem.Name = Name;
            existingItem.Description = Description;
            existingItem.Price = Price;
            existingItem.Category = Category;

            int Retval = _context.SaveChanges();
            return Retval;
        }
    }
}
