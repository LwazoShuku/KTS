using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace KTS.Models
{
    public class PayPalLogger
    {
        public static string logDirectoryPath = Environment.CurrentDirectory;

        public static void log(String messages)
        {
            try {

                StreamWriter rt = new StreamWriter(logDirectoryPath + "//PayPalError.Log", true);
                rt.WriteLine( "{0}---{1}>", DateTime.Now.ToString("yy/mm/dd hh/mm/ss"), messages);
            }

            catch( Exception )
            {
                throw;
             

            }

        }


    }
}