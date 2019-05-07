<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Quotation.aspx.cs" Inherits="Our_FYPJ2019.Quotation" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
<style>
    .coverimage
{   
    width:100px;
    height:80px;
    padding:0px
}

    .hiddencol
  {
    display: none;
  }
</style>     

     <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
   <script>
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container">
        <br />
        <h3>Quotation</h3>
        <br />

        <%--<form id="form2" runat ="server">--%>
            
            <div class="row">

                <div class ="col-sm-4">
                    <% if (status == "seller") { %>
                    <asp:Label ID="Label1" runat="server" Text="Search by Item : "></asp:Label>
                    <% } else if (status == "buyer") { %>
                    <asp:Label ID="Label2" runat="server" Text="Search by Item : "></asp:Label>
                    <% } %>
                    <div class="input-group mb-3">
                       
                        <asp:TextBox ID="tbsearch" CssClass="form-control" runat="server"></asp:TextBox>                        
                        <div class="input-group-append">
                            <asp:Button ID="searchbutton" runat="server" Text="search" CssClass ="btn btn-success" OnClick="searchbutton_Click" />
                        </div>
                    </div>
                </div>

                <div class="col-sm-3">
                    <asp:Label runat="server" for="ddlstatus" ID="lblstatus" CssClass="control-label" Text="Quotation status : ">
                    </asp:Label>
                    <div class="input-group mb-3">
                        <asp:DropDownList ID="ddlstatus" CssClass ="form-control" runat="server">
                            <asp:ListItem Selected ="True" Value ="" ></asp:ListItem>
                            <asp:ListItem Text= "unaccepted" Value ="1"></asp:ListItem>
                            <asp:ListItem Text= "accepted" Value ="2"></asp:ListItem>
                        </asp:DropDownList>
                        <div class="input-group-append">
                            <asp:Button ID="BtnFilter" runat="server" Text="Filter" CssClass ="btn btn-success" OnClick="BtnFilter_Click" />
                        </div>
                    </div>
                </div>
            </div>
        
            
                <div class="row">

                <br />
                <% if (quoteList != null) { %>                   
                        
                    <div class="col-sm-12">
                        <br />
                        <div class="card">
                            
                                <h6 class="card-header" id="unaccept" runat="server" visible="false">Unaccepted Quotations</h6>
                           
                                <h6 class="card-header" id="accept" runat="server" visible="false">Accepted Quotations</h6>
                            
                            <div class="card-body" style="width:100%">
                                
                                <asp:GridView ID="QgridView" AutoGenerateColumns="False" CssClass="table table-bordered" 
                                AllowPaging="True" PageSize="10" BackColor="White" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" 
                                    GridLines="None" runat="server" OnRowCommand="QgridView_RowCommand" OnPageIndexChanging="QgridView_PageIndexChanging" >
                                    <Columns>
                   
                                    <asp:TemplateField HeaderText="No"> 
                                        <ItemTemplate>
                                            <span>
                                            <%#Container.DataItemIndex + 1%>
                                            </span>
                                            </ItemTemplate>
                                    </asp:TemplateField>
                                        
                                        <asp:ImageField HeaderText="Image" DataImageUrlField="coverimg" > 
                                        <ControlStyle CssClass="coverimage"/>
                                        <ItemStyle HorizontalAlign="Center" />                                                
                                        </asp:ImageField>
                                        
                                        <asp:TemplateField HeaderText="seller">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbseller" runat="server" Text='<%# Bind("seller") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblseller" runat="server" Text='<%# Bind("seller") %>'></asp:Label>
                                            </ItemTemplate>                                            
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="Buyer" DataField="buyer" />

                                        <asp:TemplateField HeaderText="Item">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbbuyer" runat="server" Text='<%# Bind("item") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Lblbuyer" runat="server" Text='<%# Bind("item") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="Price offered" DataField="price"/>
              
                                        <asp:BoundField DataField="date" HeaderText="" />
              
                                        <asp:TemplateField HeaderText="Item ID">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbitemid" runat="server" Text='<%# Bind("id") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblitemid" runat="server" Text='<%# Bind("id") %>'></asp:Label>
                                            </ItemTemplate>
                                              <HeaderStyle CssClass="hiddencol" />
                                            <ItemStyle CssClass="hiddencol" />
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="Collection Date" DataField="collectiondate"/>

                                        <asp:BoundField HeaderText="Timeslot" DataField="timeslot"/>
                                         
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:Button ID="Accept" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" runat="server" CausesValidation="false" CommandName="Accept" Text="Accept" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="quoteid">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbquoteid" runat="server" Text='<%# Bind("quoteid") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblquoteid" runat="server" Text='<%# Bind("quoteid") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="hiddencol" />
                                            <ItemStyle CssClass="hiddencol" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="rtype">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="tbtype" runat="server" Text='<%# Bind("rtype") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lbltype" runat="server" Text='<%# Bind("rtype") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="hiddencol" />
                                            <ItemStyle CssClass="hiddencol" />
                                        </asp:TemplateField>                                  

                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:Button ID="View" runat="server" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" CausesValidation="false" CommandName="View" Text="View" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                </Columns>
                                </asp:GridView>
                                                                 
                            </div>
                        </div>
                    </div> 
                           
                        
                <% } else { %>

                <p>No quotation. </p>

                <% } %>

                </div>
                   
            
           
                            
          
          
                 
            <%--</form>--%>
	</div>

     
    
</asp:Content>
