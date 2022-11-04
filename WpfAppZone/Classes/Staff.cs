using System;

namespace WpfAppZone.Classes
{
    /// <summary>
    /// Конструктор модели сотрудников
    /// </summary>
    public class Staff
    {
        private object v1;
        private object v2;
        private object v3;

        /// <summary>
        /// Идентификатор сотрудника.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        public string Name { get; set; }
       

        /// <summary>
        /// Аддресс
        /// </summary>
        public string Address { get; set; }
       

        public string Phone { get; set; }
        

        public Staff() { }

        public Staff(int id, string name, string address, string phone)
        {
            Id = Id;
            Name = name;
            Address = address;
            Phone = phone;
        }

        public Staff(object v1, object v2, object v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
