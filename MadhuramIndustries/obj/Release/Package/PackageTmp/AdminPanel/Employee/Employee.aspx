<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Employee.Employee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Employee</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <!-- Info boxes -->
            <div class="row">
                <asp:HiddenField runat="server" ID="hfEmployeeID" />
                <div class="col-md-3 form-group">
                    Name*
                    <asp:Label runat="server" ID="lblEmployeeName" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEmployeeName" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Card No
                    <%--<asp:Label runat="server" ID="lblEmployeeCardNumber" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>--%>
                    <asp:TextBox runat="server" ID="txtEmployeeCardNumber" CssClass="form-control" AutoCompleteType="Disabled" />
                </div>
                
                <div class="col-md-3 form-group">
                    Mobile No*
                    <asp:Label runat="server" ID="lblEmployeeMobileNumber" Visible="false" ForeColor="Red" Font-Bold="true" Text=" This Field Is Required"></asp:Label>
                    <asp:Label runat="server" ID="lblEmployeeMobileDigit" Visible="false" ForeColor="Red" Font-Bold="true" Text=" Only 10 Digit Number"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEmployeeMobileNumber" CssClass="form-control" MaxLength="10" oncopy="return false" onpaste="return false" oncut="return false" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    City
                    <asp:TextBox runat="server" ID="txtEmployeeCity" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>
                
                <div class="col-md-3 form-group">
                    DOB*
                    <asp:Label runat="server" ID="lblEmployeeDOB" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" TextMode="Date" ID="txtEmployeeDOB" CssClass="form-control"/>
                </div>

                <div class="col-md-3 form-group">
                    Address
                    <%--<asp:Label runat="server" ID="lblEmployeeAddress" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>--%>
                    <asp:TextBox runat="server" ID="txtEmployeeAddress" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Gender*
                    <asp:Label runat="server" ID="lblEmployeeGender" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlEmployeeGender" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group">
                    Salary*
                    <asp:Label runat="server" ID="lblEmployeeSalary" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEmployeeSalary" CssClass="form-control" AutoCompleteType="Disabled" oncopy="return false" onpaste="return false" oncut="return false" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Work Time*
                    <asp:Label runat="server" ID="lblEmployeeWorkTime" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEmployeeWorkTime" CssClass="form-control" AutoCompleteType="Disabled" oncopy="return false" onpaste="return false" oncut="return false" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Over Time Salary*
                    <asp:Label runat="server" ID="lblEmployeeOverTimeSalary" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:TextBox runat="server" ID="txtEmployeeOverTimeSalary" CssClass="form-control" AutoCompleteType="Disabled" oncopy="return false" onpaste="return false" oncut="return false" onkeypress=" return numeric(event);"/>
                </div>

                <div class="col-md-3 form-group">
                    Designation*
                    <asp:Label runat="server" ID="lblEmployeeDesignation" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlDesignation" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group">
                    ID Type*
                    <asp:Label runat="server" ID="lblEmployeeIDType" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <asp:DropDownList runat="server" ID="ddlEmployeeIDProofType" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                </div>

                <div class="col-md-3 form-group">
                    ID Proof*
                    <asp:Label runat="server" ID="lblEmployeeIDProof" Visible="false" ForeColor="Red" Font-Bold="true" Text="  This Field Is Required"></asp:Label>
                    <br />
                    <asp:HiddenField runat="server" ID="hfEmployeeIDProof" />
                    <asp:FileUpload runat="server" ID="fuEmployeeIDProof"/>                    
                </div>


                <div class="col-md-3 form-group">
                    Remark
                    <asp:TextBox runat="server" ID="txtEmployeeRemark" CssClass="form-control" AutoCompleteType="Disabled"/>
                </div>

                <div class="col-md-3 form-group">
                    Status
                    <asp:DropDownList runat="server" ID="ddlEmployeeStatus" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
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
                    <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-hover" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvEmployee_PageIndexChanging" OnRowCommand="gvEmployee_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                            <asp:BoundField DataField="EmployeeCardNumber" HeaderText="Card No" />
                            <asp:BoundField DataField="EmployeeMobileNumber" HeaderText="Mobile No" />
                            <asp:BoundField DataField="EmployeeCity" HeaderText="City" />
                            <%--<asp:BoundField DataField="EmployeeDOB" HeaderText="DOB" />--%>
                            <%--<asp:BoundField DataField="EmployeeAddress" HeaderText="Address" />--%>
                            <asp:BoundField DataField="EmployeeGender" HeaderText="Gender" />
                            <asp:BoundField DataField="EmployeeSalary" HeaderText="Salary" />
                            <asp:BoundField DataField="EmployeeWorkTime" HeaderText="Work Hour" />
                            <asp:BoundField DataField="EmployeeOverTimeSalary" HeaderText="Over Time Sal." />
                            <asp:BoundField DataField="EmployeeDesignationname" HeaderText="Designation" />
                            <%--<asp:BoundField DataField="EmployeeIDProofType" HeaderText="ID Type" />--%>
                            <asp:BoundField DataField="EmployeeRemark" HeaderText="Remark" />
                            <asp:BoundField DataField="FlagDelete" HeaderText="Status" />
                            <asp:BoundField DataField="ModifyBy" HeaderText="EntryBy" />

                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%--<asp:LinkButton ID="btnDelete" CommandName="DeleteRecord" CommandArgument='<%# Eval("EmployeeID") %>' CssClass="fa fa-trash-alt mr-2 text-danger" runat="server"></asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnEdit" CommandName="EditRecord" CommandArgument='<%# Eval("EmployeeID") %>' CssClass="fas fa-edit text-warning" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDownload" CommandName="Download" CommandArgument='<%# Eval("EmployeeID") %>' CssClass="fas fa-download text-success" runat="server" ></asp:LinkButton>
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

