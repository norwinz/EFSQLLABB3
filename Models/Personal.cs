using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFSQLLABB3.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Betyg = new HashSet<Betyg>();
            Kurs = new HashSet<Kurs>();
        }

        public int PersonalId { get; set; }
        public string Pfnamn { get; set; }
        public string Penamn { get; set; }
        public int FBefattningId { get; set; }
        public int FPpronomenId { get; set; }

        public virtual Befattning FBefattning { get; set; }
        public virtual Pronomen FPpronomen { get; set; }
        public virtual ICollection<Betyg> Betyg { get; set; }
        public virtual ICollection<Kurs> Kurs { get; set; }
    }
}
