using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PetShop
{
    public partial class loginp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["name"] != null)
            { string name = Request.QueryString["name"];
            TextBox textBox = Login.FindControl("UserName") as TextBox;
            textBox.Text = name;}
            
        }
    }
    }
