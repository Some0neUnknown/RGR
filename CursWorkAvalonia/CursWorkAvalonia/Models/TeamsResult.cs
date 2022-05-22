using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class TeamsResult
    {
        public long Id { get; set; }
        public long TeamId { get; set; }
        public long? Result { get; set; }
        public long TournamentId { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual Tournament Tournament { get; set; } = null!;
    }
}
