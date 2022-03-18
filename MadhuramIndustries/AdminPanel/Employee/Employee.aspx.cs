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
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace MadhuramIndustries.AdminPanel.Employee
{
    public partial class Employee : System.Web.UI.Page
    {
        public static byte[] byteEmployeeIDProof;
        public static SqlString strEmployeeIDProofExtension;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                #region Set Default Value
                txtEmployeeDOB.Text = DateTime.Now.ToString("yyyy-MM-dd");
                hfEmployeeIDProof.Value = "0";
                #endregion Set Default Value
                FillDropDownList();
                FillGridView();
            }
        }

        #region FillDropDownList
        private void FillDropDownList()
        {
            CommonFillMethods.UserStatus(ddlEmployeeStatus);
            CommonFillMethods.FillDropDownListEmployeeDesignation(ddlDesignation);
            FillDropDownListEmployeeGender();
            FillDropDownListEmployeeIDProofType();
        }
        #endregion FillDropDownList

        #region Static DropDown

        #region Gender DropDown
        private void FillDropDownListEmployeeGender()
        {
            ddlEmployeeGender.Items.Insert(0, new ListItem("Select Gender", "Select Gender"));
            ddlEmployeeGender.Items.Insert(1, new ListItem("Male", "Male"));
            ddlEmployeeGender.Items.Insert(2, new ListItem("Female", "Female"));
        }
        #endregion Gender DropDown

        #region ID-Type DropDown
        private void FillDropDownListEmployeeIDProofType()
        {
            ddlEmployeeIDProofType.Items.Insert(0, new ListItem("Select ID Type", "Select ID Type"));
            ddlEmployeeIDProofType.Items.Insert(1, new ListItem("Aadhaar Card", "Aadhaar Card"));
            ddlEmployeeIDProofType.Items.Insert(2, new ListItem("Pan Card", "Pan Card"));
            ddlEmployeeIDProofType.Items.Insert(3, new ListItem("Driving License", "Driving License"));
            ddlEmployeeIDProofType.Items.Insert(4, new ListItem("Ration Card", "Ration Card"));
        }
        #endregion ID-Type DropDown

        #endregion Stactic DropDown

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            EmployeeBAL balEmployee = new EmployeeBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balEmployee.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvEmployee.DataSource = dt;
                gvEmployee.DataBind();
            }
            else
            {
                gvEmployee.DataSource = null;
                gvEmployee.DataBind();
            }
            #endregion Bind Data
        }
        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            EmployeeBAL balEmployee = new EmployeeBAL();
            EmployeeENT entEmployee = new EmployeeENT();
            #endregion Variable

            #region Validation
            if (txtEmployeeName.Text == "")
            {
                ClearValidation();
                lblEmployeeName.Visible = true;
                return;
            }
            else if (txtEmployeeMobileNumber.Text == "")
            {
                ClearValidation();
                lblEmployeeMobileNumber.Visible = true;
                return;
            }
            else if (txtEmployeeMobileNumber.Text.Length != 10)
            {
                ClearValidation();
                lblEmployeeMobileDigit.Visible = true;
                return;
            }
            else if (txtEmployeeDOB.Text == "")
            {
                ClearValidation();
                lblEmployeeDOB.Visible = true;
                return;
            }
            else if (ddlEmployeeGender.SelectedIndex == 0)
            {
                ClearValidation();
                lblEmployeeGender.Visible = true;
                return;
            }
            else if (txtEmployeeSalary.Text == "")
            {
                ClearValidation();
                lblEmployeeSalary.Visible = true;
                return;
            }
            else if (txtEmployeeWorkTime.Text == "")
            {
                ClearValidation();
                lblEmployeeWorkTime.Visible = true;
                return;
            }
            else if (ddlDesignation.SelectedIndex == 0)
            {
                ClearValidation();
                lblEmployeeDesignation.Visible = true;
                return;
            }
            else if (!fuEmployeeIDProof.HasFile && hfEmployeeID.Value == "0")
            {
                ClearValidation();
                lblEmployeeIDProof.Visible = true;
                return;
            }
            else if (ddlEmployeeIDProofType.SelectedIndex == 0)
            {
                ClearValidation();
                lblEmployeeIDType.Visible = true;
                return;
            }
            #endregion Validation

            #region Gather Data
            if (hfEmployeeID.Value != "")
            {
                entEmployee.EmployeeID = Convert.ToInt32(hfEmployeeID.Value.Trim());
            }
            if (txtEmployeeName.Text.Trim() != "")
            {
                entEmployee.EmployeeName = txtEmployeeName.Text.Trim();
            }
            if (txtEmployeeCardNumber.Text.Trim() != "")
            {
                entEmployee.EmployeeCardNumber = txtEmployeeCardNumber.Text.Trim();
            }
            if (txtEmployeeMobileNumber.Text.Trim() != "" && txtEmployeeMobileNumber.Text.Length == 10)
            {
                entEmployee.EmployeeMobileNumber = txtEmployeeMobileNumber.Text.Trim();
            }
            if (txtEmployeeCity.Text.Trim() != "")
            {
                entEmployee.EmployeeCity = txtEmployeeCity.Text.Trim();
            }
            if (txtEmployeeDOB.Text.Trim() != "")
            {
                DateTime dateTime = DateTime.Parse(txtEmployeeDOB.Text);
                entEmployee.EmployeeDOB = dateTime;
            }
            if (txtEmployeeAddress.Text.Trim() != "")
            {
                entEmployee.EmployeeAddress = txtEmployeeAddress.Text.Trim();
            }
            if (ddlEmployeeGender.SelectedIndex != 0)
            {
                entEmployee.EmployeeGender = ddlEmployeeGender.SelectedValue.ToString();
            }
            if (txtEmployeeSalary.Text.Trim() != "")
            {
                entEmployee.EmployeeSalary = Convert.ToInt32(txtEmployeeSalary.Text.Trim());
            }
            if (txtEmployeeWorkTime.Text.Trim() != "")
            {
                entEmployee.EmployeeWorkTime = Convert.ToInt32(txtEmployeeWorkTime.Text.Trim());
            }
            if (txtEmployeeOverTimeSalary.Text.Trim() != "")
            {
                entEmployee.EmployeeOverTimeSalary = Convert.ToInt32(txtEmployeeOverTimeSalary.Text.Trim());
            }
            if (ddlDesignation.SelectedIndex != 0)
            {
                entEmployee.DesignationID = Convert.ToInt32(ddlDesignation.SelectedValue.ToString());
            }
            if (fuEmployeeIDProof.HasFile)
            {
                string path = "";
                string extension = System.IO.Path.GetExtension(fuEmployeeIDProof.PostedFile.FileName);
                //fuEmployeeIDProof.SaveAs(Request.PhysicalApplicationPath + "AdminPanel/Document/EmployeeID/" + fuEmployeeIDProof.FileName.ToString());
                fuEmployeeIDProof.SaveAs(Request.PhysicalApplicationPath + "AdminPanel/Document/EmployeeID/" + (txtEmployeeName.Text.ToString() + "" + txtEmployeeMobileNumber.Text.ToString()) + extension);
                path = "AdminPanel/Document/EmployeeID/" + ((txtEmployeeName.Text.ToString() + "" + txtEmployeeMobileNumber.Text.ToString()) + extension);
                System.IO.Stream fs = fuEmployeeIDProof.PostedFile.InputStream;
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                byte[] bytes = br.ReadBytes(fuEmployeeIDProof.PostedFile.ContentLength);
                entEmployee.EmployeeIDProof = bytes;
                entEmployee.EmployeeIDProofExtension = extension;
            }
            else if(hfEmployeeIDProof.Value == "1" && !fuEmployeeIDProof.HasFile)
            {
                entEmployee.EmployeeIDProof = byteEmployeeIDProof;
                entEmployee.EmployeeIDProofExtension = strEmployeeIDProofExtension;
            }
            if (ddlEmployeeIDProofType.SelectedIndex != 0)
            {
                entEmployee.EmployeeIDProofType = ddlEmployeeIDProofType.SelectedValue.ToString();
            }
            if (txtEmployeeRemark.Text.Trim() != "")
            {
                entEmployee.EmployeeRemark = txtEmployeeRemark.Text.Trim();
            }
            entEmployee.ModifyDate = DateTime.Now;
            entEmployee.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entEmployee.CreateDate = DateTime.Now;
            entEmployee.CreateBy = Convert.ToInt32(Session["UserID"]);
            entEmployee.FlagDelete = Convert.ToBoolean(ddlEmployeeStatus.SelectedValue.Trim());
            #endregion Gather Data

            #region Insert/Update
            if (hfEmployeeID.Value != "")
            {
                if (balEmployee.Update(entEmployee))
                {
                    ClearControl();
                    ClearValidation();
                    FillGridView();
                }
                else
                {

                }
            }
            else
            {
                if (balEmployee.Insert(entEmployee))
                {
                    ClearControl();
                    ClearValidation();
                    FillGridView();
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
            hfEmployeeID.Value = null;
            txtEmployeeName.Text = "";
            txtEmployeeCardNumber.Text = "";
            txtEmployeeMobileNumber.Text = "";
            txtEmployeeCity.Text = "";
            txtEmployeeDOB.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtEmployeeAddress.Text = "";
            ddlEmployeeGender.SelectedIndex = 0;
            txtEmployeeSalary.Text = "";
            txtEmployeeWorkTime.Text = "";
            txtEmployeeOverTimeSalary.Text = "";
            ddlDesignation.SelectedIndex = 0;
            ddlEmployeeIDProofType.SelectedIndex = 0;
            txtEmployeeRemark.Text = "";
            ddlEmployeeStatus.SelectedIndex = 0;

        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblEmployeeName.Visible = false;
            lblEmployeeMobileNumber.Visible = false;
            lblEmployeeMobileDigit.Visible = false;
            lblEmployeeDOB.Visible = false;
            lblEmployeeGender.Visible = false;
            lblEmployeeSalary.Visible = false;
            lblEmployeeWorkTime.Visible = false;
            lblEmployeeDesignation.Visible = false;
            lblEmployeeIDProof.Visible = false;
            lblEmployeeIDType.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Button

        #region Delete/Fill/DownloadDocument For Update
        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            EmployeeBAL balEmployee = new EmployeeBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balEmployee.Delete(Convert.ToInt32(e.CommandArgument)))
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

            #region Download EmployeeDocument
            else if (e.CommandName == "Download" && e.CommandArgument != null)
            {
                EmployeeENT entEmployee = balEmployee.SelectPK(Convert.ToInt32(e.CommandArgument));
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + (entEmployee.EmployeeName.ToString() + "_" + entEmployee.EmployeeMobileNumber.ToString() + entEmployee.EmployeeIDProofExtension.ToString()));
                Response.BinaryWrite((byte[])entEmployee.EmployeeIDProof);
                Response.Flush();
                Response.End();
            }
            #endregion Download EmployeeDocument
        }
        #endregion Delete/Fill/DownloadDocument For Update

        #region Fill_DataBy_PK
        private void FillDataByPK(SqlInt32 UserID)
        {
            #region Variable
            EmployeeBAL balEmployee = new EmployeeBAL();
            EmployeeENT entEmployee = balEmployee.SelectPK(UserID);
            #endregion Variable

            ClearControl();
            ClearValidation();

            #region FillDate
            if (!entEmployee.EmployeeID.IsNull)
            {
                hfEmployeeID.Value = entEmployee.EmployeeID.Value.ToString();
            }
            if (!entEmployee.EmployeeName.IsNull)
            {
                txtEmployeeName.Text = entEmployee.EmployeeName.Value.ToString();
            }
            if (!entEmployee.EmployeeCardNumber.IsNull)
            {
                txtEmployeeCardNumber.Text = entEmployee.EmployeeCardNumber.Value.ToString();
            }
            if (!entEmployee.EmployeeMobileNumber.IsNull)
            {
                txtEmployeeMobileNumber.Text = entEmployee.EmployeeMobileNumber.Value.ToString();
            }
            if (!entEmployee.EmployeeCity.IsNull)
            {
                txtEmployeeCity.Text = entEmployee.EmployeeCity.Value.ToString();
            }
            if (!entEmployee.EmployeeDOB.Equals(DBNull.Value))
            {
                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                DateTime dateTime = DateTime.Parse(entEmployee.EmployeeDOB.ToString().Trim());
                string date = string.Format("{0:dd-MM-yyy}", dateTime);
                txtEmployeeDOB.Text = Convert.ToDateTime(date).Date.ToString("yyyy-MM-dd");
            }
            if (!entEmployee.EmployeeAddress.IsNull)
            {
                txtEmployeeAddress.Text = entEmployee.EmployeeAddress.Value.ToString();
            }
            if (!entEmployee.EmployeeGender.IsNull)
            {
                ddlEmployeeGender.SelectedValue = entEmployee.EmployeeGender.Value.ToString();
            }
            if (!entEmployee.EmployeeSalary.IsNull)
            {
                txtEmployeeSalary.Text = entEmployee.EmployeeSalary.Value.ToString();
            }
            if (!entEmployee.EmployeeWorkTime.IsNull)
            {
                txtEmployeeWorkTime.Text = entEmployee.EmployeeWorkTime.Value.ToString();
            }
            if (!entEmployee.EmployeeOverTimeSalary.IsNull)
            {
                txtEmployeeOverTimeSalary.Text = entEmployee.EmployeeOverTimeSalary.Value.ToString();
            }
            if (!entEmployee.DesignationID.IsNull)
            {
                ddlDesignation.SelectedValue = entEmployee.DesignationID.Value.ToString();
            }
            if (!entEmployee.EmployeeIDProof.IsNull)
            {
                hfEmployeeIDProof.Value = "1";
                byteEmployeeIDProof = (byte[])entEmployee.EmployeeIDProof;
            }
            if (!entEmployee.EmployeeIDProofExtension.IsNull)
            {
                strEmployeeIDProofExtension = entEmployee.EmployeeIDProofExtension;
            }
            if (!entEmployee.EmployeeIDProofType.IsNull)
            {
                ddlEmployeeIDProofType.SelectedValue = entEmployee.EmployeeIDProofType.Value.ToString();
            }
            if (!entEmployee.EmployeeRemark.IsNull)
            {
                txtEmployeeRemark.Text = entEmployee.EmployeeRemark.ToString();
            }
            if (!entEmployee.FlagDelete.IsNull)
            {
                ddlEmployeeStatus.SelectedValue = entEmployee.FlagDelete.ToString().Trim();
            }
            #endregion FillDate
        }
        #endregion Fill_DataBy_PK

        #region PageIndex Change
        protected void gvEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployee.PageIndex = e.NewPageIndex;
            FillGridView();
            gvEmployee.DataBind();
        }
        #endregion PageIndex Change

    }
}