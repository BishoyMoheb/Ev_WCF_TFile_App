using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.ServiceModel;

namespace Ev_WCF_WApp_TFile
{
    public partial class WForm_TFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void B_LoadData_Click(object sender, EventArgs e)
        {
            SRef_TextFile.CL_TextFileClient SCLTFile = new SRef_TextFile.CL_TextFileClient();
            if (FUploadControl.HasFile)
            {
                string FPath = Server.MapPath("~/") + FUploadControl.PostedFile.FileName;
                if (File.Exists(FPath))
                    File.Delete(FPath);
                FUploadControl.SaveAs(FPath);
                SRef_TextFile.TFData[] LTFile = new SRef_TextFile.TFData[] { };
                SRef_TextFile.TFData[] LTF_EmpPairs = new SRef_TextFile.TFData[] { };
                LTFile = SCLTFile.Get_TFData_WForms(FPath);
                LTF_EmpPairs = SCLTFile.Get_LongestPeriod(LTFile);
                GridView1.DataSource = LTF_EmpPairs;
                GridView1.DataBind();
            }
        }
    }
}