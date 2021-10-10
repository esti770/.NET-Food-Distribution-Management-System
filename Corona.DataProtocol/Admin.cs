using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corona.BE
{
    public class Admin
    {
        public int id { get; set; }
        public string code { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string numberPhone { get; set; }
        public string mail { get; set; }
        public Admin() { }

        public Admin(int id, string code, string firstName, string lastName, string numberPhone, string mail)
        {
            this.id = id;
            this.code = code;
            this.firstName = firstName;
            this.lastName = lastName;
            this.numberPhone = numberPhone;
            this.mail = mail;
        }
        public override string ToString() { return id + "," + code + "," + firstName + "," + lastName + "," + numberPhone + "," + mail; }
    }
}
