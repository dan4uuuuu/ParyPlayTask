
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConvertToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new Generator();
            var data = generator.GenerateFakeData(4);
            char separator = ',';
            var CSV = generator.GenerateCSVList(data.Items, separator);
            var filePath = @"\test.csv";
            WriteTofile(CSV, data.Headers, filePath);
        }

        private static void WriteTofile(string CSV, List<string> headers, string filePath)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter outputFile = new StreamWriter(desktop + filePath))
            {
                var data = CSV.Split(
                                new[] { "\r\n", "\r", "\n" },
                                StringSplitOptions.None
                            );
                var header = headers.ToArray();

                for (int i = 0; i < header.Length; i++)
                {
                    outputFile.Write(header[i]);
                    if (i < header.Length - 1)
                    {
                        outputFile.Write(",");
                    }
                }

                outputFile.WriteLine();
                for (int i = 0; i < data.Length; i++)
                { 
                    outputFile.WriteLine(data[i]);
                }
                outputFile.Flush();
                outputFile.Close();
            }
        }
    }
}
