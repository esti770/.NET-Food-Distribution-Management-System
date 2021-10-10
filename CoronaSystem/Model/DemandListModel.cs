using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{
    public class DemandListModel
    {
        ImpBL impBL;
        public DemandListModel()
        {
            impBL = new ImpBL();
        }
        public List<Demand> getAllDemand()
        {
            return impBL.getAllDemand();
        }
        public Demand getDemand(int code)
        {
            return impBL.getDemand(code);
        }
        public void createDivision(int k,List<Demand> dem)
        {
             impBL.createDivision(k, dem);
        }
        


    }
}
