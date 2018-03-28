using System.Collections.Generic;

namespace ConvertToCSV
{
    public class Result
    {
        public Result()
        {
            this.Headers = new List<string>();
            this.Items = new List<Person>();
        }
        public List<string> Headers { get; set; }

        public IList<Person> Items { get; set; }
    }
}