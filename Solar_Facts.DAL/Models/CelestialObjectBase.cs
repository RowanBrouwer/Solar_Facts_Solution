using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL.Models
{
    public abstract class CelestialObjectBase
    {
        public virtual string Name { get; set; }
        public virtual int DiameterInKM { get; set; }
        public virtual int SurfaceTempMin { get; set; }
        public virtual int SurfaceTempMax { get; set; }
        public virtual int SurfaceTempAvg
        {
            get { return (SurfaceTempMin + SurfaceTempMax) / 2; }
        }
    }
}
