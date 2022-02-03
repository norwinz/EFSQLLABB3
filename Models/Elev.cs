using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFSQLLABB3.Models
{
    public partial class Elev
    {
        public Elev()
        {
            Betyg = new HashSet<Betyg>();
            Kurs = new HashSet<Kurs>();
        }

        public int ElevId { get; set; }
        public string Fnamn { get; set; }
        public string Enamn { get; set; }
        public string Pnummer { get; set; }
        public int FPronomenId { get; set; }
        public int FKlassId { get; set; }

        public virtual Klass FKlass { get; set; }
        public virtual Pronomen FPronomen { get; set; }
        public virtual ICollection<Betyg> Betyg { get; set; }
        public virtual ICollection<Kurs> Kurs { get; set; }
    }
}
