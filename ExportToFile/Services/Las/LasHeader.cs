using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportToFile.Services.Las
{
    //NAME  .UNITS  DATA :DESCRIPTION
    //NAME is the shorthand name used in the rest of the file for that attribute. It cannot contain internal spaces, dots, or colons.
    //UNITS are the units(blank if dimensionless) for that attribute.Although there can be space just before the dot, the units must come right after the dot.
    //DATA contains the value for the attribute. This value must be preceded by at least one space, and cannot contain a colon.
    //DESCRIPTION is a short description of the attribute. The total line length cannot exceed 256 characters, so that places an implicit restriction on the length of the description.

    public class LasHeader
    {
       
        public LasLine Vers { get; set; } = new LasLine() { Name = "VERS", Unit = "", Value = DefaultValue.ExportVersionOfLas, Information = "CWLS LOG ASCII STANDARD - VERSION " + DefaultValue.ExportVersionOfLas };
        public LasLine Wrap { get; set; } = new LasLine() { Name = "WRAP", Unit = "", Value = "NO", Information = "ONE LINE PER DEPTH STEP" };
        public LasLine Strt { get; set; } = new LasLine() { Name = "STRT", Unit = "", Value = "", Information = "START DEPTH" };
        public LasLine Stop { get; set; } = new LasLine() { Name = "STOP", Unit = "", Value = "", Information = "STOP DEPTH" };
        public LasLine Step { get; set; } = new LasLine() { Name = "STEP", Unit = "M", Value = "0.010", Information = "STEP LENGTH" };
        public LasLine Null { get; set; } = new LasLine() { Name = "NULL", Unit = "", Value = DefaultValue.NullValue, Information = "NO VALUE" };
        public LasLine Comp { get; set; } = new LasLine() { Name = "COMP", Unit = "", Value = "", Information = "COMPANY" };
        public LasLine Well { get; set; } = new LasLine() { Name = "WELL", Unit = "", Value = "", Information = "WELL" };
        public LasLine Fld { get; set; } = new LasLine() { Name = "FLD", Unit = "", Value = "", Information = "FIELD" };
        public LasLine Loc { get; set; } = new LasLine() { Name = "LOC", Unit = "", Value = "", Information = "LOCATION" };
        public LasLine Stat { get; set; } = new LasLine() { Name = "STAT", Unit = "", Value = "", Information = "STATE" };
        public LasLine Coun { get; set; } = new LasLine() { Name = "COUN", Unit = "", Value = "", Information = "COUNTY" };
        public LasLine Srvc { get; set; } = new LasLine() { Name = "SRVC", Unit = "", Value = "", Information = "SERVICE COMPANY" };
        public LasLine Date { get; set; } = new LasLine() { Name = "DATE", Unit = "", Value = "", Information = "LOGDATE" };

        public List<LasLine> CurveInformation { get; set; } = new List<LasLine>();
        public List<LasLine> ParameterInformation { get; set; } = new List<LasLine>();
        public List<LasLine> OtherInformation { get; set; } = new List<LasLine>();


    }
}
