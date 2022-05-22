using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class Tournament
    {
        public Tournament()
        {
            TeamsResults = new HashSet<TeamsResult>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Time { get; set; }

        public virtual ICollection<TeamsResult> TeamsResults { get; set; }
    }
}
