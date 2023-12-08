using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Ev_WCF_CApp_TFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //// 1st Requirement
            //Ev_WCF_SLib_TFile.CL_TextFile CLTFile = new Ev_WCF_SLib_TFile.CL_TextFile();
            //CLTFile.Get_LongestPeriod(CLTFile.Get_TFData());

            // 2nd Requirement
            using (ServiceHost SHost = new ServiceHost(typeof(Ev_WCF_SLib_TFile.CL_TextFile)))
            {
                SHost.Open();
                Console.WriteLine("The service has started");
                Console.Read();
            }
        }
    }
}
