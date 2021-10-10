using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.Model
{
    public class ListOfDivisionModel
    {
        ImpBL impBL;
        public ListOfDivisionModel()
        {
            impBL = new ImpBL();
        }
        public List<Division> getAllDivision()
        {
            return impBL.getAllDivision();
        }
        public Division getDivision(int codeDiv)
        {
            return impBL.getDivision(codeDiv);
           

        }
        public void updateDivision(Division d)
        {
             impBL.updateDivision(d);


        }
        
    }
}