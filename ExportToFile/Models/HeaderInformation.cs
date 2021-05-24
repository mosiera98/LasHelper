using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportToFile.Models
{
    public class HeaderInformation
    {
        //NAME  .UNITS  DATA :DESCRIPTION
        //NAME is the shorthand name used in the rest of the file for that attribute. It cannot contain internal spaces, dots, or colons.
        //UNITS are the units(blank if dimensionless) for that attribute.Although there can be space just before the dot, the units must come right after the dot.
        //DATA contains the value for the attribute. This value must be preceded by at least one space, and cannot contain a colon.
        //DESCRIPTION is a short description of the attribute. The total line length cannot exceed 256 characters, so that places an implicit restriction on the length of the description.

        public LineValue Vers { get; set; } = new LineValue() { Name = "VERS", Unit = "", Value = DefaultValue.ExportVersionOfLas, Information = "CWLS LOG ASCII STANDARD - VERSION "+ DefaultValue.ExportVersionOfLas };
        public LineValue Wrap { get; set; } = new LineValue() { Name = "WRAP", Unit = "", Value = "NO", Information = "ONE LINE PER DEPTH STEP" };
        public LineValue Strt { get; set; } = new LineValue() { Name = "STRT", Unit = "", Value = "", Information = "START DEPTH" };
        public LineValue Stop { get; set; } = new LineValue() { Name = "STOP", Unit = "", Value = "", Information = "STOP DEPTH" };
        public LineValue Step { get; set; } = new LineValue() { Name = "STEP", Unit = "M", Value = "0.010", Information = "STEP LENGTH" };
        public LineValue Null { get; set; } = new LineValue() { Name = "NULL", Unit = "", Value = DefaultValue.NullValue, Information = "NO VALUE" };
        public LineValue Comp { get; set; } = new LineValue() { Name = "COMP", Unit = "", Value = "", Information = "COMPANY" };
        public LineValue Well { get; set; } = new LineValue() { Name = "WELL", Unit = "", Value = "", Information = "WELL" };
        public LineValue Fld { get; set; } = new LineValue() { Name = "FLD", Unit = "", Value = "", Information = "FIELD" };
        public LineValue Loc { get; set; } = new LineValue() { Name = "LOC", Unit = "", Value = "", Information = "LOCATION" };
        public LineValue Stat { get; set; } = new LineValue() { Name = "STAT", Unit = "", Value = "", Information = "STATE" };
        public LineValue Coun { get; set; } = new LineValue() { Name = "COUN", Unit = "", Value = "", Information = "COUNTY" };
        public LineValue Srvc { get; set; } = new LineValue() { Name = "SRVC", Unit = "", Value = "", Information = "SERVICE COMPANY" };
        public LineValue Date { get; set; } = new LineValue() { Name = "DATE", Unit = "", Value = "", Information = "LOGDATE" };

        public List<LineValue> CurveInformation { get; set; } = new List<LineValue>();
        public List<LineValue> ParameterInformation { get; set; } = new List<LineValue>();
        public List<LineValue> OtherInformation { get; set; } = new List<LineValue>();
        

    }
}
