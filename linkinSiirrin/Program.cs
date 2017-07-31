using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


//
///
namespace linkinSiirrin
{
    /// <summary>
    /// Web site address is given as parameter to this program, which opens it in web browser which is open or in default browser, if none is open.
    /// Firefox, Chrome and Internet Expolrer are supported. In Internet Explorer new window opens, in others new tab.
    /// </summary>
    class Program
    {
     
        static void Main(string[] args)
        {
            Process[] processlist = Process.GetProcesses();

            string browserName = GetOpenBrowserName(processlist);
            if(args.Length>0){
            
                if (browserName != "")
                {
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(browserName+".exe", @args[0]);
                    System.Diagnostics.Process.Start(startInfo);
                }
                else
                    System.Diagnostics.Process.Start(args[0]);
            }
            
            
        }

        private static string GetOpenBrowserName(Process[] list)
        {
            foreach (Process theprocess in list)
            {
                if (theprocess.ProcessName.Equals("chrome") || theprocess.ProcessName.Equals("firefox") || theprocess.ProcessName.Equals("iexplore"))
                {
                    return theprocess.ProcessName;
                }
            }
            
            
            return "";

        }
    }

    
}
