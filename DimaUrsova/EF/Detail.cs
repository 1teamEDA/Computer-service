using System;
using System.Collections.Generic;

namespace DimaUrsova.EF
{
    public partial class Detail
    {
        public Detail()
        {
            Stocks = new HashSet<Stock>();
        }

        public long DetailsCode { get; set; }
        public string NameDetails { get; set; } = null!;
        public long QuantityInstock { get; set; }
        public long CostDetails { get; set; }
        public long CostService { get; set; }

        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
