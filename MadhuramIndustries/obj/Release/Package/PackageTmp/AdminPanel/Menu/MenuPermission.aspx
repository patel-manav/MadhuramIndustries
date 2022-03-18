<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="MenuPermission.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Menu.MenuPermission" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Menu Permission</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4">
                    User*
                    <asp:DropDownList runat="server" ID="ddlUserID" OnSelectedIndexChanged="ddlUserID_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="col-md-1 mt-4">
                    <asp:Button ID="Save" runat="server" CssClass="btn btn-primary" Style="width: 100%;" Text="Save" OnClick="Save_Click" />
                </div>

            </div>

            <div class="row mt-5">
                <div class="col-md-12 table-responsive">

                    <table class="table table-hover" border="1">
                            <tr>
                                <th class="col-md-1 text-center">
                                    Sr.
                                </th>
                                <th class="col-md-3 text-center">
                                    Menu
                                </th>
                                <th>

                                </th> 
                            </tr>
                        <tbody>
                            <asp:Repeater ID="MenuList" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-center">
                                            <%# Container.ItemIndex + 1 %>
                                        </td>
                                        <td class="text-center">
                                            <%#Eval("MenuName") %>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="cbMenuID" runat="server" Checked='<%#Eval("UserWiseMenuID").ToString() != String.Empty? true:false %>' />
                                            <asp:HiddenField ID="hfMenuID" runat="server" Value='<%#Eval("MenuID")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
