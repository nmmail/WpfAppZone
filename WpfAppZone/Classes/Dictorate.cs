using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppZone.Classes
{
    /// <summary>
    /// Модель Директориию.
    /// </summary>
    public class Dictorate
    {
        public int Id { get; set; }

        public string FIO { get; set; }

        public string Phone { get; set; }

        public string Educateion { get; set; }

        public string NameInstitution { get; set; }

        public string Address { get; set; }

        public Dictorate() { }

        public Dictorate(int id , string fIO, string address,string phone, string educateion, string nameInstitution)
        {
            if(fIO.Length == 0 || phone.Length == 0 || educateion.Length == 0 || nameInstitution.Length == 0)
            {
                throw new ArgumentNullException("Значение пусто");
            }
            Address = address;
            Id = id;
            FIO = fIO;
            Phone = phone;
            Educateion = educateion;
            NameInstitution = nameInstitution;
        }
    }
}
