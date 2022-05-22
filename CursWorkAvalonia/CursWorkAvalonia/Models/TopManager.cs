using System;
using System.Collections.Generic;

namespace CursWorkAvalonia
{
    public partial class TopManager
    {
        public TopManager()
        {
            Teams = new HashSet<Team>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
