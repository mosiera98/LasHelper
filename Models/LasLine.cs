using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasHelper.Models
{
    public sealed class LasLine
    {
        //each line has four pieces of information, separated by a dot, space, and colon:

      //  NAME.UNITS DATA :DESCRIPTION
            public LasLine()
            {

            }
            public LasLine(string name, string unit, string value, string information)
            {
                Name = name;
                Unit = unit;
                Data = value;
                Description = information;
            }
            public string Name { get; set; }
            public string Unit { get; set; }
            public string Data { get; set; }
            public string Description { get; set; }

        
    }
}
