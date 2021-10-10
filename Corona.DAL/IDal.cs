using Corona.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Corona.DAL
{
    public interface IDal
    {
        bool addAdmin(Admin admin);
        bool updateAdmin(Admin admin);
        Admin getAdmin();

        bool addEmployee(Employee employee);
        bool updateEmployee(Employee employee);
        bool removeEmployee(int idEmployee);
        Employee getEmployee(int idEmployee);
        List<Employee> getAllEmployee();
        List<Employee> getEmployeeByPredicate(Func<Employee, bool> predicate);

        bool addDivision(Division division);
        bool updateDivision(Division division);
        bool removeDivision(int idDivision);
        Division getDivision(int idDivision);
        int GetLastCodeDivision();
        List<Division> getAllDivision();
        List<Division> getDivisionByPredicate(Func<Division, bool> predicate);

        bool addDemand(Demand demand);
        bool updateDemand(Demand demand);
        bool removeDemand(int code);
        Demand getDemand(int code);
        List<Demand> getAllDemand();
        List<Demand> getDemandByPredicate(Func<Demand, bool> predicate);

        string MapImageUrl(List<Address> address);
    }
}
