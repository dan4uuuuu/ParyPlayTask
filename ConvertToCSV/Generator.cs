
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToCSV
{
    public class Generator : IGenerator<Person>
    {
        public Generator()
        {

        }

        public Result GenerateFakeData(int rowsCount)
        {
            var data = new Result();
            PropertyInfo[] propertyInfos;
            propertyInfos = typeof(Person).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var item in propertyInfos)
            {
                data.Headers.Add(item.Name);
            }

            for (int i = 0; i < rowsCount; i++)
            {
                data.Items.Add(new Person()
                {
                    FirstName = i.ToString() + " FirstName",
                    LastName = i.ToString() + " Lastname",
                });
            }
            
            return data;
        }

        public string GenerateCSVList(IList<Person> list, char separator)
        {
            string csv = "";
            foreach (var item in list)
            {
                csv += item.FirstName + "," + item.LastName + separator + "\n";
            }
            var result = csv.Remove(csv.Length - 2, 1).TrimEnd('\r', '\n'); ;
            return result;
        }
    }
}
