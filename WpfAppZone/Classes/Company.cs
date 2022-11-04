using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppZone.Classes
{
    /// <summary>
    /// Конструктор модели Компания
    /// </summary>
    public class Company
    {
        public int Id { get; set; }

        public string LegalAddress { get; set; }

        public string Name { get; set; }

        public Company() { }

        public Company(int id, string legalAddress, string name)
        { 
            Id = id;
            LegalAddress = legalAddress;
            Name = name;
        }
    }
}
