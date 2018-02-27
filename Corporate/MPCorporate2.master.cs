using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Corporate_MPCorporate2 : System.Web.UI.MasterPage
{
    public int intActiveModule = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        intActiveModule = UTLUtilities.CP_ActiveModule;
    }
}
