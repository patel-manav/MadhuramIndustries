<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inward.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Inward.Inward" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Inward</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <!-- Info boxes -->
            <div class="row">
                <asp:HiddenField runat="server" ID="hfInwardID" />
                <div class="col-md-3 form-group">
                    Date
                    <asp:TextBox runat="server" TextMode="Date" ID="txtInwardDate" CssClass="form-control" />
                </div>

                <div class="col-md-3 form-group">
                    Party*
                    <asp:Label runat="server" ID="lblParty" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlParty" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group">
                    Item*
                    <asp:Label runat="server" ID="lblItem" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlItem" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group form-group">
                    Quantity*
                    <asp:Label runat="server" ID="lblInwardQuantity" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtInwardQuantity" CssClass="form-control" AutoCompleteType="Disabled" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Remark
                    <asp:TextBox runat="server" ID="txtInwardRemark" CssClass="form-control" AutoCompleteType="Disabled" />
                </div>

                <div class="col-md-2 offset-md-5 mt-4">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Style="width: 100%;" Text="Add" OnClick="btnAdd_Click" />
                </div>

                <div class="col-md-2 mt-4">
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-secondary" Style="width: 100%;" Text="Clear" OnClick="btnClear_Click" />
                </div>
            </div>

            <div class="row">
                <div class="col-md-2 offset-md-10">
                    <asp:Button ID="btnSave" runat="server" Visible="false" CssClass="btn btn-primary" Style="width: 100%;" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>

            <div class="row mt-5" id="divDatatable" runat="server" visible="false">
                <div class="col-md-12 table-responsive">
                    <table class="table table-hover table-bordered">
                        <thead class="bg-light">
                            <asp:HiddenField ID="hfKey" runat="server" Value="" />
                            <th>Sr no.</th>
                            <th>Item</th>
                            <th>Quantity</th>
                            <th>Remark</th>
                            <th>Action</th>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand" Visible="false">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#Eval("Key") %>
                                        </td>
                                        <td>
                                            <%#Eval("Item") %>
                                        </td>
                                        <td>
                                            <%#Eval("Quantity") %>
                                        </td>
                                        <td>
                                            <%#Eval("Remark") %>
                                        </td>
                                        <td class="text-center">
                                            <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="fas fa-edit text-warning mr-2" CommandArgument='<%#Eval("Key") %>' CommandName="EditRecord"></asp:LinkButton>
                                            <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="fas fa-trash-alt text-danger" CommandArgument='<%#Eval("Key") %>' CommandName="DeleteRecord"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="row mt-5">
                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gvInward" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowCommand="gvInward_RowCommand" OnPageIndexChanging="gvInward_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="InwardDate" HeaderText="Date" />
                            <asp:BoundField DataField="PartyName" HeaderText="Party" />
                            <asp:BoundField DataField="ItemName" HeaderText="Item" />
                            <asp:BoundField DataField="InwardQuantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="InwardRemark" HeaderText="Remark" />
                            <asp:BoundField DataField="ModifyBy" HeaderText="EntryBy" />

                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%# Eval("InwardID") %>' CssClass="fa fa-trash-alt mr-2 text-danger" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="btnEdit" CommandName="EditRecord" CommandArgument='<%# Eval("InwardID") %>' CssClass="fas fa-edit text-warning" runat="server"></asp:LinkButton>
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
