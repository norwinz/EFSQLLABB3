﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFSQLLABB3.Models
{
    public partial class Klass
    {
        public Klass()
        {
            Elev = new HashSet<Elev>();
        }

        public int KlassId { get; set; }
        public string KlassKod { get; set; }
        public int FProgramId { get; set; }

        public virtual Program FProgram { get; set; }
        public virtual ICollection<Elev> Elev { get; set; }
    }
}
