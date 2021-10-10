using Corona.BE;
using Corona.BL;
using CoronaSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{
    public class AddDemandModel
    {
        ImpBL impBL;
        public AddDemandModel()
        {
            impBL = new ImpBL();
        }
        public bool addDemand(Demand dem)
        {
            return impBL.addDemand(dem);
        }
    }
}
