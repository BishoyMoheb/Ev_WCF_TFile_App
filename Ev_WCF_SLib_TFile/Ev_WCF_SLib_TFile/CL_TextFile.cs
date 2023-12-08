using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace Ev_WCF_SLib_TFile
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CL_TextFile" in both code and config file together.
    public class CL_TextFile : ICL_TextFile
    {
        public List<TFData> Get_LongestPeriod(List<TFData> LTFData)
        {
            List<string> LS_PID = LTFData.Select(l => l.ProjectID.ToString()).Distinct().ToList();
            TFData TFDContent = new TFData();
            List<TFData> LTFD_EmpPairs = new List<TFData>();
            int Pair_Counter = 0;
            for (int i = 0; i < LTFData.Count; i++)
            {
                foreach (string item in LS_PID)
                {
                    if (item == LTFData[i].ProjectID.ToString())
                    {
                        if (i + 1 == LTFData.Count)
                            break;
                        if (LTFData[i + 1].DateFrom < LTFData[i].DateTo
                            && LTFData[i + 1].ProjectID.ToString() == item)
                        {
                            LTFD_EmpPairs.Add(LTFData[i]);
                            LTFD_EmpPairs.Add(LTFData[i + 1]);
                            Pair_Counter++;
                        }
                    }
                }
            }
            return LTFD_EmpPairs;
        }

        public List<TFData> Get_TFData()
        {
            Console.WriteLine("Enter the file ");
            var FLines = System.IO.File.ReadAllLines(@"H:\External HD\Bishoy Contents\Developer Interview\Evolvice Egypt\EvTFile.txt").Skip(1);
            //var FLines = System.IO.File.ReadAllLines(Console.ReadLine()).Skip(1);
            List<TFData> LTFData = new List<TFData>();
            foreach (string StrInLines in FLines)
            {
                TFData TFDContent = new TFData();
                string[] Str_SplittedArray = StrInLines.Split(',');
                TFDContent.EmpID = int.Parse(Str_SplittedArray[0]);
                TFDContent.ProjectID = int.Parse(Str_SplittedArray[1]);
                TFDContent.DateFrom = DateTime.Parse(Str_SplittedArray[2]);
                string NullString = Str_SplittedArray[3].ToLower();
                if (NullString == "\tnull")
                    TFDContent.DateTo = DateTime.Now;
                else
                    TFDContent.DateTo = DateTime.Parse(Str_SplittedArray[3]);
                LTFData.Add(TFDContent);
            }
            return LTFData;
        }

        public List<TFData> Get_TFData_WForms(string FUpLoad)
        {
            string FName = Path.GetFileName(FUpLoad);
            string FPath = FUpLoad;
            var FLines = System.IO.File.ReadAllLines(FPath).Skip(1);
            List<TFData> LTFData = new List<TFData>();
            foreach (string StrInLines in FLines)
            {
                TFData TFDContent = new TFData();
                string[] Str_SplittedArray = StrInLines.Split(',');
                TFDContent.EmpID = int.Parse(Str_SplittedArray[0]);
                TFDContent.ProjectID = int.Parse(Str_SplittedArray[1]);
                TFDContent.DateFrom = DateTime.Parse(Str_SplittedArray[2]);
                if (Str_SplittedArray[3].ToLower() == "\tnull")
                    TFDContent.DateTo = DateTime.Now;
                else
                    TFDContent.DateTo = DateTime.Parse(Str_SplittedArray[3]);
                LTFData.Add(TFDContent);
            }
            return LTFData;
        }
    }
}
