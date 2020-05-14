using System;
using System.Collections.Generic;

namespace CW_3_v2.ModelsFramework
{
    public partial class Project
    {
        public Project()
        {
            Task = new HashSet<Task>();
        }

        public int IdProject { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
