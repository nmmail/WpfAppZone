using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppZone.Classes
{
    public class Servises
    {
        public int Id { get; set; }

        public string Zones { get; set; }

        public string Name { get; set; }

        public int IdStaff { get; set; }

        public Servises(int id, string zones, string name, int idStaff)
        {
            Id = id;
            Zones = zones;
            Name = name;
            IdStaff = idStaff;
        }

        public Servises() { }
    }
}
