using System;
using System.Collections.Generic;

namespace DimaUrsova.EF
{
    public partial class Worker
    {
        public Worker()
        {
            OrdersssWorkerCodeMasNavigations = new HashSet<Ordersss>();
            OrdersssWorkerCodeMenNavigations = new HashSet<Ordersss>();
        }

        public long WorkerCode { get; set; }
        public string WorkerPib { get; set; } = null!;
        public string WorkerNumber { get; set; } = null!;
        public string WorkerDocument { get; set; } = null!;
        public long PositionCode { get; set; }

        public virtual Positionnn PositionCodeNavigation { get; set; } = null!;
        public virtual ICollection<Ordersss> OrdersssWorkerCodeMasNavigations { get; set; }
        public virtual ICollection<Ordersss> OrdersssWorkerCodeMenNavigations { get; set; }
    }
}
