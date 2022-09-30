﻿using System;
using System.Collections.Generic;

namespace SSPatients.Models
{
    public partial class ConcentrationUnit
    {
        public ConcentrationUnit()
        {
            Medications = new HashSet<Medication>();
        }

        public string ConcentrationCode { get; set; } = null!;

        public virtual ICollection<Medication> Medications { get; set; }
    }
}
