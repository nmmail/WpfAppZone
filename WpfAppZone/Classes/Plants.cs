using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppZone.Classes
{
    public class Plants
    {
        public int Id { get; set; }

        public DateTime DisembarkationDate { get; set; }

        public DateTime PlantAge { get; set; }

        public string ViewPlant { get; set; }

        public string WateringMode {get;set;}

        public int WateringRate { get; set; }


        public Plants() { }

        public Plants(int id, DateTime disembarkationDate, DateTime plantAge, string viewPlant, string wateringMode, int wateringRate)
        {        
            Id = id;
            DisembarkationDate = disembarkationDate;
            PlantAge = plantAge;
            ViewPlant = viewPlant;
            WateringMode = wateringMode;
            WateringRate = wateringRate;
        }
    }
}
