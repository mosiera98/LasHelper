using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasHelper.Models
{
    public class CreateAsciiFile
    {
        
        private readonly string DefaultTab = "    ";
        private readonly string OneTab = "\t";
        private readonly string Divider = "-";

        private List<string> _header { get; set; }
        private List<AsciiLogData> _asciiLogData { get; set; }

        private StringBuilder _stringBuilder { get; set; } = new StringBuilder();


        public CreateAsciiFile(List<string> header, List<AsciiLogData> asciiLogDataList)
        {
            _header = header;
            _asciiLogData = asciiLogDataList;
        }


        public ResultMethod CreateFile(string savePath)
        {
            try
            {              

                //  about Ascii Data 
                _stringBuilder.Append(string.Join(DefaultTab, _header) + Environment.NewLine);

                for (int i = 0; i < (string.Join(DefaultTab, _header)).Length+10; i++)
                {
                    _stringBuilder.Append(Divider);
                }
                _stringBuilder.Append(Environment.NewLine);

                foreach (var item in _asciiLogData)
                {
                    _stringBuilder.Append(string.Join(DefaultTab, item.Data) + Environment.NewLine);
                }


                //  Save _stringBuilder to file
                System.IO.File.WriteAllText(savePath, _stringBuilder.ToString());

            }
            catch (Exception ex)
            {
                return new ResultMethod()
                {
                    Exception = ex,
                    Message = ex.Message,
                };
            }


            return null;
        }


    }
}
