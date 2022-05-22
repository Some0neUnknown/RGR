using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class TeamsLineUp
    {
        public long PlayerId { get; set; }
        public long TeamId { get; set; }

        public virtual Player Player { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
