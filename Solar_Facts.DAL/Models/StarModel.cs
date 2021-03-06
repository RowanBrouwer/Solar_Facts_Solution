﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL.Models
{
    public sealed class StarModel : CelestialObjectBase
    {
        public int Id { get; set; }
        public int CoreTemp { get;  set; }
        public int SolarSystemId { get; set; }
        public SolarSystemModel solarSystem { get; set; }
        public long Age { get; set; }
    }
}
