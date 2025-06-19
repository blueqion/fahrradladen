using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fahrradladen
{
    public class Rohstoffe
    {
        private int rsId;
        private string rsBezeichnung;
        private double rsPreis;

        public Rohstoffe(int rsId, string rsBezeichnung, double rsPreis)
        {
            this.rsId = rsId;
            this.rsBezeichnung = rsBezeichnung;
            this.rsPreis = rsPreis;
        }

        public int RsId { get => rsId; set => rsId = value; }
        public string RsBezeichnung { get => rsBezeichnung; set => rsBezeichnung = value; }
        public double RsPreis { get => rsPreis; set => rsPreis = value; }
    }
}
