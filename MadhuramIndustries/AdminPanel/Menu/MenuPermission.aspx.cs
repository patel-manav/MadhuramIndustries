using MadhuramIndustries.App_Code;
using MadhuramIndustries.App_Code.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MadhuramIndustries.AdminPanel.Menu
{
    public partial class MenuPermission : System.Web.UI.Page
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
                ddlUserID_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        #region UserIndexChange
        protected void ddlUserID_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillMenuList(Convert.ToInt32(ddlUserID.SelectedValue));
        }
        #endregion UserIndexChange

        #region FillMenu
        private void FillMenuList(SqlInt32 userID)
        {
            UserWiseMenuBAL balUserWiseMenu = new UserWiseMenuBAL();
            DataTable dt = balUserWiseMenu.Select(userID);
            if (dt != null && dt.Rows.Count > 0)
            {
                MenuList.DataSource = dt;
                MenuList.DataBind();
            }
        }
        #endregion FillMenu

        #region Fill User DropDown
        private void FillDropDownList()
        {
            CommonFillMethods.FillDropDownListUser(ddlUserID);
        }
        #endregion Fill User DropDown

        #region SaveButton
        protected void Save_Click(object sender, EventArgs e)
        {
            UserWiseMenuBAL balUserWiseMenu = new UserWiseMenuBAL();

            SqlInt32 UserID = SqlInt32.Null;

            UserID = Convert.ToInt32(ddlUserID.SelectedValue);

            balUserWiseMenu.Delete(UserID);

            foreach (RepeaterItem item in MenuList.Items)
            {
                HiddenField hfMenuID = (HiddenField)item.FindControl("hfMenuID");
                CheckBox cbMenuID = (CheckBox)item.FindControl("cbMenuID");

                if (cbMenuID.Checked)
                {
                    balUserWiseMenu.Insert(UserID, Convert.ToInt32(hfMenuID.Value));
                }
            }
        }
        #endregion SaveButton
    }
}