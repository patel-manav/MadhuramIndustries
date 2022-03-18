<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeDesignation.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Employee.EmployeeDesignation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Employee Designation</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <!-- Info boxes -->
            <div class="row">
                <asp:HiddenField runat="server" ID="hfEmployeeDesignationID" />
                <div class="col-md-3 form-group">
                    Designation Name*
                    <asp:Label runat="server" ID="lblEmployeeDesignationName" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEmployeeDesignationName" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 ">
                    Status
                    <asp:DropDownList runat="server" ID="ddlEmployeeDesignationStatus" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-2 mt-4">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Style="width: 100%;" Text="Save" OnClick="btnSave_Click"/>
                </div>

                <div class="col-md-2 mt-4">
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-secondary" Style="width: 100%;" Text="Clear" OnClick="btnClear_Click"/>
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gvEmployeeDesignation" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvEmployeeDesignation_PageIndexChanging" OnRowCommand="gvEmployeeDesignation_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="EmployeeDesignationName" HeaderText="Designation Name" />
                            <asp:BoundField DataField="FlagDelete" HeaderText="Status" />
                            <asp:BoundField DataField="ModifyBy" HeaderText="EntryBy" />

                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%# Eval("EmployeeDesignationID") %>' CssClass="fa fa-trash-alt mr-2 text-danger" runat="server"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnEdit" CommandName="EditRecord" CommandArgument='<%# Eval("EmployeeDesignationID") %>' CssClass="fas fa-edit text-warning" runat="server"></asp:LinkButton>
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>

