using System;
using System.Collections.Generic;

namespace DimaUrsova.EF
{
    public partial class Positionnn
    {
        public Positionnn()
        {
            Workers = new HashSet<Worker>();
        }

        public long PositionCode { get; set; }
        public string PositionP { get; set; } = null!;

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
