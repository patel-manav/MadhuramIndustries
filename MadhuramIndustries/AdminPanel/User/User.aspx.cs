using MadhuramIndustries.App_Code;
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
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                FillDropDownList();
                FillGridView();
            }
        }

        #region FillDropDownList
        private void FillDropDownList()
        {
            CommonFillMethods.UserStatus(ddlUserStatus);
        }
        #endregion FillDropDownList

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            UserBAL balUser = new UserBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balUser.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvUser.DataSource = dt;
                gvUser.DataBind();
            }
            #endregion Bind Data
        }
        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            UserBAL balUser = new UserBAL();
            UserENT entUser = new UserENT();
            #endregion Variable

            #region Validation
            if (txtUserName.Text.Trim() == "")
            {
                ClearValidation();
                lblUserName.Visible = true;
                return;
            }
            else if (txtDisplayName.Text.Trim() == "")
            {
                ClearValidation();
                lblDisplayName.Visible = true;
                return;
            }
            else if (txtPassword.Text.Trim() == "")
            {
                ClearValidation();
                lblPassword.Visible = true;
                return;
            }
            else if (txtPassword.Text.Length <= 5)
            {
                ClearValidation();
                lblPasswordCharacter.Visible = true;
                return;
            }
            else if (txtConfirmPassword.Text.Trim() == "")
            {
                ClearValidation();
                lblConfirmPassword.Visible = true;
                return;
            }
            else if (!txtPassword.Text.Trim().Equals(txtConfirmPassword.Text.Trim()))
            {
                ClearValidation();
                lblPasswordCheck.Visible = true;
                lblConfirmPasswordCheck.Visible = true;
                return;
            }
            #endregion Validation

            #region Gather Data
            if (hfUserID.Value != "")
            {
                entUser.UserID = Convert.ToInt32(hfUserID.Value.Trim());
            }
            if (txtUserName.Text.Trim() != "")
            {
                entUser.UserName = txtUserName.Text.Trim();
            }
            if (txtDisplayName.Text.Trim() != "")
            {
                entUser.UserDisplayName = txtDisplayName.Text.Trim();
            }
            if (txtPassword.Text.Trim() != "")
            {
                entUser.UserPassword = txtPassword.Text.Trim();
            }
            entUser.ModifyDate = DateTime.Now;
            entUser.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entUser.CreateDate = DateTime.Now;
            entUser.CreateBy = Convert.ToInt32(Session["UserID"]);
            entUser.FlagDelete = Convert.ToBoolean(ddlUserStatus.SelectedValue.Trim());
            #endregion Gather Data

            #region Insert/Update
            if (hfUserID.Value != "")
            {
                if (balUser.Update(entUser))
                {
                    ClearControl();
                    ClearValidation();
                }
                else
                {

                }
            }
            else
            {
                if (balUser.Insert(entUser))
                {
                    ClearControl();
                    ClearValidation();
                }
                else
                {

                }
            }
            #endregion Insert/Update
        }
        #endregion Save Click

        #region Clear Button
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
            ClearValidation();
        }

        #region Clear Control
        private void ClearControl()
        {
            FillGridView();
            hfUserID.Value = null;
            txtUserName.Text = "";
            txtDisplayName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            ddlUserStatus.SelectedIndex = 0;
        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblUserName.Visible = false;
            lblDisplayName.Visible = false;
            lblPassword.Visible = false;
            lblPasswordCheck.Visible = false;
            lblPasswordCharacter.Visible = false;
            lblConfirmPassword.Visible = false;
            lblConfirmPasswordCheck.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Button

        #region Delete/Fill For Update
        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            UserBAL balUser = new UserBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balUser.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillGridView();
                    ClearControl();
                }
                else
                {

                }
            }
            #endregion Delete

            #region Call FillDataByPK
            else if (e.CommandName == "EditRecord" && e.CommandArgument != null)
            {
                FillDataByPK(Convert.ToInt32(e.CommandArgument));
            }
            #endregion Call FillDataByPK
        }
        #endregion Delete/Fill For Update

        #region Fill_DataBy_PK
        private void FillDataByPK(SqlInt32 UserID)
        {
            #region Variable
            UserBAL balUser = new UserBAL();
            UserENT entUser = balUser.SelectPK(UserID);
            #endregion Variable

            #region FillDate
            if (!entUser.UserID.IsNull)
            {
                hfUserID.Value = entUser.UserID.Value.ToString();
            }
            if (!entUser.UserName.IsNull)
            {
                txtUserName.Text = entUser.UserName.ToString();
            }
            if (!entUser.UserDisplayName.IsNull)
            {
                txtDisplayName.Text = entUser.UserDisplayName.ToString();
            }
            if (!entUser.UserPassword.IsNull)
            {
                txtPassword.Attributes["value"] = entUser.UserPassword.ToString();
                txtConfirmPassword.Attributes["value"] = entUser.UserPassword.ToString();
            }
            if (!entUser.FlagDelete.IsNull)
            {
                ddlUserStatus.SelectedValue = entUser.FlagDelete.ToString().Trim();
            }
            #endregion FillDate
        }
        #endregion Fill_DataBy_PK

        #region PageIndex Change
        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            FillGridView();
            gvUser.DataBind();
        }
        #endregion PageIndex Change

    }
}