using MadhuramIndustries.App_Code.BAL;
using MadhuramIndustries.App_Code.ENT;
using MadhuramIndustries;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace MadhuramIndustries.App_Code
{
    public class CommonFillMethods
    {

        #region UserStatus
        public static void UserStatus(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("Activate", "False"));
            ddl.Items.Insert(1, new ListItem("Deactivate", "True"));
        }
        #endregion UserStatus

        #region User DropDown
        public static void FillDropDownListUser(DropDownList ddl)
        {
            UserBAL balUser = new UserBAL();
            DataTable dt = balUser.SelectForDropDown();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl.DataValueField = "UserID";
                ddl.DataTextField = "UserDisplayName";
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select User", "-1"));
            }
        }
        #endregion User DropDown

        #region Item DropDown
        public static void FillDropDownListItem(DropDownList ddl)
        {
            ItemBAL balItem = new ItemBAL();
            DataTable dt = balItem.SelectForDropDown();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl.DataValueField = "ItemID";
                ddl.DataTextField = "ItemName";
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select Item", "-1"));
            }
        }
        #endregion Item DropDown

        #region Party DropDown
        public static void FillDropDownListParty(DropDownList ddl)
        {
            PartyBAL balParty = new PartyBAL();
            DataTable dt = balParty.SelectForDropDown();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl.DataValueField = "PartyID";
                ddl.DataTextField = "PartyName";
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select Party", "-1"));
            }
        }
        #endregion Party DropDown

        #region Designation DropDown
        public static void FillDropDownListEmployeeDesignation(DropDownList ddl)
        {
            EmployeeDesignationBAL balEmployeeDesignation = new EmployeeDesignationBAL();
            DataTable dt = balEmployeeDesignation.SelectForDropDown();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl.DataValueField = "EmployeeDesignationID";
                ddl.DataTextField = "EmployeeDesignationName";
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select Designation", "-1"));
            }
        }
        #endregion Designation DropDown

        #region Employee DropDown
        public static void FillDropDownListEmployee(DropDownList ddl)
        {
            EmployeeBAL balEmployee = new EmployeeBAL();
            DataTable dt = balEmployee.SelectForDropDown();
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl.DataValueField = "EmployeeID";
                ddl.DataTextField = "EmployeeName";
                ddl.DataSource = dt;
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Select Employee", "-1"));
            }
        }
        #endregion Employee DropDown

    }
}