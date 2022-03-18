<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="Party.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Party.Party" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Party</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <!-- Info boxes -->
            <div class="row">
                <asp:HiddenField runat="server" ID="hfPartyID" />
                <div class="col-md-3 form-group">
                    Name*
                    <asp:Label runat="server" ID="lblPartyName" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPartyName" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Address*
                    <asp:Label runat="server" ID="lblPartyAddress" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPartyAddress" CssClass="form-control" AutoCompleteType="Disabled" />
                </div>
                
                <div class="col-md-3 form-group">
                    GST No*
                    <asp:Label runat="server" ID="lblPartyGSTNumber" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPartyGSTNumber" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>
                
                <div class="col-md-3 form-group">
                    PanCard No
                    <asp:TextBox runat="server" ID="txtPartyPanCardNumber" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Mobile No*
                    <asp:Label runat="server" ID="lblPartyMobileNumber" Visible="false" ForeColor="Red" Font-Bold="true" Text=" This Field Is Required"></asp:Label>
                    <asp:Label runat="server" ID="lblPartyMobileDigit" Visible="false" ForeColor="Red" Font-Bold="true" Text=" Only 10 Digit Number"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPartyMobileNumber" CssClass="form-control" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Bank Name*
                    <asp:Label runat="server" ID="lblPartyBankName" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPartyBankName" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    IFSC Code*
                    <asp:Label runat="server" ID="lblPartyBankIFSCCode" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPartyBankIFSCCode" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Account No*
                    <asp:Label runat="server" ID="lblPartyBankAccountNumber" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPartyBankAccountNumber" CssClass="form-control" AutoCompleteType="Disabled" oncopy="return false" onpaste="return false" oncut="return false" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Branch Address*
                    <asp:Label runat="server" ID="lblPartyBankBranchAddress" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtPartyBankBranchAddress" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Remark
                    <asp:TextBox runat="server" ID="txtPartyRemark" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Status
                    <asp:DropDownList runat="server" ID="ddlPartyStatus" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-1 mt-4 offset-md-1">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Style="width: 100%;" Text="Save" OnClick="btnSave_Click"/>
                </div>

                <div class="col-md-1 mt-4">
                    <asp:Button ID="btnClear" runat="server" CssClass="btn btn-secondary" Style="width: 100%;" Text="Clear" OnClick="btnClear_Click"/>
                </div>
            </div>

            <div class="row mt-5">
                <div class="col-md-12 table-responsive">
                    <asp:GridView ID="gvParty" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvParty_PageIndexChanging" OnRowCommand="gvParty_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="PartyName" HeaderText="Name" />
                            <asp:BoundField DataField="PartyAddress" HeaderText="Address" />
                            <asp:BoundField DataField="PartyGSTNumber" HeaderText="GST No" />
                            <asp:BoundField DataField="PartyPanCardNumber" HeaderText="PanCard No" />
                            <asp:BoundField DataField="PartyMobileNumber" HeaderText="Mobile No" />
                            <asp:BoundField DataField="PartyBankName" HeaderText="Bank Name" />
                            <asp:BoundField DataField="PartyBankIFSCCode" HeaderText="IFSC Code" />
                            <asp:BoundField DataField="PartyBankAccountNumber" HeaderText="Account No" />
                            <asp:BoundField DataField="PartyBankBranchAddress" HeaderText="Bank Address" />
                            <asp:BoundField DataField="PartyRemark" HeaderText="Remark" />
                            <asp:BoundField DataField="FlagDelete" HeaderText="Status" />
                            <asp:BoundField DataField="ModifyBy" HeaderText="EntryBy" />

                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%# Eval("PartyID") %>' CssClass="fa fa-trash-alt mr-2 text-danger" runat="server"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnEdit" CommandName="EditRecord" CommandArgument='<%# Eval("PartyID") %>' CssClass="fas fa-edit text-warning" runat="server"></asp:LinkButton>
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
