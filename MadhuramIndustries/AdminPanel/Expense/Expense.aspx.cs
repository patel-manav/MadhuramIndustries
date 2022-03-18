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
namespace MadhuramIndustries.AdminPanel.Expense
{
    public partial class Expense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                #region Set Default Value
                txtExpenseDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                #endregion Set Default Value
                FillDropDownList();
                FillGridView();
            }
        }

        #region FillDropDownList
        private void FillDropDownList()
        {
            CommonFillMethods.UserStatus(ddlExpenseStatus);
            CommonFillMethods.FillDropDownListParty(ddlParty);
            CommonFillMethods.FillDropDownListItem(ddlItem);
        }
        #endregion FillDropDownList

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            ExpenseBAL balExpense = new ExpenseBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balExpense.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvExpense.DataSource = dt;
                gvExpense.DataBind();
            }
            #endregion Bind Data
        }
        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            ExpenseBAL balExpense = new ExpenseBAL();
            ExpenseENT entExpense = new ExpenseENT();
            #endregion Variable

            #region Validation
            if (ddlItem.SelectedIndex == 0)
            {
                ClearValidation();
                lblItem.Visible = true;
                return;
            }
            else if (ddlParty.SelectedIndex == 0)
            {
                ClearValidation();
                lblParty.Visible = true;
                return;
            }
            else if (txtItemQuantity.Text.Trim() == "")
            {
                ClearValidation();
                lblItemQuantity.Visible = true;
                return;
            }
            #endregion Validation

            #region Gather Data
            if (hfExpenseID.Value != "")
            {
                entExpense.ExpenseID = Convert.ToInt32(hfExpenseID.Value.Trim());
            }
            if (txtExpenseDate.Text.Trim() != "")
            {
                DateTime dateTime = DateTime.Parse(txtExpenseDate.Text);
                entExpense.ExpenseDate = dateTime;
            }
            if (ddlItem.SelectedIndex != 0)
            {
                entExpense.ItemID = Convert.ToInt32(ddlItem.SelectedValue.ToString());
            }
            if (ddlParty.SelectedIndex != 0)
            {
                entExpense.PartyID = Convert.ToInt32(ddlParty.SelectedValue.ToString());
            }
            if (txtItemQuantity.Text != "")
            {
                entExpense.ItemQuantity = Convert.ToInt32(txtItemQuantity.Text.ToString());
            }
            if (txtExpenseRemark.Text != "")
            {
                entExpense.ExpenseRemark = txtExpenseRemark.Text.Trim();
            }
            //entExpense.ExpenseDate = Convert.ToDateTime(txtExpenseDate.Text);
            entExpense.ModifyDate = DateTime.Now;
            entExpense.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entExpense.CreateDate = DateTime.Now;
            entExpense.CreateBy = Convert.ToInt32(Session["UserID"]);
            entExpense.FlagDelete = Convert.ToBoolean(ddlExpenseStatus.SelectedValue.Trim());
            #endregion Gather Data

            #region Insert/Update
            if (hfExpenseID.Value != "")
            {
                if (balExpense.Update(entExpense))
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
                if (balExpense.Insert(entExpense))
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
            hfExpenseID.Value = null;
            txtExpenseDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ddlItem.SelectedIndex = 0;
            ddlParty.SelectedIndex = 0;
            txtItemQuantity.Text = "";
            txtExpenseRemark.Text = "";
            ddlExpenseStatus.SelectedIndex = 0;
        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblItem.Visible = false;
            lblParty.Visible = false;
            lblItemQuantity.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Button

        #region Delete/Fill For Update
        protected void gvExpense_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            ExpenseBAL balExpense = new ExpenseBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balExpense.Delete(Convert.ToInt32(e.CommandArgument)))
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
            ExpenseBAL balExpense = new ExpenseBAL();
            ExpenseENT entExpense = balExpense.SelectPK(UserID);
            #endregion Variable

            #region FillDate
            if (!entExpense.ExpenseID.IsNull)
            {
                hfExpenseID.Value = entExpense.ExpenseID.Value.ToString();
            }
            if (!entExpense.ExpenseDate.Equals(DBNull.Value))
            {
                //txtCity.Text = entPayment.PaymentDate.ToString();
                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                DateTime dateTime = DateTime.Parse(entExpense.ExpenseDate.ToString().Trim());
                string date = string.Format("{0:dd-MM-yyy}", dateTime);
                txtExpenseDate.Text = Convert.ToDateTime(date).Date.ToString("yyyy-MM-dd");
            }
            if (!entExpense.ItemID.IsNull)
            {
                ddlItem.SelectedValue = entExpense.ItemID.ToString();
            }
            if (!entExpense.PartyID.IsNull)
            {
                ddlParty.SelectedValue = entExpense.PartyID.ToString();
            }
            if (!entExpense.ItemQuantity.IsNull)
            {
                txtItemQuantity.Text = entExpense.ItemQuantity.ToString();
            }
            if (!entExpense.ExpenseRemark.IsNull)
            {
                txtExpenseRemark.Text = entExpense.ExpenseRemark.ToString();
            }
            if (!entExpense.FlagDelete.IsNull)
            {
                ddlExpenseStatus.SelectedValue = entExpense.FlagDelete.ToString().Trim();
            }
            #endregion FillDate
        }
        #endregion Fill_DataBy_PK

        #region PageIndex Change
        protected void gvExpense_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExpense.PageIndex = e.NewPageIndex;
            FillGridView();
            gvExpense.DataBind();
        }
        #endregion PageIndex Change
    }
}