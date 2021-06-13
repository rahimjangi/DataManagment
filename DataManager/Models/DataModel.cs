using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Models
{
    public class DataModel
    {
        public string IDFATTURA { get; set; }
        public DateTime DATAEMISSIONE { get; set; }
        public string NOMELOTTO { get; set; }
        public ESITO ESITO { get; set; }
    }

    public enum ESITO
    {
        MC,
        RC,
        NS
    }
}
