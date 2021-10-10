using Corona.BE;
using Corona.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaSystem.ViewModel
{
    public class EnterUserControlModel
    {
        ImpBL myBL;
        public EnterUserControlModel()
        {
            myBL = new ImpBL();
        }

        public Admin getAdmin()
        {
            return myBL.getAdmin();
        }
    }
}
