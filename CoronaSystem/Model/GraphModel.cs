using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{
    public class GraphModel
    {
        ImpBL impBL;
        public GraphModel()
        {
            impBL = new ImpBL();
        }
        public List<Division> getAllDivision()
        {
            return impBL.getAllDivision();
        }
        public List<Division> getDivisionByPredicate(Func<Division, bool> predicate)
        {
            return impBL.getDivisionByPredicate(predicate);
        }
    }
}