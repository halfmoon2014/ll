using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace abc
{
    
    [ToolboxData("<{0}:TestCtrl runat=\"server\" />")]
    public class TestCtrl : System.Web.UI.WebControls.WebControl
    {
        public TestCtrl()
        {
        }
        public string Custom
        {
            get
            {
                String s = (String)ViewState["Custom"];
                return ((s == null) ? "Ch" : s);
            }

            set
            {
                ViewState["Custom"] = value;
            }
        }
        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("aa");
        }
    }
}
