<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeePenalty.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Employee.EmployeePenalty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Employee Penalty</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <!-- Info boxes -->
            <div class="row">
                <asp:HiddenField runat="server" ID="hfEmployeePenaltyID" />
                <div class="col-md-3 form-group">
                    Date
                    <asp:Label runat="server" ID="lblEmployeePenaltyDate" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" TextMode="Date" ID="txtEmployeePenaltyDate" CssClass="form-control"/>
                </div>
                <div class="col-md-3 form-group">
                    Employee*
                    <asp:Label runat="server" ID="lblEmployee" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlEmployee" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-3 form-group">
                    Amount*
                    <asp:Label runat="server" ID="lblEmployeePenaltyAmount" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEmployeePenaltyAmount" CssClass="form-control" AutoCompleteType="Disabled" onkeypress=" return numeric(event);"></asp:TextBox>
                </div>
                <div class="col-md-3 form-group">
                    Remark
                    <asp:TextBox runat="server" ID="txtEmployeePenaltyRemark" CssClass="form-control" ></asp:TextBox>
                </div>

                <div class="col-md-2 offset-md-8 form-group">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Style="width: 100%;" Text="Save" OnClick="btnSave_Click"/>
                </div>
                <div class="col-md-2  form-group">
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-secondary" Style="width: 100%;" Text="Clear" OnClick="btnClear_Click"/>
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gvEmployeePenalty" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvEmployeePenalty_PageIndexChanging" OnRowCommand="gvEmployeePenalty_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="EmployeePenaltyDate" HeaderText="Date" />
                            <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                            <asp:BoundField DataField="EmployeePenaltyAmount" HeaderText="Amount" />
                            <asp:BoundField DataField="EmployeePenaltyRemark" HeaderText="Remark" />
                            <asp:BoundField DataField="UserDisplayName" HeaderText="EntryBy" />

                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%# Eval("EmployeePenaltyID") %>' CssClass="fa fa-trash-alt mr-2 text-danger" runat="server"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnEdit" CommandName="EditRecord" CommandArgument='<%# Eval("EmployeePenaltyID") %>' CssClass="fas fa-edit text-warning" runat="server"></asp:LinkButton>
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
