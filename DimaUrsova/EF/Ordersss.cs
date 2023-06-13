using System;
using System.Collections.Generic;
using System.Linq;

namespace DimaUrsova.EF
{
    public partial class Ordersss
    {

        public Ordersss()
        {
            Stocks = new HashSet<Stock>();
        }

        public List<EF.Stock> StockNavigation()
        {   
                List<EF.Stock> result = App.Context.Stocks.Where(p => p.OrdersCode == this.OrdersCode).ToList();
            return result;   
        }

        public long OrdersCode { get; set; }
     
        public string NameDevice { get; set; } = null!;
        public string? Breaking { get; set; }
        public string Appearance { get; set; } = null!;
        public string DateOrder { get; set; } = null!;
        public double AllSum { get; set; }
        public long CustomerCode { get; set; }
        public string Status { get; set; } = null!;
        public long? WorkerCodeMen { get; set; }
        public long? WorkerCodeMas { get; set; }

        public virtual Customer CustomerCodeNavigation { get; set; } = null!;
        public virtual Worker? WorkerCodeMasNavigation { get; set; }
        public virtual Worker? WorkerCodeMenNavigation { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
