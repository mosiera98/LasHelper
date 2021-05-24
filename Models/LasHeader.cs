using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LasHelper.Models
{
    //NAME  .UNITS  DATA :DESCRIPTION
    //NAME is the shorthand name used in the rest of the file for that attribute. It cannot contain internal spaces, dots, or colons.
    //UNITS are the units(blank if dimensionless) for that attribute.Although there can be space just before the dot, the units must come right after the dot.
    //DATA contains the Data for the attribute. This Data must be preceded by at least one space, and cannot contain a colon.
    //DESCRIPTION is a short description of the attribute. The total line length cannot exceed 256 characters, so that places an implicit restriction on the length of the description.

    public class LasHeader//:IEnumerable
    {
        /*
       //~Version Section
        public LasLine Vers { get; set; } = new LasLine() { Name = "VERS", Unit = "", Data = DefaultValue.ExportVersionOfLas, Description = "CWLS LOG ASCII STANDARD - VERSION " + DefaultValue.ExportVersionOfLas };
        public LasLine Wrap { get; set; } = new LasLine() { Name = "WRAP", Unit = "", Data = "NO", Description = "ONE LINE PER DEPTH STEP" };
        //~Well Info Section
        public LasLine Strt { get; set; } = new LasLine() { Name = "STRT", Unit = "", Data = "", Description = "START DEPTH" };
        public LasLine Stop { get; set; } = new LasLine() { Name = "STOP", Unit = "", Data = "", Description = "STOP DEPTH" };
        public LasLine Step { get; set; } = new LasLine() { Name = "STEP", Unit = "M", Data = "0.010", Description = "STEP LENGTH" };
        public LasLine Null { get; set; } = new LasLine() { Name = "NULL", Unit = "", Data = DefaultValue.NullValue, Description = "NO Data" };
        public LasLine Comp { get; set; } = new LasLine() { Name = "COMP", Unit = "", Data = "", Description = "COMPANY" };
        public LasLine Well { get; set; } = new LasLine() { Name = "WELL", Unit = "", Data = "", Description = "WELL" };
        public LasLine Fld { get; set; } = new LasLine() { Name = "FLD", Unit = "", Data = "", Description = "FIELD" };
        public LasLine Loc { get; set; } = new LasLine() { Name = "LOC", Unit = "", Data = "", Description = "LOCATION" };
        public LasLine Stat { get; set; } = new LasLine() { Name = "STAT", Unit = "", Data = "", Description = "STATE" };
        public LasLine Coun { get; set; } = new LasLine() { Name = "COUN", Unit = "", Data = "", Description = "COUNTY" };
        public LasLine Srvc { get; set; } = new LasLine() { Name = "SRVC", Unit = "", Data = "", Description = "SERVICE COMPANY" };
        public LasLine Date { get; set; } = new LasLine() { Name = "DATE", Unit = "", Data = "", Description = "LOGDATE" };

    */
        public List<LasLine[]> VersionInfo { get; set; } = new List<LasLine[]>();
        public List<LasLine[]> WellInfo { get; set; } = new List<LasLine[]>();
        //~Cure Info Section
        public List<LasLine[]> CurveInfo { get; set; } = new List<LasLine[]>();
        //~Parameters Info Section
        public List<LasLine[]> ParameterInfo { get; set; } = new List<LasLine[]>();
        //~Other Info Section
        public List<LasLine[]> OtherInfo { get; set; } = new List<LasLine[]>();
        public LasHeader(string s)
        {
            if (s == "Default")
            {
                //~Version Section
                LasLine[] Vers = new LasLine[2];
                Vers[0] = new LasLine() { Name = "VERS", Unit = "", Data = DefaultValue.ExportVersionOfLas, Description = "CWLS LOG ASCII STANDARD - VERSION " + DefaultValue.ExportVersionOfLas };
                Vers[1] = new LasLine() { Name = "WRAP", Unit = "", Data = "NO", Description = "ONE LINE PER DEPTH STEP" };
                //~Well Info Section
                LasLine[] wells = new LasLine[12];
                wells[0] = new LasLine() { Name = "STRT", Unit = "", Data = "", Description = "START DEPTH" };
                wells[1] = new LasLine() { Name = "STOP", Unit = "", Data = "", Description = "STOP DEPTH" };
                wells[2] = new LasLine() { Name = "STEP", Unit = "M", Data = "0.010", Description = "STEP LENGTH" };
                wells[3] = new LasLine() { Name = "NULL", Unit = "", Data = DefaultValue.NullValue, Description = "NO Data" };
                wells[4] = new LasLine() { Name = "COMP", Unit = "", Data = "", Description = "COMPANY" };
                wells[5] = new LasLine() { Name = "WELL", Unit = "", Data = "", Description = "WELL" };
                wells[6] = new LasLine() { Name = "FLD", Unit = "", Data = "", Description = "FIELD" };
                wells[7] = new LasLine() { Name = "LOC", Unit = "", Data = "", Description = "LOCATION" };
                wells[8] = new LasLine() { Name = "STAT", Unit = "", Data = "", Description = "STATE" };
                wells[9] = new LasLine() { Name = "COUN", Unit = "", Data = "", Description = "COUNTY" };
                wells[10] = new LasLine() { Name = "SRVC", Unit = "", Data = "", Description = "SERVICE COMPANY" };
                wells[11] = new LasLine() { Name = "DATE", Unit = "", Data = "", Description = "LOGDATE" };
                VersionInfo.Add(Vers);
                WellInfo.Add(wells);
            }
    }
            //~Version Info Section
           
        
        //~Well Info Section
       


        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return (IEnumerator)GetEnumerator();
        //}

        //public LasHeader GetEnumerator()
        //{
        //   for(int i=0;i<15;i++)
                
        //        ;
        //}
    }
}
