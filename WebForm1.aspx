<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="web.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hfCustID" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Name" runat="server" Text="Name">Name:</asp:Label>
                    </td>
                     <td>
                         <asp:TextBox ID="txtName" runat="server" placeholder="Enter name"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label">Mobile</asp:Label>
                    </td>
                     <td>
                         <asp:TextBox ID="txtmobile" runat="server" placeholder="+917348 768 908  "></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label">Adress</asp:Label>
                    </td>
                     <td>
                         <asp:TextBox ID="txtadress" runat="server" placeholder="Enter Adress"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        
                    </td>
                     <td colspan="2">
                         <asp:Button ID="btSave" runat="server" Text="Save" OnClick="btSave_Click" />
                         <asp:Button ID="btDel" runat="server" Text="Delete" OnClick="btDel_Click" />
                         <asp:Button ID="btClear" runat="server" Text="Clear" OnClick="btClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                     <td colspan="2">
                         <asp:Label ID="lblsuccessmsg" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                     <td colspan="2">
                         <asp:Label ID="lblerrormsg" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                </table>
            <br />
            <asp:GridView ID="gvdetails" runat="server" AutoGenerateColumns="false">
            <columns>
                <asp:BoundField Datafield="Name" HeaderText="Name" />
                <asp:BoundField Datafield="Mobile" HeaderText="Mobile" />
                <asp:BoundField Datafield="Adress" HeaderText="Adress" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkview" runat="server" CommandArgument='<%# Eval("CustID") %>' OnClick="lnk_OnClick">View</asp:LinkButton>
                         </ItemTemplate>
                    </asp:TemplateField>
            </columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
