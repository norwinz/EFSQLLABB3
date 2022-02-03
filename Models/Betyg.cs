using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFSQLLABB3.Models
{
    public partial class Betyg
    {
        public int BetygId { get; set; }
        public int FElevId { get; set; }
        public int FBetygKodId { get; set; }
        public DateTime Datum { get; set; }
        public int FPersonalId { get; set; }
        public int FKursId { get; set; }

        public virtual BetygKod FBetygKod { get; set; }
        public virtual Elev FElev { get; set; }
        public virtual Kurs FKurs { get; set; }
        public virtual Personal FPersonal { get; set; }
    }
}
