using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fahrradladen
{
    public class Fwrs
    {
        private int rsid;
        private int anzahl;

        public Fwrs(int rsid, int anzahl)
        {
            this.rsid = rsid;
            this.anzahl = anzahl;
        }

        public int Rsid { get => rsid; set => rsid = value; }
        public int Anzahl { get => anzahl; set => anzahl = value; }
    }
}
