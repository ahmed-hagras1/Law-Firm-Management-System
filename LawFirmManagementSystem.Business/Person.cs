using LawFirmManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirmManagementSystem.Business
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Person()
        {
            Id = 0;
            FullName = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
        }
        private Person(int id, string fullName, string phone, string address)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
            Address = address;
        }
        public static Person GetPerson(int personId)
        {
            string fullName = string.Empty, phone = string.Empty, address = string.Empty;

            if (PeopleDataAccess.GetPerson(personId,ref fullName, ref phone, ref address))
            {
                return new Person(personId, fullName, phone, address);
            }

            return new Person();
        }
    }
}
