using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Ev_WCF_SLib_TFile
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICL_TextFile" in both code and config file together.
    [ServiceContract]
    public interface ICL_TextFile
    {
        [OperationContract]
        List<TFData> Get_TFData();

        [OperationContract]
        List<TFData> Get_TFData_WForms(string FUpLoad);

        [OperationContract]
        List<TFData> Get_LongestPeriod(List<TFData> LTFData);
    }
}
