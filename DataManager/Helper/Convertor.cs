using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using DataManager.Models;

namespace DataManager.Helper
{
    public class Convertor
    {

        public string ListToCSV(List<DataModel> data)
        {
            string header = "IDFATTURA;DATAEMISSIONE;NOMELOTTO;ESITO";
            string csv = header+"\n";
            foreach (var item in data)
            {
                string temp="";
                temp+=String.Join(",", item.IDFATTURA);
                temp += String.Join(",", item.DATAEMISSIONE);
                temp += String.Join(",", item.NOMELOTTO);
                temp += String.Join(",", item.ESITO);
                csv += temp + "\n";
            }
            return csv;
        }
        public string ListToXML(List<DataModel> data)
        {
            XmlDataModel model = new XmlDataModel();
            model.rows = data;
            using (StringWriter stringWriter = new StringWriter(new StringBuilder()))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(XmlDataModel));
                xmlSerializer.Serialize(stringWriter, model);
                return stringWriter.ToString();
            }

        }
    }
}
