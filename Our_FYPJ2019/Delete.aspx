<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="BackUpProject.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="gridviewStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <form runat="server">
        <h2>Listing Search</h2>
    <br />
        <div class="container">
            <asp:Label ID="lblResult" runat="server" Text="" ForeColor="#00CC00"></asp:Label><br />
    <asp:Label ID="lblusername" runat="server" Text="Username:" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="nameTb" runat="server" class="form-control"  placeholder="Username" aria-label="Search"></asp:TextBox>
    <br />
    <asp:Label ID="lblname" runat="server" Text="Item ID:" Font-Bold="True"></asp:Label>
    <asp:TextBox ID="itemTb" runat="server" class="form-control"  placeholder="Item ID" aria-label="Search"></asp:TextBox>
    <br />
    <asp:Button ID="searchBtn" runat="server" Text="Search" class="btn btn-primary" OnClick="searchBtn_Click"/>
            </div>
        <!--<asp:BoundField DataField="img1" HeaderText="Picture"></asp:BoundField>-->
    <br />
    <br />
       <asp:GridView ID="ListingGv" runat="server" CssClass="grid" AutoGenerateColumns="False" OnSelectedIndexChanged="ListingGv_SelectedIndexChanged" Width="100%">
        <Columns>
            <asp:BoundField HeaderText="Listing ID" DataField="itemid" ></asp:BoundField>
            <asp:BoundField HeaderText="Username" DataField="username" ></asp:BoundField>
            <asp:BoundField DataField="itemname" HeaderText="Item name"></asp:BoundField>
            <asp:BoundField DataField="dates" HeaderText="Date/Time"></asp:BoundField>          
            <asp:ImageField DataImageUrlField="img1" HeaderText="Image1" ControlStyle-Width="100" ControlStyle-Height = "100">
                           </asp:ImageField>
           <asp:ImageField DataImageUrlField="img2" HeaderText="Image2" ControlStyle-Width="100" ControlStyle-Height = "100">
                           </asp:ImageField>
            <asp:ImageField DataImageUrlField="img3" HeaderText="Image3" ControlStyle-Width="100" ControlStyle-Height = "100">
                           </asp:ImageField>
             
            <asp:BoundField DataField="descriptions" HeaderText="Descriptions"></asp:BoundField>
            <asp:CommandField HeaderText="Action" ShowSelectButton="True" SelectText="Delete Listing">
            </asp:CommandField>                
         
        </Columns> 
    </asp:GridView> 
    <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red" Font-Bold="True"></asp:Label>
    </form>
</asp:Content>
