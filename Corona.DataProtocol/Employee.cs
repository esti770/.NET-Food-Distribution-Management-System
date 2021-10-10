using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Corona.BE
{
    public class Employee
    {        
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string numberPhone { get; set; }
        public string mail { get; set; }
        public Address address { get; set; }

        public Employee() { }
        public Employee(int id)
        {
            this.id = id;

        }

        public Employee(int id, string firstName, string lastName, string numberPhone, string mail, string city, string street, string numberOfBuilding)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.numberPhone = numberPhone;
            this.mail = mail;
            this.address = new Address(city,street,numberOfBuilding);
        }
        public override string ToString()
        {
            string st = "id Employee: " + id.ToString() + "firstName: " + firstName;

            return st;
        }

    }
}