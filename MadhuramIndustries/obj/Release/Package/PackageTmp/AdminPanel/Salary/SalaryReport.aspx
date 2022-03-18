<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="SalaryReport.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Salary.SalaryReport" %>

<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>
<%--<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Salary Report</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    From Date
                    <asp:TextBox runat="server" ID="txtFromDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    To Date
                    <asp:TextBox runat="server" ID="txtToDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    Employee*
                    <asp:Label runat="server" ID="lblEmployeeID" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlEmployeeID" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>
                <div class="col-md-2 mt-4">
                    <asp:Button runat="server" ID="btnReport" Text="Generate PDF" OnClick="btnReport_Click" CssClass="btn btn-primary" Style="width: 100%;" />
                </div>
            </div>
            <asp:ScriptManager ID="smSalaryReport" runat="server"></asp:ScriptManager>
            <%--<rsweb:ReportViewer ID="rvSalaryReport" runat="server"></rsweb:ReportViewer>--%>
            <div class="row mt-5">
                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gvSalaryReport" runat="server" CssClass="table table-hover">
                    </asp:GridView>
                </div>
            </div>

        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
