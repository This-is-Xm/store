using PetShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThreeClass;


namespace PetShop
{
    public partial class newuser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            CustomerService customerSrv = new CustomerService();
            if(Page.IsValid)
            {
                if(customerSrv.IsNameExist(txtName.Text.Trim()))
                {
                    lblMsg.Text = "用户名已存在";
                }
                else
                {
                    customerSrv.Insert(txtName.Text.Trim(), txtPwd.Text.Trim(), txtEmail.Text.Trim());
                    Response.Redirect("loginp.aspx?name=" + txtName.Text);
                }
            }

        }
    }
}