<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="MadhuramIndustries.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.MadhuramIndustries.MadhuramIndustries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Madhuram Industries</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <!-- Info boxes -->
            <div class="row">
                <asp:HiddenField runat="server" ID="hfMadhuramIndustriesID" />
                <div class="col-md-3 form-group">
                    Name*
                    <asp:Label runat="server" ID="lblMadhuramIndustriesName" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesName" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Address*
                    <asp:Label runat="server" ID="lblMadhuramIndustriesAddress" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesAddress" CssClass="form-control" AutoCompleteType="Disabled" />
                </div>
                
                <div class="col-md-3 form-group">
                    GST No*
                    <asp:Label runat="server" ID="lblMadhuramIndustriesGSTNumber" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesGSTNumber" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>
                
                <div class="col-md-3 form-group">
                    PanCard No
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesPanCardNumber" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Mobile No*
                    <asp:Label runat="server" ID="lblMadhuramIndustriesMobileNumber" Visible="false" ForeColor="Red" Font-Bold="true" Text=" This Field Is Required"></asp:Label>
                    <asp:Label runat="server" ID="lblMadhuramIndustriesMobileDigit" Visible="false" ForeColor="Red" Font-Bold="true" Text=" Only 10 Digit Number"></asp:Label>
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesMobileNumber" CssClass="form-control" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Bank Name*
                    <asp:Label runat="server" ID="lblMadhuramIndustriesBankName" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesBankName" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    IFSC Code*
                    <asp:Label runat="server" ID="lblMadhuramIndustriesBankIFSCCode" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesBankIFSCCode" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Account No*
                    <asp:Label runat="server" ID="lblMadhuramIndustriesBankAccountNumber" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesBankAccountNumber" CssClass="form-control" AutoCompleteType="Disabled" oncopy="return false" onpaste="return false" oncut="return false" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Branch Address*
                    <asp:Label runat="server" ID="lblMadhuramIndustriesBankBranchAddress" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesBankBranchAddress" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Remark
                    <asp:TextBox runat="server" ID="txtMadhuramIndustriesRemark" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Status
                    <asp:DropDownList runat="server" ID="ddlMadhuramIndustriesStatus" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
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
                    <asp:GridView ID="gvMadhuramIndustries" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvMadhuramIndustries_PageIndexChanging" OnRowCommand="gvMadhuramIndustries_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="MadhuramIndustriesName" HeaderText="Name" />
                            <asp:BoundField DataField="MadhuramIndustriesAddress" HeaderText="Address" />
                            <asp:BoundField DataField="MadhuramIndustriesGSTNumber" HeaderText="GST No" />
                            <asp:BoundField DataField="MadhuramIndustriesPanCardNumber" HeaderText="PanCard No" />
                            <asp:BoundField DataField="MadhuramIndustriesMobileNumber" HeaderText="Mobile No" />
                            <asp:BoundField DataField="MadhuramIndustriesBankName" HeaderText="Bank Name" />
                            <asp:BoundField DataField="MadhuramIndustriesBankIFSCCode" HeaderText="IFSC Code" />
                            <asp:BoundField DataField="MadhuramIndustriesBankAccountNumber" HeaderText="Account No" />
                            <asp:BoundField DataField="MadhuramIndustriesBankBranchAddress" HeaderText="Bank Address" />
                            <asp:BoundField DataField="MadhuramIndustriesRemark" HeaderText="Remark" />
                            <asp:BoundField DataField="FlagDelete" HeaderText="Status" />
                            <asp:BoundField DataField="ModifyBy" HeaderText="EntryBy" />

                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%# Eval("MadhuramIndustriesID") %>' CssClass="fa fa-trash-alt mr-2 text-danger" runat="server"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnEdit" CommandName="EditRecord" CommandArgument='<%# Eval("MadhuramIndustriesID") %>' CssClass="fas fa-edit text-warning" runat="server"></asp:LinkButton>
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