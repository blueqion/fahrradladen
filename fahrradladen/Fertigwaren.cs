using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fahrradladen
{
    public class Fertigwaren
    {
        private int fwID;
        private string fwModel;

        public Fertigwaren(int fwID, string fwModel)
        {
            this.fwID = fwID;
            this.fwModel = fwModel;
        }

        public int FwID { get => fwID; set => fwID = value; }
        public string FwModel { get => fwModel; set => fwModel = value; }
    }
}