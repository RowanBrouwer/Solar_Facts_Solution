using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL.Models
{
    public class SolarSystemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StarModel> Stars { get; set; }
        public ICollection<PlanetAndDwarfPlanet> Planets { get; set; }
        public int AmountOfStars
        {
            get { return Stars.Count(); }
        }
    }
}