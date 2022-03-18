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

namespace MadhuramIndustries.AdminPanel.Menu
{
    public partial class Menu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["UserID"] == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                FillGridView();
            }
        }

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            MenuBAL balMenu = new MenuBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balMenu.Select();

            if (dt != null && dt.Rows.Count > 0)
            {
                gvMenu.DataSource = dt;
                gvMenu.DataBind();
            }
            #endregion Bind Data

        }

        #endregion Fill GridView

        #region Save Click

        protected void btnSave_Click(object sender, EventArgs e)
        {
            #region Variable
            MenuENT entMenu = new MenuENT();
            MenuBAL balMenu = new MenuBAL();
            #endregion Variable

            #region Validation
            if (txtMenuName.Text.Trim() == "")
            {
                ClearValidation();
                lblMenuName.Visible = true;
                return;
            }
            if (txtMenuURL.Text.Trim() == "")
            {
                ClearValidation();
                lblMenuURL.Visible = true;
                return;
            }
            if (txtMenuSequence.Text.Trim() == "")
            {
                ClearValidation();
                lblMenuSequence.Visible = true;
                return;
            }

            #endregion Validation

            #region Gather Data
            if (hfMenuID.Value != "")
            {
                entMenu.MenuID = Convert.ToInt32(hfMenuID.Value.Trim());
            }

            if (txtMenuName.Text.Trim() != "")
            {
                entMenu.MenuName = txtMenuName.Text.Trim();
            }

            if (txtMenuImage.Text.Trim() != "")
            {
                entMenu.MenuImagePath = txtMenuImage.Text.Trim();
            }

            if (txtMenuURL.Text.Trim() != "")
            {
                entMenu.MenuURL = txtMenuURL.Text.Trim();
            }

            if (txtMenuSequence.Text.Trim() != "")
            {
                entMenu.MenuSequence = Convert.ToDecimal(txtMenuSequence.Text);
            }

            entMenu.ModifyDate = DateTime.Now;
            entMenu.ModifyBy = Convert.ToInt32(Session["UserID"]);
            entMenu.CreateDate = DateTime.Now;
            entMenu.CreateBy = Convert.ToInt32(Session["UserID"]);

            #endregion Gather Data

            #region Insert/Update
            if (hfMenuID.Value != "")
            {
                if (balMenu.Update(entMenu))
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
                if (balMenu.Insert(entMenu))
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
            hfMenuID.Value = null;
            txtMenuName.Text = "";
            txtMenuImage.Text = "";
            txtMenuURL.Text = "";
            txtMenuSequence.Text = "";
        }
        #endregion Clear Control

        #region Clear Validation
        private void ClearValidation()
        {
            lblMenuName.Visible = false;
            lblMenuURL.Visible = false;
            lblMenuSequence.Visible = false;
        }
        #endregion Clear Validation

        #endregion Clear Control

        #region Delete/Update
        protected void gvMenu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region Variable
            MenuBAL balMenu = new MenuBAL();
            #endregion Variable

            #region Clear Validation
            ClearValidation();
            #endregion Clear Validation

            #region Delete Record
            if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
            {
                if (balMenu.Delete(Convert.ToInt32(e.CommandArgument)))
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
        private void FillDataByPK(SqlInt32 MenuID)
        {
            #region Variable
            MenuBAL balMenu = new MenuBAL();
            MenuENT entMenu = balMenu.SelectPK(MenuID);
            #endregion Variable

            #region Fill Data
            if (!entMenu.MenuID.IsNull)
            {
                hfMenuID.Value = entMenu.MenuID.Value.ToString();
            }
            if (!entMenu.MenuName.IsNull)
            {
                txtMenuName.Text = entMenu.MenuName.Value;
            }
            if (!entMenu.MenuImagePath.IsNull)
            {
                txtMenuImage.Text = entMenu.MenuImagePath.Value;
            }
            if (!entMenu.MenuURL.IsNull)
            {
                txtMenuURL.Text = entMenu.MenuURL.Value;
            }
            if (!entMenu.MenuSequence.Equals(null))
            {
                txtMenuSequence.Text = entMenu.MenuSequence.ToString();
            }
            #endregion Fill Data

        }
        #endregion FillDataByPK

        #region PageIndex Change
        protected void gvMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMenu.PageIndex = e.NewPageIndex;
            FillGridView();
            gvMenu.DataBind();
        }
        #endregion PageIndex Change
    }
}