using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportToFile.Models
{
    public class LineValue
    {
        public LineValue()
        {

        }
        public LineValue(string name,string unit,string value,string information)
        {
            Name = name;
            Unit = unit;
            Value = value;
            Information = information;
        }
        public string Name { get; set; }
        public string Unit { get; set; }
        public string Value { get; set; }
        public string Information { get; set; }
        
    }
}
