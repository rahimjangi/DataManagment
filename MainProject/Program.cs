using System.IO;
using System;
using DataManager.ClassLib;
using System.Linq;
using DataManager.Models;
using DataManager.Helper;

namespace MainProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            var fileName = Path.Combine(currentDirectory, "data.csv");

            var readCvsFiles = new ReadCsvFiles();
            var allData = readCvsFiles.ReadData(fileName);
            var finalData = allData.Where(d => d.ESITO == ESITO.NS).ToList();

            foreach (var data in finalData)
            {
                var splitedData = data.IDFATTURA.Substring(0, data.IDFATTURA.IndexOf("/")) + "_" +
                    data.IDFATTURA.Substring(data.IDFATTURA.LastIndexOf("/") + 1);
                Console.WriteLine(splitedData);
            }
            Convertor c = new Convertor();
            File.WriteAllText(Path.Combine(currentDirectory, "newData.xml"), c.ListToXML(allData));

        }
    }
}
