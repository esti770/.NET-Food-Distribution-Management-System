using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{

    public class EmployeeListModel
    {
        ImpBL myBL;
        public EmployeeListModel()
        {
            myBL = new ImpBL();
        }

        public List<Employee> getAllEmployee()
        {
            return myBL.getAllEmployee();
        }
        public List<Division> getAllDivision()
        {
            return myBL.getAllDivision();
        }
        public List<Demand> getAllDemand()
        {
            return myBL.getAllDemand();
        }
        public List<Division> divisionOfEmployee(int id)
        {
            return myBL.divisionOfEmployee(id);
        }
        


    }
}

