using PetShop.BLL;
using PetShot.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace PetShop.Admin
{
    public partial class CustomerPage : System.Web.UI.Page
    {
        CustomerService customerService = new CustomerService();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //代码重构，选中你要重构的代码，右键选择快速操作和重构，就会在pageload再执行一次，类似于刷新
            if (!IsPostBack)
            {
                GridViewBind();
            }
        }

        private void GridViewBind()
        {
            GridView1.DataSource = customerService.GetCustomer();
            GridView1.DataKeyNames = new string[] { "Customerid"};
            GridView1.DataBind();
        }

        protected void btnReg_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (customerService.IsNameExist(txtName.Text.Trim()))
                {
                    lblMsg.Text = "用户名已存在";
                }
                else
                {
                    customerService.Insert(txtName.Text.Trim(), txtPwd.Text.Trim(), txtEmail.Text.Trim());
                    lblMsg.Text = "用户添加成功";
                    Response.Write("<script language=javascript>window.location.href=window.location.href;</script>");//这句是我自己写的，意思是刷新页面，与代码重构功能一样
                }
            }

        }
        static string UserName;
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UserName= GridView1.Rows[e.NewEditIndex].Cells[2].Text;
            GridView1.EditIndex=e.NewEditIndex;
            GridViewBind();
            LinkButton linkButton=GridView1.Rows[e.NewEditIndex].Cells[0].Controls[0] as LinkButton;
            linkButton.CausesValidation = false;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridViewBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerId = (int)GridView1.DataKeys[e.RowIndex].Value;
            customer.Name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            customer.Password = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            customer.Email = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text;
            if (customerService.IsNameExistByUpdate(UserName,customer.Name))
            {
                if (customerService.IsNameExist(customer.Name))//这里我修改了，原来是txtName.Text.Trim()
                {
                    lblMsg.Text = "用户名已存在";
                }
                else
                {
                    lblMsg.Text = "修改成功";
                    customerService.Update(customer);
                    GridView1.EditIndex = -1;
                    GridViewBind();
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Customer customer = new Customer();
            customer.CustomerId = (int)GridView1.DataKeys[e.RowIndex].Value;
            customerService.Delete(customer.CustomerId);
            GridViewBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { LinkButton linkButton =e.Row.Cells[0].Controls[2] as LinkButton;
                linkButton.Attributes.Add("onclick", "javascript:return confirm('确认删除该行数据吗？')");
            }
            //这段自己改的，解绑了用户id，这样就不会出现"已经被删除的用户仍占有用户id"的情况，也能够实现分页下id的顺序显示
            //缺点在于查询时由于id为实时计算，用户id和用户姓名不对应的情况
            //实际上绑定时用户id不重复确实是正确的（正常情况id都是长得不一样），但是观赏性不好，所以这里做了修改
            if (e.Row.RowIndex != -1)
            {
                int indexID = this.GridView1.PageIndex * this.GridView1.PageSize + e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = indexID.ToString();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridViewBind();
        }

        protected void ButSearch_Click(object sender, EventArgs e)
        {
            string search=TxtSearch.Value.Trim();
            if (string.IsNullOrWhiteSpace(search))
            { return; }
            List<Customer> customer = customerService.GetCustomerByNameOREmail(search);
            GridView1.DataSource = customer;
            GridView1.DataKeyNames = new string[] { "Customerid" };
            GridView1.DataBind();
        }
    }
}