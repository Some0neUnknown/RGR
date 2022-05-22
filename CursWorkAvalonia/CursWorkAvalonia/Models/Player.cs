using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Player
    {
        public Player()
        {
            PlayersResults = new HashSet<PlayersResult>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual TeamsLineUp TeamsLineUp { get; set; } = null!;
        public virtual ICollection<PlayersResult> PlayersResults { get; set; }
    }
}
