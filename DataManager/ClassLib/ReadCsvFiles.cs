using DataManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataManager.ClassLib
{
    public class ReadCsvFiles
    {
        public List<DataModel> ReadData(string fileName)
        {
            var listDataModel = new List<DataModel>();

            using (StreamReader streamReader = new StreamReader(fileName))
            {
                streamReader.ReadLine();

                while(streamReader.Peek() != -1)
                {
                    var line = streamReader.ReadLine();
                    var lineSplitedArray = line.Split(";");

                    if(lineSplitedArray.Length == 4)
                    {
                        string idfattura = lineSplitedArray[0];
                        DateTime dateEmissione = DateTime.Parse(lineSplitedArray[1]);
                        string nomeLotte = lineSplitedArray[2];
                        ESITO esito = (ESITO)Enum.Parse(typeof(ESITO), lineSplitedArray[3]);

                        var lineInList = new DataModel
                        {
                            IDFATTURA = idfattura,
                            DATAEMISSIONE = dateEmissione,
                            NOMELOTTO = nomeLotte,
                            ESITO = esito
                        };

                        listDataModel.Add(lineInList);

                    }
                }
            }

            return listDataModel;

        }
    }
}
