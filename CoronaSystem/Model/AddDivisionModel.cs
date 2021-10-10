using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{

    public class AddDivisionModel
    {
        ImpBL impBL;
        public AddDivisionModel()
        {
            impBL = new ImpBL();
        }
        public List<Division> getAllDivision()
        {
            return impBL.getAllDivision();
        }
        public List<Employee> getAllEmployee()
        {
            return impBL.getAllEmployee();
        }
        public void updateDivision(Division d)
        {
             impBL.updateDivision( d);
        }

    }
}
    

