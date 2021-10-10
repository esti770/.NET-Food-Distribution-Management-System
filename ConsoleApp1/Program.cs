using Corona.BE;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            using (var ctx = new CoronaContext())
            {
                var emp = new Employee(45, "yossi", "peleg", "0987676565", "chanam850@gmail.com", "jerusalem", "Ben", "78");
                ctx.EmployeeList.Add(emp);
                ctx.SaveChanges();
                var emp1 = new Employee(45, "yisrael", "nuch", "056776565", "yisra@gmail.com", "jerusalem", "Ben", "78");
                ctx.EmployeeList.Add(emp1);
                ctx.SaveChanges();
                var adm = new Admin(3456, "456456", "Yosi", "Peleg", "089765645", "yoss@gmail.com");
                ctx.MyAdmin.Add(adm);
                ctx.SaveChanges();

                //    var admin = ctx.MyAdmin.FirstOrDefault();
                //Console.WriteLine(admin);

                //Address address = new Address("jerusalem","yaffo","6");
                //string location = address.ToString() + ", israel";
                //string KEY = @"5rRMSAOyU11mGgkbAlWk3C1y1y0nT2Gv";

                //var client = new RestClient("http://www.mapquestapi.com/geocoding/v1/address");
                //client.Timeout = -1;
                //var request = new RestRequest(Method.POST);
                //request.AddParameter("key", KEY);
                //request.AddParameter("location", location);
                //request.AddParameter("maxResults", 1);
                //request.AddParameter("thumbMaps", false);


                //IRestResponse response = client.Execute(request);
                //Console.WriteLine(response.Content);

                //object deserializeContent = JsonConvert.DeserializeObject<object>(response.Content);
                //Console.WriteLine( JObject.Parse(deserializeContent.ToString()));
                //Console.ReadLine();


                //var dem = new Demand( "kiryat malachi", "Ben Gurion", "8", typeDiv.food, false);
                //ctx.DemandList.Add(dem);
                //ctx.SaveChanges();
                //var dem67 = new Demand( "Jerusalem", "yaffo", "9", typeDiv.medicines, true);
                //ctx.DemandList.Add(dem67);
                //ctx.SaveChanges();
                //var dem1 = new Demand( "Jerusalem", "Ben zion", "9", typeDiv.medicines, true);
                //ctx.DemandList.Add(dem1);
                //ctx.SaveChanges();
                //var dem2 = new Demand( "Jerusalem", "najara", "26", typeDiv.food, true);
                //ctx.DemandList.Add(dem2);
                //ctx.SaveChanges();
                //var dem4 = new Demand( "Jerusalem", "najara", "43", typeDiv.foodAndMedicine, false);
                //ctx.DemandList.Add(dem4);
                //ctx.SaveChanges();


                //  public Division(int empId, DateTime dateDiv, List<Demand> listOfDemand)

                //List<Demand> list = new List<Demand>();
                //list.Add(dem4);
                //var dem5 = new Division(1, new DateTime(2008, 3, 1, 7, 0, 0),list);
                //ctx.DivisionList.Add(dem5);
                ctx.SaveChanges();




            }

        }
    }
}
