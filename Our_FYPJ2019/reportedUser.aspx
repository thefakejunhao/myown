<%@ Page Title="" Language="C#" MasterPageFile="~/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="reportedUser.aspx.cs" Inherits="BackUpProject.reportedUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .btn1{
            float:right;
        }
           .btn2{
            float:right;         
        }
    </style>

    <link href="gridviewStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
  <div class="container">
      <form runat="server">
        <!--  <div class="btn1">
              &nbsp; 
              <asp:Button ID="btnChat" runat="server" Text="Chat" OnClick="btnChat_Click" class="btn btn-secondary btn-lg"/>               
              </div>-->
      <div class="btn2">
          <asp:Button ID="btnListing" runat="server" Text="Listing" OnClick="btnListing_Click" class="btn btn-secondary btn-lg"/>
      </div>
      <br />        
          <h3>
              <asp:Label ID="lblType" runat="server" Text=""></asp:Label>         
          </h3>
          <br />
          <asp:Label ID="lblGv" runat="server" Text=""></asp:Label>

               <button type="button" class="btn btn-light" data-toggle="modal" style="margin-bottom:10px; cursor:pointer;" data-target="#changepw_modal">Mark as false report</button>    
    <!-- Modal -->
          <div class="modal fade" id="changepw_modal" role="dialog">
              <div class="modal-dialog">

                  <!-- Modal content-->
                  <div class="modal-content">
                      <div class="modal-header">
                          <h4 class="modal-title">Delete report</h4>
                          <button type="button" class="close" data-dismiss="modal">&times;</button>
                      </div>

                      <div class="modal-body">
                          <h3></h3>
                          <asp:Label ID="lbl" runat="server" Text="Report ID:"></asp:Label>
                          <asp:TextBox ID="reportIDtb" runat="server" class="form-control" placeholder="" aria-label="Search" Width="200px"></asp:TextBox>

                      </div>
                      <div class="modal-footer">
                          <asp:Button ID="btnDelete" runat="server" Text="Delete"  class="btn btn-light" OnClick="btnDelete_Click" />
                          <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                      </div>
                  </div>

              </div>
          </div>
          <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
          <br />
          <div class="btn1">
              <asp:Label ID="Label1" runat="server" Text="Sort:"></asp:Label>
              <asp:DropDownList ID="ddlSort" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True">
                  <asp:ListItem Text="Most Reported" Value="Most Reported" Selected="True"></asp:ListItem>
                  <asp:ListItem Text="Least Reported" Value="Least Reported"></asp:ListItem>
                  <asp:ListItem Text="Recent" Value="Recent"></asp:ListItem>
              </asp:DropDownList>
              <br />
          </div>

          <asp:GridView ID="reportedListingUserGv" runat="server" CssClass="grid" AutoGenerateColumns="False" OnSelectedIndexChanged="reportedListingUserGv_SelectedIndexChanged" Width="100%" AllowPaging="True" PageSize="4" OnPageIndexChanging="reportedListingUserGv_PageIndexChanging">
              <Columns>
                  
                  <asp:BoundField HeaderText="Username" DataField="Name"></asp:BoundField>
                  <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                  <asp:BoundField HeaderText="Reason stated" DataField="ReasonStated"></asp:BoundField>
                  <asp:BoundField HeaderText="Report ID" DataField="listingID"></asp:BoundField>
                  <asp:BoundField HeaderText="Item Name" DataField="itemName"></asp:BoundField>
                  <asp:BoundField HeaderText="Total Reports" DataField="noOfReports"></asp:BoundField>
                  <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Show"></asp:CommandField>
              </Columns>
          </asp:GridView>    
          <asp:Label ID="lbldisplayPage" runat="server" Text=""></asp:Label>  
          

          <asp:GridView ID="reportedChatUserGv" runat="server" CssClass="grid" AutoGenerateColumns="False" Width="100%">
              <Columns>
            <asp:BoundField HeaderText="Username" DataField="Name" ></asp:BoundField>
            <asp:BoundField DataField="NRIC" HeaderText="NRIC"></asp:BoundField>
            <asp:BoundField DataField="Email"  HeaderText="Email"></asp:BoundField>      
            <asp:BoundField HeaderText="Reason stated" DataField="ReasonStated"></asp:BoundField>
            <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Show">
            </asp:CommandField>
                  </Columns>
          </asp:GridView>
          
        

</form>
    </div>

</asp:Content>
