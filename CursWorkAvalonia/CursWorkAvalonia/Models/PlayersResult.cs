using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class PlayersResult
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public long? Result { get; set; }

        public virtual Player Player { get; set; } = null!;
    }
}
