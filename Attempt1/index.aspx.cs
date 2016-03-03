using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attempt1
{
    public partial class index : System.Web.UI.Page
    {
        static string[] nationalities = new string[]
        {
            "American", "Armenian", "Australian", "Austrian", "Belgian", "Brazilian", "British", "Bulgarian", "Canadian",
            "African", "Chinese", "Cuban", "Danish", "Dutch", "Egyptian", "Estonian", "Ethiopian", "Filipino", "Finnish", "French",
            "German", "Greek", "Hungarian", "Indian", "Indonesian", "Iranian", "Iraqi", "Irish", "Italian", "Japanese", "Latvian", "Lithuanian",
            "Mexican", "New Zealander", "Northern Irish", "Norwegian", "Polish", "Portuguese", "Romanian", "Russian", "Scottish", "Serbian",
            "Slovakian", "South African", "Uruguayan", "Welsh"
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lstNationality.DataSource = nationalities;
                lstNationality.DataBind();
            }
        }
    }
}