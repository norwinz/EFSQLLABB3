using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFSQLLABB3.Models
{
    public partial class Kurs
    {
        public Kurs()
        {
            Betyg = new HashSet<Betyg>();
        }

        public int KursId { get; set; }
        public string KursNamn { get; set; }
        public int FPersonalId { get; set; }
        public int FElevId { get; set; }

        public virtual Elev FElev { get; set; }
        public virtual Personal FPersonal { get; set; }
        public virtual ICollection<Betyg> Betyg { get; set; }
    }
}
