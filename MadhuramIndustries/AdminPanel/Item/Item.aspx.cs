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

namespace MadhuramIndustries.AdminPanel.Item
{
    public partial class Item : System.Web.UI.Page
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
            CommonFillMethods.UserStatus(ddlItemStatus);
            FillItemGST();
            FillItemUnit();
        }
        #endregion FillDropDownList

        #region FillStaticDropDownList

        #region FillItemGST
        private void FillItemGST()
        {
            ddlItemGST.Items.Insert(0, new ListItem("Select GST Slab", "Select GST Slab"));
            ddlItemGST.Items.Insert(1, new ListItem("5%", "5"));
            ddlItemGST.Items.Insert(2, new ListItem("12%", "12"));
            ddlItemGST.Items.Insert(3, new ListItem("18%", "18"));
            ddlItemGST.Items.Insert(4, new ListItem("28%", "28"));
        }
        #endregion FillItemGST

        #region FillItemUnit
        private void FillItemUnit()
        {
            ddlItemUnit.Items.Insert(0, new ListItem("Select Unit", "Select Unit"));
            ddlItemUnit.Items.Insert(1, new ListItem("NOS", "NOS"));
            ddlItemUnit.Items.Insert(2, new ListItem("KG", "KG"));
            ddlItemUnit.Items.Insert(3, new ListItem("ML", "ML"));
        }
        #endregion FillItemUnit

        #endregion FillStaticDropDownList

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            ItemBAL balItem = new ItemBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balItem.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvItem.DataSource = dt;
                gvItem.DataBind();
            }
            #endregion Bind Data
        }
        #endregion Fill GridView

        #region Save Click
        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            ItemBAL balItem = new ItemBAL();
            ItemENT entItem = new ItemENT();
            #endregion Variable

            #region Validation
            if (txtItemName.Text.Trim() == "")
            {
                ClearValidation();
                lblItemName.Visible = true;
                return;
            }
            else if (txtItemCode.Text.Trim() == "")
            {
                ClearValidation();
                lblItemCode.Visible = true;
                return;
            }
            else if (ddlItemGST.SelectedIndex == 0)
            {
                ClearValidation();
                lblItemGST.Visible = true;
                return;
            }
            else if (ddlItemUnit.SelectedIndex == 0)
            {
                ClearValidation();
                lblItemUnit.Visible = true;
                return;
            }
            #endregion Validation

            #region Gather Data
            if (hfItemID.Value != "")
            {
                entItem.ItemID = Convert.ToInt32(hfItemID.Value.Trim());
            }
            if (txtItemName.Text.Trim() != "")
            {
                entItem.ItemName = txtItemName.Text.Trim();
            }
            if (txtItemCode.Text.Trim() != "")
            {
                entItem.ItemCode = txtItemCode.Text.Trim();
            }
            if (ddlItemGST.SelectedIndex != 0)
            {
                entItem.ItemGST = Convert.ToInt32(ddlItemGST.SelectedValue.ToString());
            }
            if (ddlItemUnit.SelectedIndex != 0)
            {
                entItem.ItemUnit = ddlItemUnit.SelectedValue.ToString();
            }
            if (txtItemRemark.Text.Trim() != "")
            {
                entItem.ItemRemark = txtItemRemark.Text.Trim();
            }
            entItem.ModifyDate = DateTime.Now;
            entItem.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entItem.CreateDate = DateTime.Now;
            entItem.CreateBy = Convert.ToInt32(Session["UserID"]);
            entItem.FlagDelete = Convert.ToBoolean(ddlItemStatus.SelectedValue.Trim());
            #endregion Gather Data

            #region Insert/Update
            if (hfItemID.Value != "")
            {
                if (balItem.Update(entItem))
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
                if (balItem.Insert(entItem))
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
            hfItemID.Value = null;
            txtItemName.Text = "";
            txtItemCode.Text = "";
            ddlItemGST.SelectedIndex = -1;
            ddlItemUnit.SelectedIndex = -1;
            txtItemRemark.Text = "";
            ddlItemStatus.SelectedIndex = 0;
        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblItemName.Visible = false;
            lblItemCode.Visible = false;
            lblItemGST.Visible = false;
            lblItemUnit.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Button

        #region Delete/Fill For Update
        protected void gvItem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            ItemBAL balItem = new ItemBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balItem.Delete(Convert.ToInt32(e.CommandArgument)))
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
            ItemBAL balItem = new ItemBAL();
            ItemENT entItem = balItem.SelectPK(UserID);
            #endregion Variable

            #region FillDate
            if (!entItem.ItemID.IsNull)
            {
                hfItemID.Value = entItem.ItemID.Value.ToString();
            }
            if (!entItem.ItemName.IsNull)
            {
                txtItemName.Text = entItem.ItemName.ToString();
            }
            if (!entItem.ItemCode.IsNull)
            {
                txtItemCode.Text = entItem.ItemCode.ToString();
            }
            if (!entItem.ItemGST.IsNull)
            {
                ddlItemGST.SelectedValue = entItem.ItemGST.ToString();
            }
            if (!entItem.ItemUnit.IsNull)
            {
                ddlItemUnit.SelectedValue = entItem.ItemUnit.ToString();
            }
            if (!entItem.ItemRemark.IsNull)
            {
                txtItemRemark.Text = entItem.ItemRemark.ToString();
            }
            if (!entItem.FlagDelete.IsNull)
            {
                ddlItemStatus.SelectedValue = entItem.FlagDelete.ToString().Trim();
            }
            #endregion FillDate
        }
        #endregion Fill_DataBy_PK

        #region PageIndex Change
        protected void gvItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvItem.PageIndex = e.NewPageIndex;
            FillGridView();
            gvItem.DataBind();
        }
        #endregion PageIndex Change
    }
}