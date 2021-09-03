using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections;


namespace DataHandling
{
    public class CsvHelper
    {
        public void ImplementCSCDataHandling()
        {
            //initialization
            String importFilePath = @"C:\Users\admin\source\repos\DataHandling\AddressData.csv";
            String exportFilePath = @"C:\Users\admin\source\repos\DataHandling\Export.csv";

            using (var reader = new StreamReader(importFilePath))
            using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses.csv,here are city");
                foreach(AddressData addressData in record)
                {
                    Console.Write(" " + addressData.name);
                    Console.Write(" " + addressData.email);
                    Console.Write(" " + addressData.phone);
                    Console.Write(" " + addressData.country);
                    Console.Write(" " + addressData.city);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\n*******Now reading from csv file and write to csv file*******");

                using(var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer,CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(record);
                }
            }
        }
    }
}
