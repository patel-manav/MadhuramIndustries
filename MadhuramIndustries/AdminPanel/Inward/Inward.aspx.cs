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

namespace MadhuramIndustries.AdminPanel.Inward
{
    public partial class Inward : System.Web.UI.Page
    {
        static int key = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                #region Set Default Value
                txtInwardDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                #endregion Set Default Value
                FillDropDownList();
                FillGridView();
            }
        }

        #region FillDropDownList
        private void FillDropDownList()
        {
            CommonFillMethods.FillDropDownListParty(ddlParty);
            CommonFillMethods.FillDropDownListItem(ddlItem);
        }
        #endregion FillDropDownList

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            InwardBAL balInward = new InwardBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balInward.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvInward.DataSource = dt;
                gvInward.DataBind();
            }
            #endregion Bind Data
        }
        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            InwardBAL balInward = new InwardBAL();
            InwardENT entInward = new InwardENT();
            #endregion Variable

            #region Validation
            if ((ddlParty.SelectedIndex == 0 && hfInwardID.Value != ""))
            {
                ClearValidation();
                lblParty.Visible = true;
                return;
            }
            else if (ddlItem.SelectedIndex == 0 && hfInwardID.Value != "")
            {
                ClearValidation();
                lblItem.Visible = true;
                return;
            }
            else if (txtInwardQuantity.Text.Trim() == "" && hfInwardID.Value != "")
            {
                ClearValidation();
                lblInwardQuantity.Visible = true;
                return;
            }
            #endregion Validation

            #region GatherData/Insert
            if (hfInwardID.Value != "")
            {
                entInward.InwardID = Convert.ToInt32(hfInwardID.Value.Trim());
            }
            if (txtInwardDate.Text.Trim() != "")
            {
                DateTime dateTime = DateTime.Parse(txtInwardDate.Text);
                entInward.InwardDate = dateTime;
            }
            if (ddlParty.SelectedIndex != 0)
            {
                entInward.PartyID = Convert.ToInt32(ddlParty.SelectedValue.ToString());
            }
            entInward.ModifyDate = DateTime.Now;
            entInward.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entInward.CreateDate = DateTime.Now;
            entInward.CreateBy = Convert.ToInt32(Session["UserID"]);

            DataTable dt = (DataTable)ViewState["vsInward"];

            if (hfInwardID.Value == "")
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!dr["ItemID"].Equals(DBNull.Value))
                    {
                        entInward.ItemID = Convert.ToInt32(dr["ItemID"]);
                    }
                    if (!dr["Quantity"].Equals(DBNull.Value))
                    {
                        entInward.InwardQuantity = Convert.ToInt32(dr["Quantity"]);
                    }
                    if (!dr["Remark"].Equals(DBNull.Value))
                    {
                        entInward.InwardRemark = dr["Remark"].ToString();
                    }

                    if (balInward.Insert(entInward))
                    {

                    }
                }

                rpData.DataSource = null;
                rpData.DataBind();
                rpData.Visible = false;
                ClearControl();
            }
            #endregion GatherData/Insert

            #region Update
            if (hfInwardID.Value != "")
            {
                if (ddlItem.SelectedIndex != 0)
                {
                    entInward.ItemID = Convert.ToInt32(ddlItem.SelectedValue);
                }
                if (txtInwardQuantity.Text != "")
                {
                    entInward.InwardQuantity = Convert.ToInt32(txtInwardQuantity.Text);
                }
                if (txtInwardRemark.Text != "")
                {
                    entInward.InwardRemark = txtInwardRemark.Text.Trim();
                }

                if (balInward.Update(entInward))
                {
                    ClearControl();
                    ClearValidation();
                }
            }

            #endregion Update
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
            gvInward.Visible = true;
            rpData.DataSource = null;
            rpData.DataBind();
            //key = 0;
            rpData.Visible = false;
            rpData.Visible = false;
            hfInwardID.Value = null;
            txtInwardDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtInwardDate.Enabled = true;
            ddlParty.SelectedIndex = 0;
            ddlParty.Enabled = true;
            ddlItem.SelectedIndex = 0;
            txtInwardQuantity.Text = "";
            txtInwardRemark.Text = "";
            btnSave.Visible = false;
            btnAdd.Visible = true;
        }
        #endregion Clear Control

        #region Clear Control For Add
        private void ClearControlForAdd()
        {
            hfInwardID.Value = null;
            txtInwardDate.Enabled = false;
            ddlItem.SelectedIndex = 0;
            ddlParty.Enabled = false;
            txtInwardQuantity.Text = "";
            txtInwardRemark.Text = "";
        }
        #endregion Clear Control For Add

        #region Clear Validation
        private void ClearValidation()
        {
            lblItem.Visible = false;
            lblParty.Visible = false;
            lblInwardQuantity.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Button

        #region Delete/Fill For Update
        protected void gvInward_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            InwardBAL balInward = new InwardBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balInward.Delete(Convert.ToInt32(e.CommandArgument)))
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
                btnSave.Visible = true;
                btnAdd.Visible = false;
                FillDataByPK(Convert.ToInt32(e.CommandArgument));
            }
            #endregion Call FillDataByPK
        }
        #endregion Delete/Fill For Update

        #region Fill_DataBy_PK
        private void FillDataByPK(SqlInt32 UserID)
        {
            #region Variable
            InwardBAL balInward = new InwardBAL();
            InwardENT entInward = balInward.SelectPK(UserID);
            #endregion Variable

            #region FillDate
            if (!entInward.InwardID.IsNull)
            {
                hfInwardID.Value = entInward.InwardID.Value.ToString();
            }
            if (!entInward.InwardDate.Equals(DBNull.Value))
            {
                //txtCity.Text = entPayment.PaymentDate.ToString();
                System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
                DateTime dateTime = DateTime.Parse(entInward.InwardDate.ToString().Trim());
                string date = string.Format("{0:dd-MM-yyy}", dateTime);
                txtInwardDate.Text = Convert.ToDateTime(date).Date.ToString("yyyy-MM-dd");
            }
            if (!entInward.ItemID.IsNull)
            {
                ddlItem.SelectedValue = entInward.ItemID.ToString();
            }
            if (!entInward.PartyID.IsNull)
            {
                ddlParty.SelectedValue = entInward.PartyID.ToString();
            }
            if (!entInward.InwardQuantity.IsNull)
            {
                txtInwardQuantity.Text = entInward.InwardQuantity.ToString();
            }
            if (!entInward.InwardRemark.IsNull)
            {
                txtInwardRemark.Text = entInward.InwardRemark.ToString();
            }
            #endregion FillDate
        }
        #endregion Fill_DataBy_PK

        #region PageIndex Change
        protected void gvInward_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInward.PageIndex = e.NewPageIndex;
            FillGridView();
            gvInward.DataBind();
        }
        #endregion PageIndex Change

        #region Add Button
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["vsInward"] == null)
            {
                InItInwardDataTable();
                AddRowToDataTable();
            }
            else
            {
                AddRowToDataTable();
            }
        }
        #endregion Add Button

        #region Add Coloumn For Temp Data [Init Method]
        private void InItInwardDataTable()
        {
            DataTable dtInward = new DataTable();
            dtInward.Columns.Add("Key", typeof(Int32));
            dtInward.Columns.Add("ItemID", typeof(Int32));
            dtInward.Columns.Add("Item", typeof(String));
            dtInward.Columns.Add("Quantity", typeof(Int32));
            dtInward.Columns.Add("Remark", typeof(String));

            ViewState["vsInward"] = dtInward;
        }
        #endregion Add Coloumn For Temp Data [Init Method]

        #region Add Temp Row/Data
        private void AddRowToDataTable()
        {
            #region Parameter
            DataTable dt = (DataTable)ViewState["vsInward"];
            DataRow dr;
            #endregion Parameter

            //Validation karva nu baki chhe
            #region Validation
            if (ddlParty.SelectedIndex == 0)
            {
                ClearValidation();
                lblParty.Visible = true;
                return;
            }
            else if (ddlItem.SelectedIndex == 0)
            {
                ClearValidation();
                lblItem.Visible = true;
                return;
            }
            else if (txtInwardQuantity.Text.Trim() == "")
            {
                ClearValidation();
                lblInwardQuantity.Visible = true;
                return;
            }
            #endregion Validation

            #region Check Edit or Add
            if (hfKey.Value != String.Empty)
            {
                dr = dt.Select("Key = '" + hfKey.Value + "'").FirstOrDefault();
            }
            else
            {
                dr = dt.NewRow();
                key += 1;
                dr["Key"] = key;
            }
            #endregion Check Edit or Add

            #region Gather Data
            ClearValidation();
            if (ddlItem.SelectedIndex != 0)
            {
                dr["ItemID"] = Convert.ToInt32(ddlItem.SelectedValue);
                dr["Item"] = ddlItem.SelectedItem.ToString();
            }
            if (txtInwardQuantity.Text != "")
            {
                dr["Quantity"] = Convert.ToInt32(txtInwardQuantity.Text.ToString());
            }
            if (txtInwardRemark.Text != "")
            {
                dr["Remark"] = txtInwardRemark.Text.Trim();
            }

            if (hfKey.Value == String.Empty)
                dt.Rows.Add(dr);

            #endregion Gather Data

            #region Bind Repeater

            if (dt != null && dt.Rows.Count > 0)
            {
                divDatatable.Visible = true;
                ViewState["vsInward"] = dt;
                rpData.Visible = true;
                rpData.DataSource = dt;
                rpData.DataBind();
                btnSave.Visible = true;
                gvInward.Visible = false;
                ClearControlForAdd();
                hfKey.Value = String.Empty;
                btnAdd.Text = "Add";
            }
            else
            {
                divDatatable.Visible = false;
                rpData.DataSource = null;
                rpData.DataBind();
            }
            #endregion Bind Repeater
        }
        #endregion Add Temp Row/Data

        #region Edit/Delete For Temp Data
        protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            #region Edit Record
            if (e.CommandName == "EditRecord")
            {
                DataTable dt = (DataTable)ViewState["vsInward"];
                DataRow dr = dt.Select("Key = " + Convert.ToInt32(e.CommandArgument)).FirstOrDefault();

                btnAdd.Text = "Edit";
                hfKey.Value = dr["Key"].ToString();

                if (!dr["ItemID"].Equals(DBNull.Value) && !dr["Item"].Equals(DBNull.Value))
                    ddlItem.SelectedValue = dr["ItemID"].ToString();

                if (!dr["Quantity"].Equals(DBNull.Value))
                    txtInwardQuantity.Text = dr["Quantity"].ToString();

                if (!dr["Remark"].Equals(DBNull.Value))
                    txtInwardRemark.Text = dr["Remark"].ToString();

            }
            #endregion Edit Record

            #region Delete Record
            if (e.CommandName == "DeleteRecord")
            {
                DataTable dt = (DataTable)ViewState["vsInward"];
                DataRow dr = dt.Select("Key = " + Convert.ToInt32(e.CommandArgument)).FirstOrDefault();
                dr.Delete();

                if (dt != null && dt.Rows.Count > 0)
                {
                    divDatatable.Visible = true;
                    ViewState["vsInward"] = dt;
                    rpData.DataSource = dt;
                    rpData.DataBind();
                    ClearControl();
                }
                else
                {
                    divDatatable.Visible = false;
                    rpData.DataSource = null;
                    rpData.DataBind();
                }
            }
            #endregion Delete Record
        }
        #endregion Edit/Delete For Temp Data
    }
}