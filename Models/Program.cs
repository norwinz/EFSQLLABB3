using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFSQLLABB3.Models
{
    public partial class Program
    {
        public Program()
        {
            Klass = new HashSet<Klass>();
        }

        public int ProgramId { get; set; }
        public string ProgramTyp { get; set; }

        public virtual ICollection<Klass> Klass { get; set; }
    }
}
