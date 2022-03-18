using MadhuramIndustries.App_Code;
using System;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using MadhuramIndustries.App_Code.BAL;
using System.Data.SqlTypes;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;


namespace MadhuramIndustries.AdminPanel.Salary
{
    
    public partial class SalaryReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Set Default Value
                txtFromDate.Text = DateTime.Now.Date.AddDays(-7).ToString("yyyy-MM-dd");
                txtToDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FillDropDownList();
                #endregion Set Default Value
            }
        }

        #region FillDropDownList
        private void FillDropDownList()
        {
            CommonFillMethods.FillDropDownListEmployee(ddlEmployeeID);
        }
        #endregion FillDropDownList

        #region RDLC Report
        protected void btnReport_Click(object sender, EventArgs e)
        {
            #region Variable
            AttendanceBAL balAttendance = new AttendanceBAL();

            SqlDateTime FromDate = SqlDateTime.Null;
            SqlDateTime ToDate = SqlDateTime.Null;
            SqlInt32 EmployeeID = SqlInt32.Null;

            #endregion Variable

            #region Validation
            if (ddlEmployeeID.SelectedIndex == 0)
            {
                lblEmployeeID.Visible = true;
                return;
            }
            else
            {
                lblEmployeeID.Visible = false;
            }
            #endregion Validation

            #region GatherData
            FromDate = Convert.ToDateTime(txtFromDate.Text);
            ToDate = Convert.ToDateTime(txtToDate.Text);
            EmployeeID = Convert.ToInt32(ddlEmployeeID.SelectedValue);
            #endregion GatherData

            #region Bind Data
            DataTable dt = balAttendance.SelectForSalaryReport(FromDate, ToDate, EmployeeID);
            #endregion Bind Data

            string pathRdlc = @"M:\MadhuramIndustries\MadhuramIndustries\Reports\SalaryReport.rdlc";

            var report = new Microsoft.Reporting.WebForms.LocalReport();
            //ReportParameter[] paramater = new ReportParameter[2];
            //paramater[1] = new ReportParameter("EndDate", "tomorrow");

            byte[] fileBytes = System.IO.File.ReadAllBytes(pathRdlc);
            MemoryStream rs = new MemoryStream(fileBytes);

            Microsoft.Reporting.WebForms.ReportDataSource datasource = new Microsoft.Reporting.WebForms.ReportDataSource("SalaryReport", balAttendance.SelectForSalaryReport(FromDate, ToDate, EmployeeID));
            report.DataSources.Add(datasource);
            report.EnableExternalImages = true;
            report.LoadReportDefinition(rs);
            //report.SetParameters(paramater);

            var rpt = report.Render("PDF");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.AppendHeader("Content-Disposition", "attachment; filename=abc.pdf");
            Response.BinaryWrite(rpt);
            Response.Flush();
            Response.End();
        }
        #endregion RDLC Report

        //#region Normal Report
        //protected void btnReport_Click(object sender, EventArgs e)
        //{
        //    #region Variable
        //    AttendanceBAL balAttendance = new AttendanceBAL();

        //    SqlDateTime FromDate = SqlDateTime.Null;
        //    SqlDateTime ToDate = SqlDateTime.Null;
        //    SqlInt32 EmployeeID = SqlInt32.Null;

        //    #endregion Variable

        //    #region Validation
        //    if (ddlEmployeeID.SelectedIndex == 0)
        //    {
        //        lblEmployeeID.Visible = true;
        //        return;
        //    }
        //    else
        //    {
        //        lblEmployeeID.Visible = false;
        //    }
        //    #endregion Validation

        //    #region GatherData
        //    FromDate = Convert.ToDateTime(txtFromDate.Text);
        //    ToDate = Convert.ToDateTime(txtToDate.Text);
        //    EmployeeID = Convert.ToInt32(ddlEmployeeID.SelectedValue);
        //    #endregion GatherData

        //    #region Bind Data

        //    DataTable dt = balAttendance.SelectForSalaryReport(FromDate, ToDate, EmployeeID);

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        //gvLedgerReport.Visible = true;
        //        Session["LedgerReport"] = dt;
        //        gvSalaryReport.DataSource = dt;
        //        gvSalaryReport.DataBind();
        //        //pdf = true;
        //        //lblPDF.Visible = false;
        //        //SetCurrencyFormat();
        //    }
        //    #endregion Bind Data

        //    GeneratePDF();
        //}

        //#region PDF Generate Code
        //private void GeneratePDF()
        //{
        //    String path = $"M:\\MadhuramIndustries\\MadhuramIndustries\\SalaryReport.pdf";
        //    Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
        //    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
        //    pdfDoc.Open();
        //    Chunk glue = new Chunk(new VerticalPositionMark());
        //    Paragraph p = new Paragraph("MADHURAM INDUSTRIES");
        //    p.Font.Size = 20;
        //    p.Add(new Chunk(glue));
        //    DateTime now = DateTime.Now;
        //    string timenow = string.Format("{0:dd-MM-yyyy H:mm:ss}", now);
        //    p.Add("TIME : " + timenow);
        //    pdfDoc.Add(p);
        //    pdfDoc.Add(new Paragraph(" "));
        //    Paragraph p1 = new Paragraph("EMPLOYEE NAME : " + ddlEmployeeID.SelectedItem.ToString());
        //    pdfDoc.Add(p1);
        //    System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;
        //    DateTime dateTime = DateTime.Parse(txtFromDate.Text);
        //    string date = string.Format("{0:dd-MM-yyyy}", dateTime);

        //    DateTime dateTime1 = DateTime.Parse(txtToDate.Text);
        //    string date1 = string.Format("{0:dd-MM-yyyy}", dateTime1);

        //    Paragraph p2 = new Paragraph("REPORT DATE : " + date + " To " + date1);
        //    pdfDoc.Add(p2);
        //    pdfDoc.Add(new Paragraph(" "));
        //    if (Session["LedgerReport"] != null)
        //    {
        //        DataTable dt1 = (DataTable)Session["LedgerReport"];
        //        PdfPTable table = new PdfPTable(dt1.Columns.Count);
        //        Font fontH1 = new Font(Font.NORMAL, 12, Font.BOLD);
        //        Font fontB1 = new Font(Font.NORMAL, 10, Font.NORMAL);
        //        foreach (DataColumn c in dt1.Columns)
        //        {
        //            table.AddCell(new Phrase(c.ColumnName, fontH1));
        //        }
        //        foreach (DataRow r in dt1.Rows)
        //        {
        //            if (dt1.Rows.Count > 0)
        //            {
        //                table.AddCell(new Phrase(r["Date"].ToString(), fontB1));
        //                table.AddCell(new Phrase(r["Worked Hour"].ToString(), fontB1));
        //                table.AddCell(new Phrase(r["OverTime Hour"].ToString(), fontB1));
        //                //table.AddCell(new Phrase(r["Normal Salary"].ToString(), fontB1));
        //                //table.AddCell(new Phrase(r["OverTime Salary"].ToString(), fontB1));
        //                table.AddCell(new Phrase(r["Penalty Amount"].ToString(), fontB1));
        //                //table.AddCell(new Phrase(r["Total Paid Amount"].ToString(), fontB1));
        //                //table.AddCell(new Phrase(r["Balance"].ToString(), fontB1));
        //            }
        //        }
        //        table.WidthPercentage = 99;
        //        table.HorizontalAlignment = Element.ALIGN_CENTER;
        //        pdfDoc.Add(table);
        //        pdfDoc.Close();
        //        pdfWriter.Close();
        //        try
        //        {
        //            String path1 = $"M:\\MadhuramIndustries\\MadhuramIndustries\\SalaryReport.pdf";
        //            Response.ContentType = "Application/pdf";
        //            Response.AddHeader("Content-Disposition", "attachment;filename=" + ddlEmployeeID.SelectedItem.Text + " LedgerReport" + ".pdf");
        //            Response.WriteFile(path);
        //            Response.TransmitFile(Server.MapPath(path));
        //            Response.End();
        //        }
        //        catch (Exception)
        //        {

        //        }
        //    }
        //    Session["LedgerReport"] = null;
        //}
        //#endregion PDF Generate Code

        //#endregion Normal Report
    }
}
