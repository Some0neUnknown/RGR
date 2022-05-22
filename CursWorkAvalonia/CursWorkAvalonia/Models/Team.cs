using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Team
    {
        public Team()
        {
            TeamsLineUps = new HashSet<TeamsLineUp>();
            TeamsResults = new HashSet<TeamsResult>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? TopManagerId { get; set; }

        public virtual TopManager? TopManager { get; set; }
        public virtual ICollection<TeamsLineUp> TeamsLineUps { get; set; }
        public virtual ICollection<TeamsResult> TeamsResults { get; set; }
    }
}
