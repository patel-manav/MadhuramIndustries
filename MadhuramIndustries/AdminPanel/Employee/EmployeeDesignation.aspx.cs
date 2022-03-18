using System;
using MadhuramIndustries.App_Code.BAL;
using MadhuramIndustries.App_Code.ENT;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MadhuramIndustries.App_Code;

namespace MadhuramIndustries.AdminPanel.Employee
{
    public partial class EmployeeDesignation : System.Web.UI.Page
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
            CommonFillMethods.UserStatus(ddlEmployeeDesignationStatus);
        }
        #endregion FillDropDownList

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            EmployeeDesignationBAL balEmployeeDesignation = new EmployeeDesignationBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balEmployeeDesignation.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvEmployeeDesignation.DataSource = dt;
                gvEmployeeDesignation.DataBind();
            }
            #endregion Bind Data

        }

        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            EmployeeDesignationENT entEmployeeDesignation = new EmployeeDesignationENT();
            EmployeeDesignationBAL balEmployeeDesignation = new EmployeeDesignationBAL();
            #endregion Variable

            #region Validation
            if (txtEmployeeDesignationName.Text.Trim() == "")
            {
                ClearValidation();
                lblEmployeeDesignationName.Visible = true;
                return;
            }
            #endregion Validation

            #region Gather Data
            if (hfEmployeeDesignationID.Value != "")
            {
                entEmployeeDesignation.EmployeeDesignationID = Convert.ToInt32(hfEmployeeDesignationID.Value.Trim());
            }

            if (txtEmployeeDesignationName.Text.Trim() != "")
            {
                entEmployeeDesignation.EmployeeDesignationName = txtEmployeeDesignationName.Text.Trim();
            }

            entEmployeeDesignation.ModifyDate = DateTime.Now;
            entEmployeeDesignation.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entEmployeeDesignation.CreateDate = DateTime.Now;
            entEmployeeDesignation.CreateBy = Convert.ToInt32(Session["UserID"]);
            entEmployeeDesignation.FlagDelete = Convert.ToBoolean(ddlEmployeeDesignationStatus.SelectedValue.Trim());

            #endregion Gather Data

            #region Insert/Update
            if (hfEmployeeDesignationID.Value != "")
            {
                if (balEmployeeDesignation.Update(entEmployeeDesignation))
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
                if (balEmployeeDesignation.Insert(entEmployeeDesignation))
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
        
        #region Clear Control
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl();
            ClearValidation();
        }

        #region Clear Control
        private void ClearControl()
        {
            FillGridView();
            hfEmployeeDesignationID.Value = null;
            txtEmployeeDesignationName.Text = "";
            ddlEmployeeDesignationStatus.SelectedIndex = 0;
        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblEmployeeDesignationName.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Control

        #region Delete/Update
        protected void gvEmployeeDesignation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            EmployeeDesignationBAL balEmployeeDesignation = new EmployeeDesignationBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete Record
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balEmployeeDesignation.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    ClearControl();
                }
                else
                {

                }
            }
            #endregion Delete Record

            #region Call FillDataByPK
            else if (e.CommandName == "EditRecord" && e.CommandArgument != null)
            {
                FillDataByPK(Convert.ToInt32(e.CommandArgument));
            }
            #endregion Call FillDataByPK
        }
        #endregion Delete/Update

        #region FillDataByPK
        private void FillDataByPK(SqlInt32 EmployeeDesignationID)
        {
            #region Variable
            EmployeeDesignationBAL balEmployeeDesignation = new EmployeeDesignationBAL();
            EmployeeDesignationENT entEmployeeDesignation = balEmployeeDesignation.SelectPK(EmployeeDesignationID);
            #endregion Variable

            #region Fill Data
            if (!entEmployeeDesignation.EmployeeDesignationID.IsNull)
            {
                hfEmployeeDesignationID.Value = entEmployeeDesignation.EmployeeDesignationID.Value.ToString();
            }
            if (!entEmployeeDesignation.EmployeeDesignationName.IsNull)
            {
                txtEmployeeDesignationName.Text = entEmployeeDesignation.EmployeeDesignationName.Value;
            }
            if (!entEmployeeDesignation.FlagDelete.IsNull)
            {
                ddlEmployeeDesignationStatus.SelectedValue = entEmployeeDesignation.FlagDelete.ToString().Trim();
            }
            #endregion Fill Data
        }
        #endregion FillDataByPK

        #region PageIndex Change
        protected void gvEmployeeDesignation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeDesignation.PageIndex = e.NewPageIndex;
            FillGridView();
            gvEmployeeDesignation.DataBind();
        }
        #endregion PageIndex Change
    }
}