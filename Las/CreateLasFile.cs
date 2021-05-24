using LasHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasHelper
{
    public class CreateLasFile
    {
        private readonly string FirstDot = ".";
        private readonly string FirstDot1 = ".";
        private readonly string FirstSpace = "\t\t";
        private readonly string FirstSpace1 = "   ";
        private readonly string colon = "\t:\t";
        private readonly string DefaultTab = "    ";
        private readonly string OneTab = "\t";
        private readonly string Divider = "-";
        //public int Count { get; }
        private LasHeader _headerInformation { get; set; }
        private AsciiLogData _asciiLogData { get; set; }
        
        private StringBuilder _stringBuilder { get; set; } = new StringBuilder();


        public CreateLasFile(LasHeader headerInformation, AsciiLogData asciiLogDataList)
        {
            _headerInformation = headerInformation;
            _asciiLogData = asciiLogDataList;
        }


        public ResultMethod CreateFile(string savePath)
        {
            try
            {
                //  about version of file
                _stringBuilder.Append("~VERSION INFORMATION" + Environment.NewLine);

                foreach (var o in _headerInformation.VersionInfo)
                {
                    for (int i = 0; i < o.Length; i++)
                        _stringBuilder.Append(o[i].Name.ToString() + FirstDot + o[i].Unit.ToString() + FirstSpace + o[i].Data.ToString() + colon + o[i].Description.ToString() + Environment.NewLine);
                };
                // _stringBuilder.Append(_headerInformation.VersionInfoVers.Name + FirstDot + _headerInformation.Vers.Unit + FirstSpace + _headerInformation.Vers.Value + colon + _headerInformation.Vers.Information + Environment.NewLine);
                // _stringBuilder.Append(_headerInformation.Wrap.Name + FirstDot + _headerInformation.Wrap.Unit + FirstSpace + _headerInformation.Wrap.Value + colon + _headerInformation.Wrap.Information + Environment.NewLine);


                //  about Well Information 
                _stringBuilder.Append( Environment.NewLine);
                _stringBuilder.Append("~WELL INFORMATION" + Environment.NewLine);
                _stringBuilder.Append("#MNEM" + FirstDot + "UNIT" + FirstSpace + "DATA TYPE" + colon + "INFORMATION" + Environment.NewLine);
                _stringBuilder.Append("#");

                for (int i = 0; i < ("#MNEM" + FirstDot + "UNIT" + FirstSpace + "DATA TYPE" + colon + "INFORMATION").Length ; i++)
                {
                    _stringBuilder.Append(Divider);
                }
               _stringBuilder.Append(Environment.NewLine);
                foreach (var o in _headerInformation.WellInfo)
                {
                    for (int i = 0; i < o.Length; i++)
                        _stringBuilder.Append(o[i].Name.ToString() + FirstDot + o[i].Unit.ToString() + FirstSpace + o[i].Data.ToString() + colon + o[i].Description.ToString() + Environment.NewLine);
                };
                /*
                                _stringBuilder.Append(_headerInformation.Strt.Name + FirstDot1 + _headerInformation.Strt.Unit + FirstSpace1 + _headerInformation.Strt.Value + colon + _headerInformation.Strt.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Stop.Name + FirstDot1 + _headerInformation.Stop.Unit + FirstSpace1 + _headerInformation.Stop.Value + colon + _headerInformation.Stop.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Step.Name + FirstDot1 + _headerInformation.Step.Unit + FirstSpace1 + _headerInformation.Step.Value + colon + _headerInformation.Step.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Null.Name + FirstDot + _headerInformation.Null.Unit + FirstSpace + _headerInformation.Null.Value + colon + _headerInformation.Null.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Comp.Name + FirstDot + _headerInformation.Comp.Unit + FirstSpace + _headerInformation.Comp.Value + colon + _headerInformation.Comp.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Well.Name + FirstDot + _headerInformation.Well.Unit + FirstSpace + _headerInformation.Well.Value + colon + _headerInformation.Well.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Fld.Name + FirstDot + _headerInformation.Fld.Unit + FirstSpace + _headerInformation.Fld.Value + colon + _headerInformation.Fld.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Loc.Name + FirstDot + _headerInformation.Loc.Unit + FirstSpace + _headerInformation.Loc.Value + colon + _headerInformation.Loc.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Stat.Name + FirstDot + _headerInformation.Stat.Unit + FirstSpace + _headerInformation.Stat.Value + colon + _headerInformation.Stat.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Coun.Name + FirstDot + _headerInformation.Coun.Unit + FirstSpace + _headerInformation.Coun.Value + colon + _headerInformation.Coun.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Srvc.Name + FirstDot + _headerInformation.Srvc.Unit + FirstSpace + _headerInformation.Srvc.Value + colon + _headerInformation.Srvc.Information + Environment.NewLine);
                                _stringBuilder.Append(_headerInformation.Date.Name + FirstDot + _headerInformation.Date.Unit + FirstSpace + _headerInformation.Date.Value + colon + _headerInformation.Date.Information + Environment.NewLine);
                */
                //  about Curve Information 
                _stringBuilder.Append("~CURVE INFORMATION" + Environment.NewLine);
                _stringBuilder.Append("#MNEM" + FirstDot + "UNIT" + FirstSpace + "DATA" + colon + "Description" + Environment.NewLine);
                _stringBuilder.Append("#");

                for (int i = 0; i < ("#MNEM" + FirstDot + "UNIT" + FirstSpace + "DATA" + colon + "Description").Length ; i++)
                {
                    _stringBuilder.Append(Divider);
                }            
                _stringBuilder.Append(Environment.NewLine);
                foreach (var o in _headerInformation.CurveInfo)
                {
                    for (int i = 0; i < o.Length; i++)
                        _stringBuilder.Append(o[i].Name.ToString() + FirstDot + o[i].Unit.ToString() + FirstSpace + o[i].Data.ToString() + colon + o[i].Description.ToString() + Environment.NewLine);
                };
                /*
                foreach (var item in _headerInformation.CurveInfo)
                {
                   // _stringBuilder.Append(item.Name + FirstDot + item.Unit + FirstSpace + item.Value + colon + item.Information + Environment.NewLine);
                }
                */


                //  about Parameter Information 
                if (_headerInformation.ParameterInfo != null && _headerInformation.ParameterInfo.Count > 0)
                {
                    _stringBuilder.Append("~PARAMETER INFORMATION" + Environment.NewLine);
                    _stringBuilder.Append("#MNEM" + FirstDot + "UNIT" + FirstSpace + "VALUE" + colon + "DESCRIPTION" + Environment.NewLine);
                    for (int i = 0; i < ("#MNEM" + FirstDot + "UNIT" + FirstSpace + "VALUE" + colon + "DESCRIPTION").Length ; i++)
                    {
                        _stringBuilder.Append(Divider); 
                    }
                    _stringBuilder.Append(Environment.NewLine);

                    foreach (var o in _headerInformation.ParameterInfo)
                    {
                        for (int i = 0; i < o.Length; i++)
                            _stringBuilder.Append(o[i].Name.ToString() + FirstDot + o[i].Unit.ToString() + FirstSpace + o[i].Data.ToString() + colon + o[i].Description.ToString() + Environment.NewLine);
                    };
                }

                //  about Ascii Data 
                _stringBuilder.Append("~A"+ DefaultTab);
                foreach (var o in _headerInformation.CurveInfo)
                {
                    for (int i = 0; i < o.Length; i++)
                        _stringBuilder.Append(o[i].Name.ToString() + FirstSpace );
                };
                _stringBuilder.Append(Environment.NewLine);

                foreach (var o in _asciiLogData.Data)
                {
                    _stringBuilder.Append(DefaultTab + OneTab);
                    for (int i = 0; i < o.Length; i++)
                        _stringBuilder.Append(o[i].ToString());
                    _stringBuilder.Append(Environment.NewLine);
                };


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
