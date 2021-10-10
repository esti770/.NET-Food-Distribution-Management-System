using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Corona.BE
{
    public class Demand
    {
        [Key]
        public int codeDem { get; set; }
        public Address address { get; set; }
        public typeDiv type { get; set; }
        public bool constDivide { get; set; }
        public int codeDiv { get; set; }

        public Demand() { }
        public Demand(string city, string street, string numberOfBuilding, typeDiv type, bool constDivide)
        {
            this.address = new Address(city, street, numberOfBuilding);
            this.type = type;
            this.constDivide = constDivide;
        }
        public override string ToString() { return codeDem + ", " + address.city + ", " + address.street + ", " + address.numberOfBuilding + ", " + type + ", " + (constDivide ? "const divide" : "not const divide"); }
    }
}


