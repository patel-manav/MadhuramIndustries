<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="Expense.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Expense.Expense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Expense</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <!-- Info boxes -->
            <div class="row">
                <asp:HiddenField runat="server" ID="hfExpenseID" />
                <div class="col-md-3 form-group">
                    Date
                    <asp:TextBox runat="server" TextMode="Date" ID="txtExpenseDate" CssClass="form-control"/>
                </div>

                <div class="col-md-3 form-group">
                    Item*
                    <asp:Label runat="server" ID="lblItem" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlItem" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group form-group">
                    Party*
                    <asp:Label runat="server" ID="lblParty" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlParty" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group">
                    Item Qty*
                    <asp:Label runat="server" ID="lblItemQuantity" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtItemQuantity" CssClass="form-control" AutoCompleteType="Disabled" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Remark
                    <asp:TextBox runat="server" ID="txtExpenseRemark" CssClass="form-control" AutoCompleteType="Disabled" />
                </div>

                <div class="col-md-3 ">
                    Status
                    <asp:DropDownList runat="server" ID="ddlExpenseStatus" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-2 offset-md-2 mt-4">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Style="width: 100%;" Text="Save" OnClick="btnSave_Click" />
                </div>
                <div class="col-md-2 mt-4">
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-secondary" Style="width: 100%;" Text="Clear" OnClick="btnClear_Click" />
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gvExpense" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowCommand="gvExpense_RowCommand" OnPageIndexChanging="gvExpense_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ExpenseDate" HeaderText="Date" />
                            <asp:BoundField DataField="ItemName" HeaderText="Item" />
                            <asp:BoundField DataField="PartyName" HeaderText="Party" />
                            <asp:BoundField DataField="ItemQuantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="ExpenseRemark" HeaderText="Remark" />
                            <asp:BoundField DataField="FlagDelete" HeaderText="Status" />
                            <asp:BoundField DataField="ModifyBy" HeaderText="EntryBy" />

                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%# Eval("ExpenseID") %>' CssClass="fa fa-trash-alt mr-2 text-danger" runat="server"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnEdit" CommandName="EditRecord" CommandArgument='<%# Eval("ExpenseID") %>' CssClass="fas fa-edit text-warning" runat="server"></asp:LinkButton>
                                </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="server"></asp:Content>
