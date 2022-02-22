using System;
using System.Collections.Generic;

namespace BikesKart.Models
{
    public partial class Store
    {
        public Store()
        {
            Orders = new HashSet<Order>();
            staff = new HashSet<Staff>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Staff> staff { get; set; }
    }
}
