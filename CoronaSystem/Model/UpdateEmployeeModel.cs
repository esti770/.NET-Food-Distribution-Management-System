using Corona.BL;
using Corona.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{
    class UpdateEmployeeModel
    {
        ImpBL impBL;
        public UpdateEmployeeModel()
        {
            impBL = new ImpBL();
        }
        public bool updateEmployee(Employee employee)
        {
            return impBL.updateEmployee(employee);
        }
        public Employee getEmployee(int idemployee)
        {
            return impBL.getEmployee(idemployee);
        }
    }
}

