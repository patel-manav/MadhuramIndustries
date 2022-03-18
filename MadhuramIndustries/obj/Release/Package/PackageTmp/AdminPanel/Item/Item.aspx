<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="Item.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Item.Item" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Item</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <!-- Info boxes -->
            <div class="row">
                <asp:HiddenField runat="server" ID="hfItemID" />
                <div class="col-md-3 form-group">
                    Item Name*
                    <asp:Label runat="server" ID="lblItemName" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtItemName" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Item Code*
                    <asp:Label runat="server" ID="lblItemCode" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtItemCode" CssClass="form-control" AutoCompleteType="Disabled" />
                </div>

                <div class="col-md-3 form-group">
                    GST*
                    <asp:Label runat="server" ID="lblItemGST" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlItemGST" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group form-group">
                    Unit*
                    <asp:Label runat="server" ID="lblItemUnit" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlItemUnit" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group">
                    Remark
                    <asp:TextBox runat="server" ID="txtItemRemark" CssClass="form-control" AutoCompleteType="Disabled" />
                </div>

                <div class="col-md-3 ">
                    Status
                    <asp:DropDownList runat="server" ID="ddlItemStatus" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
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
                    <asp:GridView ID="gvItem" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowCommand="gvItem_RowCommand" OnPageIndexChanging="gvItem_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="ItemName" HeaderText="Name" />
                            <asp:BoundField DataField="ItemCode" HeaderText="Code" />
                            <asp:BoundField DataField="ItemGST" HeaderText="GST" />
                            <asp:BoundField DataField="ItemUnit" HeaderText="Unit" />
                            <asp:BoundField DataField="ItemRemark" HeaderText="Remark" />
                            <asp:BoundField DataField="FlagDelete" HeaderText="Status" />
                            <asp:BoundField DataField="ModifyBy" HeaderText="EntryBy" />

                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%# Eval("ItemID") %>' CssClass="fa fa-trash-alt mr-2 text-danger" runat="server"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnEdit" CommandName="EditRecord" CommandArgument='<%# Eval("ItemID") %>' CssClass="fas fa-edit text-warning" runat="server"></asp:LinkButton>
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
