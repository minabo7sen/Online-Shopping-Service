using ClientApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Models
{
    public class CartItem
    {
        [Key, Column(Order = 0), ForeignKey("User")]
        public string UserId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Item")]
        public int ItemId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ShoppingItem Item { get; set; }

        public int Quantity { get; set; }
    }
}
