using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{
    public class GraphPieModel
    {
        ImpBL impBL;
        public GraphPieModel()
        {
            impBL = new ImpBL();
        }
        public List<Division> getAllDivision()
        {
            return impBL.getAllDivision();
        }
        public Division getDivision(int code)
        {
            return impBL.getDivision(code);
        }

    }
}
