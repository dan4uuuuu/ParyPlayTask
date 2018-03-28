using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToCSV
{
    public interface IGenerator<T>
    {
        string GenerateCSVList(IList<T> list, char separator);

        Result GenerateFakeData(int rowsCount);
    }
}
