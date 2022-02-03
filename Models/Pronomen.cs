using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFSQLLABB3.Models
{
    public partial class Pronomen
    {
        public Pronomen()
        {
            Elev = new HashSet<Elev>();
            Personal = new HashSet<Personal>();
        }

        public int PronomenId { get; set; }
        public string PronomenTyp { get; set; }

        public virtual ICollection<Elev> Elev { get; set; }
        public virtual ICollection<Personal> Personal { get; set; }
    }
}
