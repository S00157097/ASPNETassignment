using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attempt1
{
    public partial class index : Page
    {
        static string[] nationalities = new string[]
        {
            "Select Nationality", "American", "Armenian", "Australian", "Austrian", "Belgian", "Brazilian", "British", "Bulgarian", "Canadian",
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

                if(Request.Cookies["userDataS00157097"] != null)
                {
                    txtFirstName.Text = Request.Cookies["userDataS00157097"]["FirstName"].ToString();
                    txtLastName.Text = Request.Cookies["userDataS00157097"]["LastName"].ToString();
                    txtEmail.Text = Request.Cookies["userDataS00157097"]["Email"].ToString();
                    lstNationality.SelectedValue = Request.Cookies["userDataS00157097"]["Nationality"];
                }
            }
        }





        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cbxRemember.Checked)
            {
                HttpCookie userData = new HttpCookie("userDataS00157097");
                userData["FirstName"] = txtFirstName.Text;
                userData["LastName"] = txtLastName.Text;
                userData["Email"] = txtEmail.Text;
                userData["Nationality"] = lstNationality.SelectedItem.Text;

                userData.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(userData);
            }

            Response.Redirect("quiz.aspx?q=1");
        }
    }
}