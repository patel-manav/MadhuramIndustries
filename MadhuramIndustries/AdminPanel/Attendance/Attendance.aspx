<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MasterPage.Master" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="MadhuramIndustries.AdminPanel.Attendance.Attendance" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="server">
    <h1 class="m-0 text-dark">Attendance</h1>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainContent" runat="server">
    <section class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-3">
                    Date*
                    <asp:TextBox runat="server" ID="txtAttendanceDate" TextMode="Date" OnTextChanged="txtAttendanceDate_TextChanged" AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-12 table-responsive mt-5">                    
                    <table class="table table-hover" border="1">
                        <tr>
                            <th class=" text-center">Sr.
                            </th>
                            <th class=" text-center">Employee
                            </th>
                            <th class=" text-center">InTime
                            </th>
                            <th class=" text-center">OutTime
                            </th>
                            <th class=" text-center">TotalHour
                            </th>
                            <th class=" text-center">OverTime
                            </th>
                            <th class=" text-center">Status
                            </th>
                            <th class=" text-center">Action
                            </th>
                        </tr>
                        <tbody>
                            <asp:Repeater ID="rpEmployee" runat="server" OnItemCommand="rpEmployee_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td class="text-center">
                                            <%# Container.ItemIndex + 1 %>
                                        </td>
                                        <td class="text-center">
                                            <%#Eval("EmployeeName") %>
                                            <asp:HiddenField runat="server" ID="hfEmployeeID" Value='<%#Eval("EmployeeID") %>' />
                                            <asp:HiddenField runat="server" ID="hfAttendanceID" Value='<%#Eval("AttendanceID") %>'/>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtInTime" Text='<%#Eval("InTime").ToString() == ""? "": Convert.ToDateTime(Eval("InTime")).ToString("HH:mm") %>' TextMode="Time" CssClass="form-control"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtOutTime" Text='<%#Eval("OutTime").ToString() == ""? "": Convert.ToDateTime(Eval("OutTime")).ToString("HH:mm") %>' TextMode="Time" CssClass="form-control" Enabled='<%#Eval("InTime").ToString()==""?false: true %>'></asp:TextBox>
                                        </td>
                                        <td class="text-center">
                                            <%#Eval("TotalWorkedHours") %>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtOverTimeHours" CssClass="form-control" Text='<%#Eval("OverTimeHours") %>' onkeypress=" return numeric(event);"></asp:TextBox>
                                        </td>
                                        <td class="text-center">
                                            <asp:Label runat="server" ID="lblStatus" Text='<%#Eval("OutTime").ToString() == "" && Eval("InTime").ToString() != "" ? "In":"Out" %>'></asp:Label>
                                        </td>
                                        <td class="text-center">
                                            <asp:LinkButton runat="server" ID="lbtnSave" Text="Save" CommandArgument='<%#Eval("EmployeeID") %>' CommandName="SaveRecord" CssClass="btn btn-primary"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                        <dx:aspxreportdesigner runat="server"></dx:aspxreportdesigner>
                    </table>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphScript" runat="server">
</asp:Content>
