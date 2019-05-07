<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="BannedList.aspx.cs" Inherits="BackUpProject.BannedList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="gridviewStyle.css" rel="stylesheet" />
        <style>
  .right{
      float:right;
  }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>
        Banned User List 
    </h2>
    <asp:Label ID="banResult" runat="server" Text="" Font-Bold="True" Font-Size="Medium" ForeColor="#66FF66"></asp:Label>
    <br />
    <br />
    <form runat="server">
    <div class="container">
                <div class="right">
            <div class="d-none d-md-inline-block form-inline ml-auto mr-0 mr-md-3 my-2 my-md-0">
      <div class="input-group">
          <asp:TextBox ID="searchTb" runat="server" class="form-control" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2"></asp:TextBox>
        <div class="input-group-append">
            <asp:Button ID="searchBtn" runat="server" Text="Search" class="btn btn-primary" onClick="searchBtn_Click"/>
           <!-- <i class="fas fa-search"></i>-->   
  </div>
    </div>
      </div>
        </div>
        <br />
        <br />
        <asp:GridView ID="BannedGriDView" runat="server" CssClass="grid" AutoGenerateColumns="false" Width="100%" OnSelectedIndexChanged="BannedGriDView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="Name" ></asp:BoundField>
            <asp:BoundField DataField="Address"  HeaderText="Address"></asp:BoundField>
            <asp:BoundField HeaderText="Contact No" DataField="ContactNo" ></asp:BoundField>
            <asp:BoundField HeaderText="Email" DataField="Email" ></asp:BoundField>
            <asp:BoundField DataField="Reason"  HeaderText="Reason"></asp:BoundField>
            <asp:BoundField DataField="adminBan"  HeaderText="Banned By"></asp:BoundField>
            <asp:BoundField DataField="date"  HeaderText="Date/Time"></asp:BoundField>
            <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Unban User">
            </asp:CommandField>
        </Columns>
                </asp:GridView>          

    </div>
    </form>
</asp:Content>
