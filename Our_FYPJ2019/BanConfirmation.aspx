<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="BanConfirmation.aspx.cs" Inherits="BackUpProject.BanConfirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <form runat="server">
  <h2>Ban User</h2>
  <table class="table table-bordered" >
    <thead>
    </thead>
    <tbody>
      <tr>
        <td>Name:</td>
        <td><asp:Label ID="lblName" runat="server" Text="Label"></asp:Label> </td>
      </tr>
      <tr>
        <td>Address:</td>
        <td><asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>  </td>
      </tr>
            <tr>
        <td>Unit No:</td>
        <td><asp:Label ID="lblArea" runat="server" Text="Label"></asp:Label></td>
      </tr>
      <tr>
        <td>Contact number:</td>
        <td> <asp:Label ID="lblContact" runat="server" Text="Label"></asp:Label>  </td>
      </tr>
      <tr>
        <td>Email:</td>
        <td><asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
      </tr>
       <tr>
        <td>Reason:</td>
        <td><asp:TextBox ID="reasontb" runat="server"></asp:TextBox></td>
      </tr>
      <tr>
        <td>Ban by:</td>
        <td>
            <asp:Label ID="lbladmin" runat="server" Text=""></asp:Label></td>
      </tr>



    </tbody>
  </table>
      
 <asp:Button ID="banBtn" runat="server" class="btn btn-light" Text="Ban" OnClick="banBtn_Click" />
<asp:Label ID="ErrorMsg" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>     
  </form>
</div>
</asp:Content>
