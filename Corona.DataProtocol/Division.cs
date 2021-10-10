using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Corona.BE
{
    public class Division
    {
        [Key]
        public int codeDiv { get; set; }
        public int empId { get; set; }
        public DateTime dateDiv { get; set; }

        //public List<Demand> listOfDemand { get; set; }
        public bool divide { get; set; }
        public Division() { }
        //{

        //    this.empId =0;
        //    this.dateDiv = new DateTime();
        //    this.dateDiv = DateTime.Today;

        //    this.divide = false;

        //    //codeDiv = (int)( DateTime.Now.Ticks);
        //    //Console.WriteLine(codeDiv);
        //}
        public Division(int empId, DateTime dateDiv)
        {
           //codeDiv = id;
            this.empId = 0;
            this.dateDiv = dateDiv;
           
            this.divide = false;
        }
        public override string ToString() {
            string st = "code division: " + codeDiv.ToString()+" ";
            
            return st;
        }
    }
}
