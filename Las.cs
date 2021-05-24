using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LasHelper.Models;
using LasHelper;
namespace LasHelper
{
    public class Las
    {
        // bool DefaultHeader = false;

        public LasHeader HeaderSection;
        public AsciiLogData ASCIILogDataSection = new AsciiLogData();
        public Las(bool d)
        {
            if (d)
            {
                  HeaderSection = new LasHeader("Default");
             }
            else
            {
                 HeaderSection = new LasHeader("NoDefault");
            }
           
        }
        public int ReadFromFile(string filname)
        { }
            public int WriteToFile(string filname)
        {
             bool hasfinished = false;

            if (HeaderSection.VersionInfo.Count == 0)
                return 0;
            CreateLasFile LASfile = new CreateLasFile(HeaderSection, ASCIILogDataSection);
            if (LASfile.CreateFile(filname) == null)
                return 0;
            else
                return 255;
         }




}
       
   
}

            
            
          
        

   
             

         
        
    

