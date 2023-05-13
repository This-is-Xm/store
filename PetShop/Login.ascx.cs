using PetShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ThreeClass
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       
        }

        CustomerService customerService = new CustomerService();
        protected void Button1_Click(object sender, EventArgs e)
        {
            int customerID = customerService.CheckLogin(UserName.Text, Password.Text);
            if (customerID!=0)
            {
                if (UserName.Text == "admin")
                {
                    Response.Redirect("~Admin/Default.aspx");
                }
                else
                {Response.Write("<script>alert('登录成功')</script>"); }
                
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误')</script>");
            }
        }
    }
}