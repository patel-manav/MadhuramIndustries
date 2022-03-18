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

namespace MadhuramIndustries.AdminPanel.Attendance
{
    public partial class Attendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null || Session["UserID"].ToString() == null)
            {
                Response.Redirect("../User/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                txtAttendanceDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FillGridView();
            }

        }

        #region Fill GridView
        private void FillGridView()
        {
            #region Variable
            EmployeeBAL balEmployee = new EmployeeBAL();
            #endregion Variable

            #region Bind Data
            DataTable dt = balEmployee.SelectAttendance(Convert.ToDateTime(txtAttendanceDate.Text));

            if (dt != null && dt.Rows.Count > 0)
            {
                rpEmployee.DataSource = dt;
                rpEmployee.DataBind();
            }
            else
            {
                rpEmployee.DataSource = null;
                rpEmployee.DataBind();
            }
            #endregion Bind Data
        }
        #endregion Fill GridView

        protected void txtAttendanceDate_TextChanged(object sender, EventArgs e)
        {
            FillGridView();
        }

        protected void rpEmployee_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName != null && e.CommandName == "SaveRecord")
            {
                #region Variable
                AttendanceBAL balAttendance = new AttendanceBAL();
                AttendanceENT entAttendance = new AttendanceENT();
                #endregion Variable

                if (e.CommandArgument != null && e.CommandArgument.ToString() != "")
                    entAttendance.EmployeeID = Convert.ToInt32(e.CommandArgument);

                if (txtAttendanceDate.Text.Trim() != "")
                    entAttendance.AttendanceDate = Convert.ToDateTime(txtAttendanceDate.Text.ToString());

                entAttendance.ModifyDate = DateTime.Now;
                entAttendance.ModifyBy = Convert.ToInt32(Session["UserID"]);
                entAttendance.CreateDate = DateTime.Now;
                entAttendance.CreateBy = Convert.ToInt32(Session["UserID"]);

                foreach (RepeaterItem item in rpEmployee.Items)
                {
                    #region Get Controls
                    HiddenField hfEmployeeID = (HiddenField)item.FindControl("hfEmployeeID");
                    HiddenField hfAttendanceID = (HiddenField)item.FindControl("hfAttendanceID");
                    TextBox txtInTime = (TextBox)item.FindControl("txtInTime");
                    TextBox txtOutTime = (TextBox)item.FindControl("txtOutTime");
                    TextBox txtOverTimeHours = (TextBox)item.FindControl("txtOverTimeHours");
                    #endregion Get Controls

                    if (hfEmployeeID != null && hfEmployeeID.Value != "" && hfEmployeeID.Value == e.CommandArgument.ToString())
                    {
                        #region Insert/Update

                        if (txtInTime != null && txtInTime.Text != "")
                            entAttendance.InTime = Convert.ToDateTime(txtInTime.Text);

                        if (txtOutTime != null && txtOutTime.Text != "")
                            entAttendance.OutTime = Convert.ToDateTime(txtOutTime.Text);

                        if (txtOverTimeHours != null && txtOverTimeHours.Text != "")
                            entAttendance.OverTimeHours = Convert.ToInt32(txtOverTimeHours.Text);

                        if (txtInTime != null && txtInTime.Text != "" && txtOutTime != null && txtOutTime.Text != "")
                            entAttendance.TotalWorkedHours = (decimal)(Convert.ToDateTime(txtOutTime.Text.Trim()) - Convert.ToDateTime(txtInTime.Text.Trim())).TotalHours;

                        if (hfAttendanceID != null && hfAttendanceID.Value != "")
                        {
                            entAttendance.AttendanceID = Convert.ToInt32(hfAttendanceID.Value);

                            if (balAttendance.Update(entAttendance))
                            {
                                FillGridView();
                                break;
                            }
                        }
                        else
                        {
                            if (balAttendance.Insert(entAttendance))
                            {
                                FillGridView();
                                break;
                            }
                        }
                        #endregion Insert/Update
                    }
                }
            }
        }
    }
}