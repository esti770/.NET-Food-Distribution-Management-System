using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{

    public class MapModel
    {
        ImpBL impBL;
        public MapModel()
        {
            impBL = new ImpBL();
        }
        public string MapImageUrl(List<Address> address)
        {
            return impBL.MapImageUrl(address);
        }
        public List<Division> getAllDivision()
        {
            return impBL.getAllDivision();
        }
        public List<Demand> getAllDemand()
        {
            return impBL.getAllDemand();
        }
        
    }
}

