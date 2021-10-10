using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Corona.BE
{
    public class CoronaContext : DbContext
    { 
        public CoronaContext():base("myDb"){ }
        public DbSet<Employee> EmployeeList { get; set; }
        public DbSet<Division> DivisionList { get; set; }
        public DbSet<Demand> DemandList { get; set; }
        public DbSet<Admin> MyAdmin { get; set; }
    }
}