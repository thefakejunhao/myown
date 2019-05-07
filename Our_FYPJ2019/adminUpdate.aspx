<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="adminUpdate.aspx.cs" Inherits="BackUpProject.adminUpdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="gridviewStyle.css" rel="stylesheet" />
    <style>
  .right{
      float:right;
  }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
<h2>Admin Update Listing Form</h2>
    <form runat="server">
        <div class="right">
            <div class="d-none d-md-inline-block form-inline ml-auto mr-0 mr-md-3 my-2 my-md-0">
      <div class="input-group">
         <!-- <asp:TextBox ID="searchTb" runat="server" class="form-control" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2"></asp:TextBox>
        <div class="input-group-append">
            <asp:Button ID="searchBtn" runat="server" Text="Search" class="btn btn-primary" OnClick="searchBtn_Click"/>-->
           <!-- <i class="fas fa-search"></i>-->   
  </div>
    </div>
   <!--   </div>-->
        </div>
     <!-- <div class="dropdown">
    <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" class="btn btn-primary dropdown-toggle" data-toggle="dropdown">
    </asp:DropDownList>-->

        <div class="btn">
 <button type="button" class="btn btn-light" data-toggle="modal" style="margin-bottom:10px; cursor:pointer;" data-target="#changepw_modal">Add</button>
        </div>
         
    <!-- Modal -->
  <div class="modal fade" id="changepw_modal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <h4 class="modal-title">Update form</h4><button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        
        <div class="modal-body">
           <h3></h3>
                     <asp:Label ID="lblname" runat="server" Text="Category:"></asp:Label>
                        <asp:TextBox ID="addNametb" runat="server" class="form-control"  placeholder="Add name" aria-label="Search" Width="200px"></asp:TextBox>
                        <asp:Label ID="lbltype" runat="server" Text="Type:"></asp:Label>
                        <asp:TextBox ID="addTypetb" runat="server" class="form-control"  placeholder="Add Type" aria-label="Search" Width="200px"></asp:TextBox>
        </div>
        <div class="modal-footer">
          <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" class="btn btn-light"/>
          <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
        </div>
      </div>
      
    </div>
  </div>
        <asp:Label ID="lblResult" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#33CC33"></asp:Label><br />
        <asp:Label ID="lblError" runat="server" Text="Label" ForeColor="#CC0000"></asp:Label><br />


        <asp:GridView ID="editGV" runat="server" AutoGenerateColumns="False" CssClass="grid" Width="100%" OnSelectedIndexChanged="editGV_SelectedIndexChanged" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True"  DataKeyNames="ID"  PageSize="7">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" sortExpression="ID" InsertVisible="False" ReadOnly="True" ></asp:BoundField> 
            <asp:BoundField HeaderText="Category" DataField="name" sortExpression="name"></asp:BoundField>
            <asp:BoundField HeaderText="rtype" DataField="rtype" sortExpression="rtype" ></asp:BoundField> 
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button" ControlStyle-CssClass="btn btn-primary"></asp:CommandField>
        </Columns>
        </asp:gridview>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:fypjConnectionString %>" SelectCommand="SELECT * FROM [adminEdit] where [rtype] IS NOT NULL or [rtype] IS NOT NULL" UpdateCommand="UPDATE [adminEdit] Set [rtype]=@rtype, [name]=@name where [ID]=@ID" DeleteCommand="DELETE FROM [adminEdit] WHERE [ID] =@ID">
            <DeleteParameters>
                <asp:Parameter Name="rtype" Type ="String" />
            </DeleteParameters>
        </asp:SqlDataSource>
       
</form>
        </div>
</asp:Content>
