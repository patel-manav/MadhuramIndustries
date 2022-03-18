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
    public partial class EmployeePenalty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                txtEmployeePenaltyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FillGridView();
                FillDropDownList();
            }
        }

        #region FillDropDownList
        private void FillDropDownList()
        {
            CommonFillMethods.FillDropDownListEmployee(ddlEmployee);
        }
        #endregion FillDropDownList

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            EmployeePenaltyBAL balMenu = new EmployeePenaltyBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balMenu.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvEmployeePenalty.DataSource = dt;
                gvEmployeePenalty.DataBind();
            }
            #endregion Bind Data

        }

        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            EmployeePenaltyENT entEmployeePenalty = new EmployeePenaltyENT();
            EmployeePenaltyBAL balEmployeePenalty = new EmployeePenaltyBAL();
            #endregion Variable

            #region Validation
            if (txtEmployeePenaltyDate.Text.Trim() == "")
            {
                ClearValidation();
                lblEmployeePenaltyDate.Visible = true;
                return;
            }
            if (ddlEmployee.SelectedIndex == 0)
            {
                ClearValidation();
                lblEmployee.Visible = true;
                return;
            }
            if (txtEmployeePenaltyAmount.Text.Trim() == "")
            {
                ClearValidation();
                lblEmployeePenaltyAmount.Visible = true;
                return;
            }

            #endregion Validation

            #region Gather Data
            if (hfEmployeePenaltyID.Value != "")
            {
                entEmployeePenalty.EmployeePenaltyID = Convert.ToInt32(hfEmployeePenaltyID.Value.Trim());
            }

            if (txtEmployeePenaltyDate.Text.Trim() != "")
            {
                entEmployeePenalty.EmployeePenaltyDate = Convert.ToDateTime(txtEmployeePenaltyDate.Text.Trim());
            }

            if (ddlEmployee.SelectedIndex != 0)
            {
                entEmployeePenalty.EmployeeID = Convert.ToInt32(ddlEmployee.SelectedValue.ToString());
            }

            if (txtEmployeePenaltyAmount.Text.Trim() != "")
            {
                entEmployeePenalty.EmployeePenaltyAmount = Convert.ToInt32(txtEmployeePenaltyAmount.Text.Trim());
            }

            if (txtEmployeePenaltyRemark.Text.Trim() != "")
            {
                entEmployeePenalty.EmployeePenaltyRemark = txtEmployeePenaltyRemark.Text.Trim();
            }

            entEmployeePenalty.ModifyDate = DateTime.Now;
            entEmployeePenalty.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entEmployeePenalty.CreateDate = DateTime.Now;
            entEmployeePenalty.CreateBy = Convert.ToInt32(Session["UserID"]);

            #endregion Gather Data

            #region Insert/Update
            if (hfEmployeePenaltyID.Value != "")
            {
                if (balEmployeePenalty.Update(entEmployeePenalty))
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
                if (balEmployeePenalty.Insert(entEmployeePenalty))
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
            hfEmployeePenaltyID.Value = null;
            txtEmployeePenaltyDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ddlEmployee.SelectedIndex = 0;
            txtEmployeePenaltyAmount.Text = "";
            txtEmployeePenaltyRemark.Text = "";
        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblEmployeePenaltyDate.Visible = false;
            lblEmployee.Visible = false;
            lblEmployeePenaltyAmount.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Control

        #region Delete/Update
        protected void gvEmployeePenalty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            EmployeePenaltyBAL balEmployeePenalty = new EmployeePenaltyBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete Record
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balEmployeePenalty.Delete(Convert.ToInt32(e.CommandArgument)))
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
        private void FillDataByPK(SqlInt32 EmployeePenaltyID)
        {
            #region Variable
            EmployeePenaltyBAL balEmployeePenalty = new EmployeePenaltyBAL();
            EmployeePenaltyENT entEmployeePenalty = balEmployeePenalty.SelectPK(EmployeePenaltyID);
            #endregion Variable

            #region Fill Data
            if (!entEmployeePenalty.EmployeePenaltyID.IsNull)
            {
                hfEmployeePenaltyID.Value = entEmployeePenalty.EmployeePenaltyID.Value.ToString();
            }
            if (!entEmployeePenalty.EmployeePenaltyDate.IsNull)
            {
                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                DateTime dateTime = DateTime.Parse(entEmployeePenalty.EmployeePenaltyDate.ToString().Trim());
                string date = string.Format("{0:dd-MM-yyy}", dateTime);
                txtEmployeePenaltyDate.Text = Convert.ToDateTime(date).Date.ToString("yyyy-MM-dd");
            }
            if (!entEmployeePenalty.EmployeeID.IsNull)
            {
                ddlEmployee.SelectedValue = entEmployeePenalty.EmployeeID.Value.ToString();
            }
            if (!entEmployeePenalty.EmployeePenaltyAmount.IsNull)
            {
                txtEmployeePenaltyAmount.Text = entEmployeePenalty.EmployeePenaltyAmount.Value.ToString();
            }
            if(!entEmployeePenalty.EmployeePenaltyRemark.IsNull)
            {
                txtEmployeePenaltyRemark.Text = entEmployeePenalty.EmployeePenaltyRemark.ToString();
            }
            #endregion Fill Data

        }
        #endregion FillDataByPK

        #region PageIndex Change
        protected void gvEmployeePenalty_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeePenalty.PageIndex = e.NewPageIndex;
            FillGridView();
            gvEmployeePenalty.DataBind();
        }
        #endregion PageIndex Change
    }
}