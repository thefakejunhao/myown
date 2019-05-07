<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="adminBanning.aspx.cs" Inherits="BackUpProject.adminBanning" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="gridviewStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Ban User</h2>
    <form runat="server">
         <div class="container">
             <asp:Button ID="banListBtn" runat="server" Text="Banned List" OnClick="banListBtn_Click" class="btn btn-light" style="float:right;"/>
             <br />
             <br />
             <asp:TextBox ID="searchtb" runat="server" class="form-control" type="text" placeholder="Search by Name, Email or contact number" aria-label="Search"></asp:TextBox>
             <br />
    <asp:Button ID="searchBtn" runat="server" Text="Search" class="btn btn-light" OnClick="searchBtn_Click"/>
    <br /> 
    <br />
   <asp:Label ID="lblSearch" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Small"></asp:Label>
    <asp:GridView ID="CustomerGv" runat="server" CssClass="grid" AutoGenerateColumns="false" OnSelectedIndexChanged="CustomerSearch_SelectedIndexChanged" Width="100%" PageSize="5">
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="Name" ></asp:BoundField>
            <asp:BoundField DataField="Address"  HeaderText="Address"></asp:BoundField>
            <asp:BoundField DataField="unitNo"  HeaderText="Unit No"></asp:BoundField>
            <asp:BoundField HeaderText="Contact No" DataField="ContactNo" ></asp:BoundField>
            <asp:BoundField DataField="Email"  HeaderText="Email"></asp:BoundField>
            <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Ban Customer">
            </asp:CommandField>
        </Columns>
    </asp:GridView>           
    </div>
    </form>
   
</asp:Content>
