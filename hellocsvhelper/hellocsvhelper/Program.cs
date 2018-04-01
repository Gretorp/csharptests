using System.Collections.Generic;
using CsvHelper;
using System.IO;
using System;

namespace hellocsvhelper
{

    class Program
    {
        public static List<string> ReadInCSV(string absolutePath)
        {
            List<string> result = new List<string>();
            string value;
            using (TextReader fileReader = File.OpenText(absolutePath))
            {
                var csv = new CsvReader(fileReader);
                csv.Configuration.HasHeaderRecord = false;
                while (csv.Read())
                {
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        result.Add(value);
                    }
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            string csvpath = "C:\\Users\\Andre\\Documents\\GitHub\\RIU_Studios\\2018.csv";
            List<string> data = new List<string>();
            data = ReadInCSV(csvpath);
            foreach(string s in data)
            {
                Console.WriteLine(s);
            }
            

        }

    }
}
