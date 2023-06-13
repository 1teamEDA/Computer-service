using System;
using System.Collections.Generic;

namespace DimaUrsova.EF
{
    public partial class Customer
    {
        public Customer()
        {
            Orderssses = new HashSet<Ordersss>();
        }

        public long CustomerCode { get; set; }
        public string CustomerPib { get; set; } = null!;
        public string CustomerNomer { get; set; } = null!;
        public string CustomerAddress { get; set; } = null!;
        public string CustomerDocument { get; set; } = null!;

        public virtual ICollection<Ordersss> Orderssses { get; set; }
    }
}
