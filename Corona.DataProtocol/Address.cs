using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corona.BE
{
    public class Address
    {
        public string city { get; set; }
        public string street { get; set; }
        public string numberOfBuilding { get; set; }
        public Address() { }
        public Address(string city, string street, string numberOfBuilding)
        {
            this.city = city;
            this.street = street;
            this.numberOfBuilding = numberOfBuilding;
        }
        public override string ToString() { return street + " " + numberOfBuilding + ", " + city; }



    }
}
