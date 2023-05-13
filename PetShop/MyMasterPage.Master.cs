using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//母版页，一切从这里开始，其他的页面都是将母版页与子页面结合产生的页面
namespace PetShop
{
    public partial class MyMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //session类似于一个Map，里面可以存放多个键值对，是以key - value进行存放的。key必须是一个字符串，value是一个对象。
            if (Session["CustomerName"] != null)
            {
                LabShow.Text =Session["CustomerName"].ToString()+"，欢迎您！" ;
            }
        }
        protected void LbtnRegister_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)  //用户已登录
            {
                Session.Clear();  //注销当前用户
            }
            //跳转到注册页面中
            Response.Redirect("~/newuser.aspx");
        }
        protected void LbtnLogin_Click(object sender, EventArgs e)
        {
            if (Session["CustomerId"] != null)  //用户已登录
            {
                Session.Clear();  //注销当前用户
            }
            //跳转到登录页面中
            Response.Redirect("~/loginP.aspx");
        }
    }
}