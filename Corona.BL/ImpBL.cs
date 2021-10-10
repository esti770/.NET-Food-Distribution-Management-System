using Corona.DAL;
using Corona.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Accord.MachineLearning;
using System.Drawing;


namespace Corona.BL
{

    public class ImpBL
    {
        IDal myDal;
        public ImpBL()
        {
            myDal = new ImpDal();
        }

        #region admin
        public bool addAdmin(Admin admin)
        {
            return myDal.addAdmin(admin);
        }
        public bool updateAdmin(Admin admin)
        {
            return myDal.updateAdmin(admin);
        }
        public Admin getAdmin()
        {
            return myDal.getAdmin();
        }
        #endregion 

        #region employee
        public bool addEmployee(Employee employee)
        {
            return myDal.addEmployee(employee);
        }
        public bool updateEmployee(Employee employee)
        {
            return myDal.updateEmployee(employee);
        }
        public bool removeEmployee(int idEmployee)
        {
            return myDal.removeEmployee(idEmployee);
        }
        public Employee getEmployee(int idEmployee)
        {
            return myDal.getEmployee(idEmployee);
        }
        public List<Employee> getAllEmployee()
        {
            return myDal.getAllEmployee();
        }
        public List<Employee> getEmployeeByPredicate(Func<Employee, bool> predicate)
        {
            return myDal.getEmployeeByPredicate(predicate);
        }
        #endregion

        #region division
        public bool addDivision(Division division)
        {
            return myDal.addDivision(division);
        }
        public bool updateDivision(Division division)
        {
            return myDal.updateDivision(division);
        }
        public bool removeDivision(int idDivision)
        {
            return myDal.removeDivision(idDivision);
        }
        public Division getDivision(int idDivision)
        {
            return myDal.getDivision(idDivision);
        }
        public List<Division> getAllDivision()
        {
            return myDal.getAllDivision();
        }
        public List<Division> getDivisionByPredicate(Func<Division, bool> predicate)
        {
            return myDal.getDivisionByPredicate(predicate);
        }
        public int GetLastCodeDivision()
        {
            return myDal.GetLastCodeDivision();
        }
        #endregion

        #region demand
        public bool addDemand(Demand demand)
        {
            return myDal.addDemand(demand);
        }
        public bool updateDemand(Demand demand)
        {
            return myDal.updateDemand(demand);
        }
        public bool removeDemand(int code)
        {
            return myDal.removeDemand(code);
        }
        public Demand getDemand(int code)
        {
            return myDal.getDemand(code);
        }
        public  List<Demand> getAllDemand()
        {
            return myDal.getAllDemand();
        }
        public List<Demand> getDemandByPredicate(Func<Demand, bool> predicate)
        {
            return myDal.getDemandByPredicate(predicate);
        }
        #endregion

        public bool checkAdmin(string code)
        {
            return (getAdmin().code == code);
        }
        public List<Demand> divisionByCity(string city)
        {
            return (from d in getAllDemand()
                    where d.address.city == city
                    select d).ToList();
        }

        //check if exist cordinate
        public bool VerifyAddress(Address address)
        {
            return new AddressVerification().IsRealAdrress(address);
        }
        //create cordinate
        public double[] GetLatLongFromAddress(Address address)
        {
            return new AddressVerification().GetLatLongFromAddress(address);
        }

        #region CreateGroups
        public int[] k_means(double[][] observations, int K)//{[2,2,1,1,1,1,0,0]
        {
            Accord.Math.Random.Generator.Seed = 0;

            //double[][] observations =

            //{
            //new double[] { 10,  5,  6 },

            // new double[] { -5, -2, -1 },
            // new double[] { -5, -5, -6 },
            // new double[] {  2,  1,  1 },
            // new double[] {  1,  1,  2 },
            // new double[] {  1,  2,  2 },
            // new double[] {  3,  1,  2 },
            // new double[] { 11,  5,  4 },
            // new double[] { 15,  5,  6 },
            //};

            // Create a new K-Means algorithm
            KMeans kmeans = new KMeans(k: K)
            {
                // For example, let's say we would like to consider the importance of 
                // the first column as 0.1, the second column as 0.7 and the third 0.9
                //Distance = new WeightedSquareEuclidean(new double[] { 0.1, 0.7, 1.1 })
            };

            // Compute and retrieve the data centroids
            var clusters = kmeans.Learn(observations);

            // Use the centroids to parition all the data
            int[] labels = clusters.Decide(observations);
            return labels;



        }
        #endregion
        #region createDivision
        public void createDivision(int K, List<Demand> dem)
        {
            AddressVerification ad = new AddressVerification();
            

            double[][] cordinate = new double[dem.Count][];

            int i = 0;
            foreach (var d in dem)
            {
                cordinate[i++] = (ad.GetLatLongFromAddress(d.address));
            }

            //for (int r= 0; r < cordinate.GetLength(0); r++)
            //{
            //    for (int j = 0; j < cordinate.GetLength(1); j++)
            //    {
            //        System.Console.WriteLine("Element({0},{1})={2}", r, j, cordinate[r][j]);
            //    }
            //}[123...,456...,8990,]
            int[] groups = k_means(cordinate, K);//[[2,2,1,1,2,1,0,0]

            //var gro = from g in groups, r in cordinate
            //          group new { dem.First(); }

            Demand[] demArr = dem.ToArray();
            
            for (int numk = 0; numk < K; numk++)
            {
                Division div = new Division(0, DateTime.Today);
                myDal.addDivision(div);
                int myCode = myDal.GetLastCodeDivision();

                for (int y = 0; y < groups.Count(); y++)
                {
                    if (groups[y] == numk)
                    {
                        demArr[y].codeDiv= myCode;
                        myDal.updateDemand(demArr[y]);
                        
                    }
                }
               
                
             
               
               




            }
            
        }
        #endregion

        //פונקציה שמקבלת תעודת זהות של עובד ומחזירה את כל הרשימה של החלוקות שלו
        public List<Division> divisionOfEmployee(int empId)
        {
           return myDal.getDivisionByPredicate((Division x) => x.empId == empId);
        }

        public string MapImageUrl(List<Address> address)
        {
            return myDal.MapImageUrl(address);
        }


    }

}