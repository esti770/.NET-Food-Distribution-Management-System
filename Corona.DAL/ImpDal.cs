using Corona.BE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace Corona.DAL
{
    public class ImpDal : IDal

    {
        public bool addAdmin(Admin admin)
        {
            try
            {
                using (var db = new CoronaContext())
                {
                    if (db.MyAdmin != null)
                        throw new Exception("Admin already in the system");

                    db.MyAdmin.Add(admin);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e) { throw e; }
        }
        public bool updateAdmin(Admin admin)
        {
            try
            {
                using (var myDb = new CoronaContext())
                {
                    if (getAdmin() != null)
                    {
                        myDb.Entry(getAdmin()).CurrentValues.SetValues(admin);
                        myDb.SaveChanges();
                    }

                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public Admin getAdmin()
        {
            using (var db = new CoronaContext())
            {
                var admin = db.MyAdmin.FirstOrDefault();

                return admin;
            }
        }

        public bool addEmployee(Employee employee)
        {
            try
            {
                using (var db = new CoronaContext())
                {
                    //if (getEmployee(employee.id) != null)
                    //    throw new Exception("Employee already in the system");

                    db.EmployeeList.Add(employee);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e) { throw e; }
        }
        public bool updateEmployee(Employee employee)
        {
            try
            {
                using (var myDb = new CoronaContext())
                {
                    var employeeTemp = myDb.EmployeeList.SingleOrDefault(d => d.id.Equals(employee.id));
                    if (employeeTemp != null)
                    {
                        myDb.Entry(employeeTemp).CurrentValues.SetValues(employee);
                        myDb.SaveChanges();
                        return true;
                    }

                }
                return false;
            }
            catch (Exception) { return false; }
        }
        public bool removeEmployee(int idEmployee)
        {
            try
            {
                using (var db = new CoronaContext())
                {
                    List<Division> div =
                        (from d in getAllDivision()
                         where (d.empId == idEmployee) && (d.divide == false)
                         select d).ToList();
                    if (div == null)// if he havent division in the future
                    {
                        db.EmployeeList.Remove(getEmployee(idEmployee));
                        db.SaveChanges();
                    }
                    else// can't remove he have division in the future
                        return false;
                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public Employee getEmployee(int idEmployee)
        {
            using (var db = new CoronaContext())
            {
                var employee = db.EmployeeList.SingleOrDefault(b => b.id.Equals(idEmployee));
                return employee;
            }
        }
        public List<Employee> getAllEmployee()
        {
            using (var db = new CoronaContext())
            {
                return (from b in db.EmployeeList
                        select b).ToList();
            }
        }
        public List<Employee> getEmployeeByPredicate(Func<Employee, bool> predicate)
        {
            using (var db = new CoronaContext())
            {
                return (from b in db.EmployeeList
                        where predicate(b)
                        select b).ToList();
            }
        }

        public bool addDivision(Division division)
        {
            try
            {
                using (var myDb = new CoronaContext())
                {
                    if (getDivision(division.codeDiv) != null)
                        throw new Exception("Division already in the system");

                    myDb.DivisionList.Add(division);
                    myDb.SaveChanges();
                }
                return true;
            }
            catch (Exception e) { return false; }
        }
        public int GetLastCodeDivision()
        {
            using (var myDb = new CoronaContext())
            {
                //char d = myDb.DivisionList.Sql.Last;
                //return d.codeDiv;
                return (myDb.DivisionList.Max(t => t.codeDiv));
            }
        }
        public bool updateDivision(Division division)
        {
            try
            {
                using (var myDb = new CoronaContext())
                {
                    var divisionTemp = myDb.DivisionList.SingleOrDefault(d => d.codeDiv.Equals(division.codeDiv));
                    if (divisionTemp != null)
                    {
                        myDb.Entry(divisionTemp).CurrentValues.SetValues(division);
                        myDb.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public bool removeDivision(int idDivision)
        {
            try
            {
                using (var db = new CoronaContext())
                {
                    if (getDivision(idDivision).divide == false)//if he doesnt already divide
                    {
                        db.EmployeeList.Remove(getEmployee(idDivision));
                        db.SaveChanges();
                    }
                    else
                        return false;
                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public Division getDivision(int idDivision)
        {
            using (var db = new CoronaContext())
            {
                var div = db.DivisionList.SingleOrDefault(b => b.codeDiv.Equals(idDivision));
                return div;
            }
        }
        public List<Division> getAllDivision()
        {
            using (var db = new CoronaContext())
            {
                return (from b in db.DivisionList
                        select b).ToList();
            }
        }
        public List<Division> getDivisionByPredicate(Func<Division, bool> predicate)
        {
            using (var db = new CoronaContext())
            {
                return (from b in db.DivisionList
                        where predicate(b)
                        select b).ToList();
            }
        }

        public bool addDemand(Demand demand)
        {
            try
            {
                using (var db = new CoronaContext())
                {
                    if (getDemand(demand.codeDem) != null)
                        throw new Exception("Demand already in the system");

                    db.DemandList.Add(demand);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception e) { throw e; }
        }
        public bool updateDemand(Demand demand)
        {
            try
            {
                using (var myDb = new CoronaContext())
                {
                    var demandTemp = myDb.DemandList.SingleOrDefault(d => d.codeDem.Equals(demand.codeDem));
                    if (demandTemp != null)
                    {
                        myDb.Entry(demandTemp).CurrentValues.SetValues(demand);
                        myDb.SaveChanges();
                    }

                }
                return true;
            }
            catch (Exception) { return false; }
        }
        public bool removeDemand(int code)//if the demand in the division I cant remove him. but if he in the demand list I can remove him.
        {
            try
            {
                using (var db = new CoronaContext())
                {
                    if (getDemand(code) != null)
                    {
                        db.DemandList.Remove(getDemand(code));
                        db.SaveChanges();
                    }
                    else
                        return false;
                }
                return true;
            }
            catch (Exception) { return false; }

        }
        public Demand getDemand(int code)
        {
            using (var db = new CoronaContext())
            {
                var dem = db.DemandList.SingleOrDefault(b => b.codeDem.Equals(code));
                return dem;
            }
        }
        public List<Demand> getAllDemand()
        {
            using (var myDb = new CoronaContext())
            {
                return (from b in myDb.DemandList
                        select b).ToList();
            }
        }
        public List<Demand> getDemandByPredicate(Func<Demand, bool> predicate)
        {
            using (var db = new CoronaContext())
            {
                return (from b in db.DemandList
                        where predicate(b)
                        select b).ToList();
            }
        }
        public string MapImageUrl(List<Address> address)
        {
            string key = "03jhg7NXBfhDqBHCdDPhM5ywhBiMtn5m";
            //IGeocoder geocoder = new MapQuestGeocoder(key);
            //IEnumerable<Geocoding.Address> addresses = await geocoder.GeocodeAsync(address.ToString());
            //string latlng = addresses.First().Coordinates.Latitude + "," + addresses.First().Coordinates.Longitude;

            // location url 
            string url = @"https://www.mapquestapi.com/staticmap/v5/map" +
             @"?key=" + key + @"&locations=";
             foreach (var a in address)
            {
                url = url + a.ToString() + "||";
                    }

             url=url+@"&size=500,500@2x";
            return url;

            ////daonload static map as Image to filname loction
            //string fileName = Directory.GetCurrentDirectory() + @"\img.jpeg";
            //using (WebClient wc = new WebClient())
            //{
            //    wc.DownloadFile(url, fileName);
            //}

            ////open and convert image to bitmap
            //Bitmap bitmap;
            //using (Stream bmpStream = File.Open(fileName, FileMode.Open))
            //{
            //    Image image = Image.FromStream(bmpStream);

            //    bitmap = new Bitmap(image);
            //}
            //return bitmap;
        }
    }
}


