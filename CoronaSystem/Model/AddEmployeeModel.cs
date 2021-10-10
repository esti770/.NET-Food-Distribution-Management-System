using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{
    public class AddEmployeeModel
    {
        ImpBL impBL;
        public AddEmployeeModel()
        {
            impBL = new ImpBL();
        }
        public bool addEmployee(Employee employee)
        {
            return impBL.addEmployee(employee);
        }
        public bool VerifyAddress(Address ad)
        {
            return impBL.VerifyAddress(ad);
        }
        public double[] GetLatLongFromAddress(Address ad)
        {
            return impBL.GetLatLongFromAddress(ad);
        }
        public void createDivision(int k,List<Demand> dem)
        {
             impBL.createDivision(k,dem);
        }





    }
}

