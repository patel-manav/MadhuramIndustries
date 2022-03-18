using MadhuramIndustries.App_Code.BAL;
using MadhuramIndustries.App_Code.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MadhuramIndustries.AdminPanel.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            if (!Page.IsPostBack)
            {

            }
            if (Page.IsPostBack)
            {
                txtUserPassword.Attributes["value"] = txtUserPassword.Text;
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            #region Variable
            UserBAL balUser = new UserBAL();
            #endregion Variable

            #region Validation
            if (txtUserName.Text == "")
            {
                lblUserName.Visible = true;
                lblUserPassword.Visible = false;
                lblPasswordIncorrect.Visible = false;
                return;
            }
            if (txtUserPassword.Text == "")
            {
                lblUserName.Visible = false;
                lblUserPassword.Visible = true;
                lblPasswordIncorrect.Visible = false;
                return;
            }
            #endregion Validation

            #region GatherData
            String UserName = txtUserName.Text;
            String UserPassword = txtUserPassword.Text;
            #endregion GatherData

            #region FetchData
            DataTable dt = balUser.UserSignIn(UserName, UserPassword);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (dt.Rows[0][1].ToString() == txtUserName.Text && dt.Rows[0][3].ToString() == txtUserPassword.Text)
                {
                    //UserID
                    Session["UserID"] = dt.Rows[0][0].ToString();

                    //UserName
                    Session["UserName"] = dt.Rows[0][1].ToString();

                    //UserDisplayName
                    Session["UserDisplayName"] = dt.Rows[0][2].ToString();

                    Response.Redirect("../Menu/Menu.aspx");
                    lblUserName.Visible = false;
                    lblUserPassword.Visible = false;
                }
                else
                {
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "fun_login_check()", true);
                    txtUserName.Text = "";
                    txtUserPassword.Text = "";
                    lblPasswordIncorrect.Visible = true;
                    lblUserPassword.Visible = false;
                    lblUserName.Visible = false;
                    txtUserPassword.Attributes["value"] = "";
                    Session.RemoveAll();
                }
            }
            else
            {
                String msg = "Password is Wrong";
                ClientScript.RegisterStartupScript(this.GetType(), "", "alert('" + msg + "');", true);
                txtUserPassword.Attributes["value"] = "";
                txtUserName.Text = "";
                txtUserPassword.Text = "";
                lblPasswordIncorrect.Visible = true;
                lblUserPassword.Visible = false;
                lblUserName.Visible = false;
                Session.RemoveAll();
            }
            #endregion FetchData
        }
    }
}