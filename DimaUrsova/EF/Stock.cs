using System;
using System.Collections.Generic;

namespace DimaUrsova.EF
{
    public partial class Stock
    {
        public long StockCode { get; set; }
        public long Quantity { get; set; }
        public long DetailsCode { get; set; }
        public long? OrdersCode { get; set; }

        public virtual Detail DetailsCodeNavigation { get; set; } = null!;
        public virtual Ordersss? OrdersssCodeNavigation { get; set; }
    }
}
