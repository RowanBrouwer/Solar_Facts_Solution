using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL.Models
{
    public class PlanetAndDwarfPlanet : CelestialObjectBase
    {
        public int Id { get; set; }
        public int StarId { get; set; }
        public Star StarToOrbit { get; set; }
        public int KnownMoons { get; set; }
        public long OrbitDistanceInKM { get; set; }
        public double OrbitPeriodInDays { get; set; }
        public CelestialTypeEnum Type { get; set; }
    }
}
