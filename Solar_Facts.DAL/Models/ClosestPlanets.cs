﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL.Models
{
    public class ClosestPlanets
    {
        public PlanetAndDwarfPlanet PlanetA { get; set; }
        public PlanetAndDwarfPlanet PlanetB { get; set; }
        public long Distance { get; set; }
    }
}
