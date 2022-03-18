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

namespace MadhuramIndustries.AdminPanel.MadhuramIndustries
{
    public partial class MadhuramIndustries : System.Web.UI.Page
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
            CommonFillMethods.UserStatus(ddlMadhuramIndustriesStatus);
        }
        #endregion FillDropDownList

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            MadhuramIndustriesBAL balMadhuramIndustries = new MadhuramIndustriesBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balMadhuramIndustries.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvMadhuramIndustries.DataSource = dt;
                gvMadhuramIndustries.DataBind();
            }
            #endregion Bind Data
        }
        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            MadhuramIndustriesBAL balMadhuramIndustries = new MadhuramIndustriesBAL();
            MadhuramIndustriesENT entMadhuramIndustries = new MadhuramIndustriesENT();
            #endregion Variable

            #region Validation
            if (txtMadhuramIndustriesName.Text.Trim() == "")
            {
                ClearValidation();
                lblMadhuramIndustriesName.Visible = true;
                return;
            }
            else if (txtMadhuramIndustriesAddress.Text.Trim() == "")
            {
                ClearValidation();
                lblMadhuramIndustriesAddress.Visible = true;
                return;
            }
            else if (txtMadhuramIndustriesGSTNumber.Text.Trim() == "")
            {
                ClearValidation();
                lblMadhuramIndustriesGSTNumber.Visible = true;
                return;
            }
            else if (txtMadhuramIndustriesMobileNumber.Text.Trim() == "")
            {
                ClearValidation();
                lblMadhuramIndustriesMobileNumber.Visible = true;
                return;
            }
            else if (txtMadhuramIndustriesMobileNumber.Text.Length != 10)
            {
                ClearValidation();
                lblMadhuramIndustriesMobileDigit.Visible = true;
                return;
            }
            else if (txtMadhuramIndustriesBankName.Text.Trim() == "")
            {
                ClearValidation();
                lblMadhuramIndustriesBankName.Visible = true;
                return;
            }
            else if (txtMadhuramIndustriesBankIFSCCode.Text.Trim() == "")
            {
                ClearValidation();
                lblMadhuramIndustriesBankIFSCCode.Visible = true;
                return;
            }
            else if (txtMadhuramIndustriesBankAccountNumber.Text.Trim() == "")
            {
                ClearValidation();
                lblMadhuramIndustriesBankAccountNumber.Visible = true;
                return;
            }
            else if (txtMadhuramIndustriesBankBranchAddress.Text.Trim() == "")
            {
                ClearValidation();
                lblMadhuramIndustriesBankBranchAddress.Visible = true;
                return;
            }
            #endregion Validation

            #region Gather Data
            if (hfMadhuramIndustriesID.Value != "")
            {
                entMadhuramIndustries.MadhuramIndustriesID = Convert.ToInt32(hfMadhuramIndustriesID.Value.Trim());
            }
            if (txtMadhuramIndustriesName.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesName = txtMadhuramIndustriesName.Text.Trim();
            }
            if (txtMadhuramIndustriesAddress.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesAddress = txtMadhuramIndustriesAddress.Text.Trim();
            }
            if (txtMadhuramIndustriesGSTNumber.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesGSTNumber = txtMadhuramIndustriesGSTNumber.Text.Trim();
            }
            if (txtMadhuramIndustriesPanCardNumber.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesPanCardNumber = txtMadhuramIndustriesPanCardNumber.Text.Trim();
            }
            else
            {
                entMadhuramIndustries.MadhuramIndustriesPanCardNumber = null;
            }
            if (txtMadhuramIndustriesMobileNumber.Text.Trim() != "" && txtMadhuramIndustriesMobileNumber.Text.Length == 10)
            {
                entMadhuramIndustries.MadhuramIndustriesMobileNumber = txtMadhuramIndustriesMobileNumber.Text.ToString();
            }
            if (txtMadhuramIndustriesBankName.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesBankName = txtMadhuramIndustriesBankName.Text.Trim();
            }
            if (txtMadhuramIndustriesBankIFSCCode.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesBankIFSCCode = txtMadhuramIndustriesBankIFSCCode.Text.Trim();
            }
            if (txtMadhuramIndustriesBankAccountNumber.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesBankAccountNumber = txtMadhuramIndustriesBankAccountNumber.Text.Trim();
            }
            if (txtMadhuramIndustriesBankBranchAddress.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesBankBranchAddress = txtMadhuramIndustriesBankBranchAddress.Text.Trim();
            }
            if (txtMadhuramIndustriesRemark.Text.Trim() != "")
            {
                entMadhuramIndustries.MadhuramIndustriesRemark = txtMadhuramIndustriesRemark.Text.Trim();
            }
            else
            {
                entMadhuramIndustries.MadhuramIndustriesRemark = null;
            }
            entMadhuramIndustries.ModifyDate = DateTime.Now;
            entMadhuramIndustries.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entMadhuramIndustries.CreateDate = DateTime.Now;
            entMadhuramIndustries.CreateBy = Convert.ToInt32(Session["UserID"]);
            entMadhuramIndustries.FlagDelete = Convert.ToBoolean(ddlMadhuramIndustriesStatus.SelectedValue.Trim());
            #endregion Gather Data

            #region Insert/Update
            if (hfMadhuramIndustriesID.Value != "")
            {
                if (balMadhuramIndustries.Update(entMadhuramIndustries))
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
                if (balMadhuramIndustries.Insert(entMadhuramIndustries))
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
            hfMadhuramIndustriesID.Value = null;
            txtMadhuramIndustriesName.Text = "";
            txtMadhuramIndustriesAddress.Text = "";
            txtMadhuramIndustriesGSTNumber.Text = "";
            txtMadhuramIndustriesPanCardNumber.Text = "";
            txtMadhuramIndustriesMobileNumber.Text = "";
            txtMadhuramIndustriesBankName.Text = "";
            txtMadhuramIndustriesBankIFSCCode.Text = "";
            txtMadhuramIndustriesBankAccountNumber.Text = "";
            txtMadhuramIndustriesBankBranchAddress.Text = "";
            txtMadhuramIndustriesRemark.Text = "";
            ddlMadhuramIndustriesStatus.SelectedIndex = 0;
        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblMadhuramIndustriesName.Visible = false;
            lblMadhuramIndustriesAddress.Visible = false;
            lblMadhuramIndustriesGSTNumber.Visible = false;
            lblMadhuramIndustriesMobileNumber.Visible = false;
            lblMadhuramIndustriesMobileDigit.Visible = false;
            lblMadhuramIndustriesBankName.Visible = false;
            lblMadhuramIndustriesBankIFSCCode.Visible = false;
            lblMadhuramIndustriesBankAccountNumber.Visible = false;
            lblMadhuramIndustriesBankBranchAddress.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Button

        #region Delete/Fill For Update
        protected void gvMadhuramIndustries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            MadhuramIndustriesBAL balMadhuramIndustries = new MadhuramIndustriesBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balMadhuramIndustries.Delete(Convert.ToInt32(e.CommandArgument)))
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
            MadhuramIndustriesBAL balMadhuramIndustries = new MadhuramIndustriesBAL();
            MadhuramIndustriesENT entMadhuramIndustries = balMadhuramIndustries.SelectPK(UserID);
            #endregion Variable

            #region FillDate
            if (!entMadhuramIndustries.MadhuramIndustriesID.IsNull)
            {
                hfMadhuramIndustriesID.Value = entMadhuramIndustries.MadhuramIndustriesID.Value.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesName.IsNull)
            {
                txtMadhuramIndustriesName.Text = entMadhuramIndustries.MadhuramIndustriesName.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesAddress.IsNull)
            {
                txtMadhuramIndustriesAddress.Text = entMadhuramIndustries.MadhuramIndustriesAddress.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesGSTNumber.IsNull)
            {
                txtMadhuramIndustriesGSTNumber.Text = entMadhuramIndustries.MadhuramIndustriesGSTNumber.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesPanCardNumber.IsNull)
            {
                txtMadhuramIndustriesPanCardNumber.Text = entMadhuramIndustries.MadhuramIndustriesPanCardNumber.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesMobileNumber.IsNull)
            {
                txtMadhuramIndustriesMobileNumber.Text = entMadhuramIndustries.MadhuramIndustriesMobileNumber.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesBankName.IsNull)
            {
                txtMadhuramIndustriesBankName.Text = entMadhuramIndustries.MadhuramIndustriesBankName.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesBankIFSCCode.IsNull)
            {
                txtMadhuramIndustriesBankIFSCCode.Text = entMadhuramIndustries.MadhuramIndustriesBankIFSCCode.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesBankAccountNumber.IsNull)
            {
                txtMadhuramIndustriesBankAccountNumber.Text = entMadhuramIndustries.MadhuramIndustriesBankAccountNumber.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesBankBranchAddress.IsNull)
            {
                txtMadhuramIndustriesBankBranchAddress.Text = entMadhuramIndustries.MadhuramIndustriesBankBranchAddress.ToString();
            }
            if (!entMadhuramIndustries.MadhuramIndustriesRemark.IsNull)
            {
                txtMadhuramIndustriesRemark.Text = entMadhuramIndustries.MadhuramIndustriesRemark.ToString();
            }
            if (!entMadhuramIndustries.FlagDelete.IsNull)
            {
                ddlMadhuramIndustriesStatus.SelectedValue = entMadhuramIndustries.FlagDelete.ToString().Trim();
            }
            #endregion FillDate
        }
        #endregion Fill_DataBy_PK

        #region PageIndex Change
        protected void gvMadhuramIndustries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMadhuramIndustries.PageIndex = e.NewPageIndex;
            FillGridView();
            gvMadhuramIndustries.DataBind();
        }
        #endregion PageIndex Change
    }
}