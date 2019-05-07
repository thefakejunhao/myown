<%@ Page Title="" Language="C#" MasterPageFile="~/adminLoginMasterpage.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="BackUpProject.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">  
    <div>
            <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Admin Login</div>
      <div class="card-body">
          <div class="form-group">
            <div class="form-label-group">
             <asp:TextBox ID="usertb" runat="server"  ></asp:TextBox> 
             <label for="usertb">Username</label>
            </div>
          </div>
          <div class="form-group">
            <div class="form-label-group">
              <asp:TextBox ID="passwordtb" runat="server" TextMode="Password" ></asp:TextBox> 
             <label for="passwordtb">Password</label>
            </div>
          </div>
         <asp:Button ID="loginbtn" runat="server" Text="Login" class="btn btn-primary" OnClick="loginbtn_Click"/>
        <div class="text-center">
          <asp:Label ID="lblError" runat="server" Text="" Font-Bold="true" ForeColor="Red" Font-Size="Medium"> </asp:Label>
         <!-- <a class="d-block small" href="#">Forgot Password?</a>-->
        </div>
      </div>
    </div>
  </div>
          </div>
  </form>
</asp:Content>
