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

namespace MadhuramIndustries.AdminPanel.Party
{
    public partial class Party : System.Web.UI.Page
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
            CommonFillMethods.UserStatus(ddlPartyStatus);
        }
        #endregion FillDropDownList

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            PartyBAL balParty = new PartyBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balParty.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvParty.DataSource = dt;
                gvParty.DataBind();
            }
            #endregion Bind Data
        }
        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            PartyBAL balParty = new PartyBAL();
            PartyENT entParty = new PartyENT();
            #endregion Variable

            #region Validation
            if (txtPartyName.Text.Trim() == "")
            {
                ClearValidation();
                lblPartyName.Visible = true;
                return;
            }
            else if (txtPartyAddress.Text.Trim() == "")
            {
                ClearValidation();
                lblPartyAddress.Visible = true;
                return;
            }
            else if (txtPartyGSTNumber.Text.Trim() == "")
            {
                ClearValidation();
                lblPartyGSTNumber.Visible = true;
                return;
            }
            else if (txtPartyMobileNumber.Text.Trim() == "")
            {
                ClearValidation();
                lblPartyMobileNumber.Visible = true;
                return;
            }
            else if (txtPartyMobileNumber.Text.Length != 10)
            {
                ClearValidation();
                lblPartyMobileDigit.Visible = true;
                return;
            }
            else if (txtPartyBankName.Text.Trim() == "")
            {
                ClearValidation();
                lblPartyBankName.Visible = true;
                return;
            }
            else if (txtPartyBankIFSCCode.Text.Trim() == "")
            {
                ClearValidation();
                lblPartyBankIFSCCode.Visible = true;
                return;
            }
            else if (txtPartyBankAccountNumber.Text.Trim() == "")
            {
                ClearValidation();
                lblPartyBankAccountNumber.Visible = true;
                return;
            }
            else if (txtPartyBankBranchAddress.Text.Trim() == "")
            {
                ClearValidation();
                lblPartyBankBranchAddress.Visible = true;
                return;
            }
            #endregion Validation

            #region Gather Data
            if (hfPartyID.Value != "")
            {
                entParty.PartyID = Convert.ToInt32(hfPartyID.Value.Trim());
            }
            if (txtPartyName.Text.Trim() != "")
            {
                entParty.PartyName = txtPartyName.Text.Trim(); 
            }
            if (txtPartyAddress.Text.Trim() != "")
            {
                entParty.PartyAddress = txtPartyAddress.Text.Trim();
            }
            if (txtPartyGSTNumber.Text.Trim() != "")
            {
                entParty.PartyGSTNumber = txtPartyGSTNumber.Text.Trim();
            }
            if (txtPartyPanCardNumber.Text.Trim() != "")
            {
                entParty.PartyPanCardNumber = txtPartyPanCardNumber.Text.Trim();
            }
            else
            {
                entParty.PartyPanCardNumber = null;
            }
            if (txtPartyMobileNumber.Text.Trim() != "" && txtPartyMobileNumber.Text.Length == 10)
            {             
                entParty.PartyMobileNumber = txtPartyMobileNumber.Text.ToString();
            }
            if (txtPartyBankName.Text.Trim() != "")
            { 
                entParty.PartyBankName = txtPartyBankName.Text.Trim();
            }
            if (txtPartyBankIFSCCode.Text.Trim() != "")
            { 
                entParty.PartyBankIFSCCode = txtPartyBankIFSCCode.Text.Trim();
            }
            if (txtPartyBankAccountNumber.Text.Trim() != "")
            { 
                entParty.PartyBankAccountNumber = txtPartyBankAccountNumber.Text.Trim();
            }
            if (txtPartyBankBranchAddress.Text.Trim() != "")
            {
                entParty.PartyBankBranchAddress = txtPartyBankBranchAddress.Text.Trim();   
            }
            if (txtPartyRemark.Text.Trim() != "")
            {
                entParty.PartyRemark = txtPartyRemark.Text.Trim();
            }
            else
            {
                entParty.PartyRemark = null;
            }
            entParty.ModifyDate = DateTime.Now;
            entParty.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entParty.CreateDate = DateTime.Now;
            entParty.CreateBy = Convert.ToInt32(Session["UserID"]);
            entParty.FlagDelete = Convert.ToBoolean(ddlPartyStatus.SelectedValue.Trim());
            #endregion Gather Data

            #region Insert/Update
            if (hfPartyID.Value != "")
            {
                if (balParty.Update(entParty))
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
                if (balParty.Insert(entParty))
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
            hfPartyID.Value = null;
            txtPartyName.Text = "";
            txtPartyAddress.Text = "";
            txtPartyGSTNumber.Text = "";
            txtPartyPanCardNumber.Text = "";
            txtPartyMobileNumber.Text = "";
            txtPartyBankName.Text = "";
            txtPartyBankIFSCCode.Text = "";
            txtPartyBankAccountNumber.Text = "";
            txtPartyBankBranchAddress.Text = "";
            txtPartyRemark.Text = "";
            ddlPartyStatus.SelectedIndex = 0;
        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblPartyName.Visible = false;
            lblPartyAddress.Visible = false;
            lblPartyGSTNumber.Visible = false;
            lblPartyMobileNumber.Visible = false;
            lblPartyMobileDigit.Visible = false;
            lblPartyBankName.Visible = false;
            lblPartyBankIFSCCode.Visible = false;
            lblPartyBankAccountNumber.Visible = false;
            lblPartyBankBranchAddress.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Button

        #region Delete/Fill For Update
        protected void gvParty_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            PartyBAL balParty = new PartyBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balParty.Delete(Convert.ToInt32(e.CommandArgument)))
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
            PartyBAL balParty = new PartyBAL();
            PartyENT entParty = balParty.SelectPK(UserID);
            #endregion Variable

            #region FillDate
            if (!entParty.PartyID.IsNull)
            {
                hfPartyID.Value = entParty.PartyID.Value.ToString();
            }
            if (!entParty.PartyName.IsNull)
            {
                txtPartyName.Text = entParty.PartyName.ToString();
            }
            if (!entParty.PartyAddress.IsNull)
            {
                txtPartyAddress.Text = entParty.PartyAddress.ToString();
            }
            if (!entParty.PartyGSTNumber.IsNull)
            {
                txtPartyGSTNumber.Text = entParty.PartyGSTNumber.ToString();
            }
            if (!entParty.PartyPanCardNumber.IsNull)
            {
                txtPartyPanCardNumber.Text = entParty.PartyPanCardNumber.ToString();
            }
            if (!entParty.PartyMobileNumber.IsNull)
            {
                txtPartyMobileNumber.Text = entParty.PartyMobileNumber.ToString();
            }
            if (!entParty.PartyBankName.IsNull)
            {
                txtPartyBankName.Text = entParty.PartyBankName.ToString();
            }
            if (!entParty.PartyBankIFSCCode.IsNull)
            {
                txtPartyBankIFSCCode.Text = entParty.PartyBankIFSCCode.ToString();
            }
            if (!entParty.PartyBankAccountNumber.IsNull)
            {
                txtPartyBankAccountNumber.Text = entParty.PartyBankAccountNumber.ToString();
            }
            if (!entParty.PartyBankBranchAddress.IsNull)
            {
                txtPartyBankBranchAddress.Text = entParty.PartyBankBranchAddress.ToString();
            }
            if (!entParty.PartyRemark.IsNull)
            {
                txtPartyRemark.Text = entParty.PartyRemark.ToString();
            }
            if (!entParty.FlagDelete.IsNull)
            {
                ddlPartyStatus.SelectedValue = entParty.FlagDelete.ToString().Trim();
            }
            #endregion FillDate
        }
        #endregion Fill_DataBy_PK

        #region PageIndex Change
        protected void gvParty_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvParty.PageIndex = e.NewPageIndex;
            FillGridView();
            gvParty.DataBind();
        }
        #endregion PageIndex Change
    }
}