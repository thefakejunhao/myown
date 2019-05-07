<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListingItems.aspx.cs" Inherits="Our_FYPJ2019.ListingItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        h5 {
    font-size: 1.28571429em;
    font-weight: 700;
    line-height: 1.2857em;
    margin: 0;
}

.card {
    font-size: 1em;
    overflow: hidden;
    padding: 0;
    border: none;
    border-radius: .28571429rem;
    box-shadow: 0 1px 3px 0 #d4d4d5, 0 0 0 1px #d4d4d5;
}

.card-block {
    font-size: 1em;
    position: relative;
    margin: 0;
    padding: 1em;
    border: none;
    border-top: 1px solid rgba(34, 36, 38, .1);
    box-shadow: none;
}

.card-img-top {
    display: block;
    width: 100%;
    height: auto;
}

.card-title {
    font-size: 1.28571429em;
    font-weight: 700;
    line-height: 1.2857em;
}

.card-text {
    clear: both;
    margin-top: .5em;
    color: rgba(0, 0, 0, .68);
}

.card-footer {
    font-size: 1em;
    position: static;
    top: 0;
    left: 0;
    max-width: 100%;
    padding: .75em 1em;
    color: rgba(0, 0, 0, .4);
    border-top: 1px solid rgba(0, 0, 0, .05) !important;
    background: #fff;
}

.card-inverse .btn {
    border: 1px solid rgba(0, 0, 0, .05);
}

.profile {
    position: absolute;
    top: -12px;
    display: inline-block;
    overflow: hidden;
    box-sizing: border-box;
    width: 25px;
    height: 25px;
    margin: 0;
    border: 1px solid #fff;
    border-radius: 50%;
}

.profile-avatar {
    display: block;
    width: 100%;
    height: 100%;
    border-radius: 50%;
}

.profile-inline {
    position: relative;
    top: 0;
    display: inline-block;
}

.profile-inline ~ .card-title {
    display: inline-block;
    margin-left: 4px;
    vertical-align: top;
}

.text-bold {
    font-weight: 700;
}

.meta {
    font-size: 1em;
    color: rgba(0, 0, 0, .4);
}

.meta a {
    text-decoration: none;
    color: rgba(0, 0, 0, .4);
}

.meta a:hover {
    color: rgba(0, 0, 0, .87);
}

.overflow {
    width: 10em;
  outline: 1px solid #000;
  margin: 0 0 2em 0;
  
  /**
   * Required properties to achieve text-overflow
   */
      white-space: nowrap;
    overflow: hidden;
}
    </style>
    <script>
        
       function choose() {
            var types = document.getElementById('<%=ddltypes.ClientID%>');
            var ddltypes = types.options[types.selectedIndex].text;
            var weightrange = document.getElementById("weightrange");
            var qtyrange = document.getElementById("qtyrange");
            
            if (ddltypes != "Plastics") {
                weightrange.style.display = "";
                qtyrange.style.display = "none";
            }
            
            else if (ddltypes == "Plastics") {
                weightrange.style.display = "none";
                qtyrange.style.display = "";
            }
        }

        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <%-- <form id ="form1" runat="server">--%>
    

    <div class ="container" >
        <br />
        <div class ="row">
            <div class="col-sm-3">
            </div>
            
            <div class ="col-sm-3">
                <asp:Label ID="Label1" runat="server" Text="Search : "></asp:Label>
                <div class="input-group mb-3">
                     <!-- Actual search box -->
                    <asp:TextBox ID="tbsearch" CssClass="form-control" runat="server"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="searchbutton" runat="server" Text="search" CssClass ="btn btn-warning" OnClick="searchbutton_Click" />
                    </div>
                </div>
            </div>
            <div class="col-sm-3">

            </div>

            <div class ="col-sm">
               
            </div>
            <%--<asp:Button ID="sortbutton" runat="server" CssClass ="btn btn-success" Text="Sort" OnClick="sortbutton_Click" />--%>
            
            
            
        </div>
                <div class ="row">
                    <div class ="col-sm-2">
                        <div class ="row">
                            <br />

                             <asp:Label runat="server" ID="lbllocation" CssClass="control-label" Text="Estate : ">
                        </asp:Label>
                        <asp:TextBox ID="tblocation" runat="server" CssClass="form-control" placeholder="Estate"></asp:TextBox>
                        <br />
                            <br />
                            <br />
                            <asp:Label runat="server" for="ddltypes" ID="lbltypes" CssClass="control-label" Text="Recyclable Types : ">
                            </asp:Label>
                            <asp:DropDownList ID="ddltypes" CssClass ="form-control" runat="server" onchange="choose();">
                                <asp:ListItem Selected ="True" Value ="" Text =""></asp:ListItem>
                                <asp:ListItem Text = "Plastics" Value ="1"></asp:ListItem>
                                <asp:ListItem Text = "Paper" Value ="1"></asp:ListItem>
                                <asp:ListItem Text = "Metals" Value ="3"></asp:ListItem>
                                <asp:ListItem Text = "Batteries/Bulbs" Value ="4"></asp:ListItem>
                                <asp:ListItem Text = "Electronics" Value ="5"></asp:ListItem>
                            </asp:DropDownList>
                             
                            <br />
                            <br />
                            <br />
                            <asp:Label runat="server" ID="lblsort" CssClass="control-label" Text="Sort :  ">
                            </asp:Label>
                            <asp:DropDownList ID="ddlsort" CssClass ="form-control" runat="server">
                                <asp:ListItem Selected ="True" Value ="" Text =""></asp:ListItem>
                                <asp:ListItem Text= "Recent" Value ="1"></asp:ListItem>
                                <asp:ListItem Text= "Weight : Heaviest" Value ="3"></asp:ListItem>
                                <asp:ListItem Text= "Weight : Lowest" Value ="4"></asp:ListItem>
                                <asp:ListItem Text= "Quantity : Highest" Value ="5"></asp:ListItem>
                                <asp:ListItem Text= "Quantity : Lowest" Value ="6"></asp:ListItem>
                            </asp:DropDownList>
                            
                            <!-- weight -->
                            <div id="weightrange" style="display:none">
                                <br />
         
                                <asp:Label runat="server" ID="lblpricerange" CssClass="control-label" Text="Weight range : "></asp:Label>
                                    <asp:TextBox ID="tbmin" runat="server" placeholder="Minimum" CssClass="form-control"></asp:TextBox>
                                    <asp:TextBox ID="tbmax" runat="server" placeholder="Maximum" CssClass="form-control"></asp:TextBox>
                                    <asp:RangeValidator ID="qtyrval" runat="server" ErrorMessage="Min weight is 5kg" ForeColor="red" MinimumValue="5" MaximumValue="10000000" ControlToValidate="tbmin" Type="Integer" ></asp:RangeValidator>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Max weight must be more than 5kg" ForeColor="red" MinimumValue="6" MaximumValue="10000000" ControlToValidate="tbmax" Type="Integer" ></asp:RangeValidator>
                                <br />
                            </div>

                            <div id="qtyrange"  style="display:none">
                                <br />
                                
                                <asp:Label runat="server" ID="Label2" CssClass="control-label" Text="Quantity range : "></asp:Label>
                                <asp:TextBox ID="tbminqty" runat="server" placeholder="Minimum" CssClass="form-control"></asp:TextBox>
                                <asp:TextBox ID="tbmaxqty" runat="server" placeholder="Maximum" CssClass="form-control"></asp:TextBox>                                
                                <br />
                            </div>

                            <br />
                            <br />
                            <asp:Button ID="setbutton" runat="server" Text="Filter" OnClick="setbutton_Click" CssClass="btn btn-danger"/>
                            
                        </div>
  
                    </div>
                    <div class ="col-sm-10">
                        <div class ="row">
                    <% if (itemList != null) { %>
                    <% foreach (var item in itemList)
                        { %>
                            
                    <div class="col-sm-6 col-md-4 col-lg-3 mt-4">
                        <div class="card card-inverse card-info">
                            <img class="card-img-top" src="<%=item.image1 %>" style ="height : 170px ; width : 100%"/> 
                            <div class="card-block">
                                <figure class="profile">
                                    <img src="<%=item.image1 %>" class="profile-avatar" alt=""/>
                                    
                                </figure>
                                <h4 class="card-title mt-3"><%=item.itemname %></h4>
                                
                                <div class="card-text">
                                
                                    <% if (item.rtype != "Plastics")
        {%>
                                        <a><%=item.weight %>KG</a>
                                    <% }
        else if (item.rtype == "Plastics")
        { %>
                                        <a><%=item.qty %> QTY</a>
                                    <% } %>
                                    <br />
                                    <span><strong>Type : </strong><%=item.rtype%><br /></span>
                                    <span style="color : black"><%= item.desc %><br /></span>
                                    <span><strong>User : </strong><%= item.username %></span>
                                </div>
                               
                            </div>
                            <div class="card-footer">
                                <small>Last updated on <%=item.date%></small>

                                <a href ="/product.aspx?user=<%=item.username%>&id=<%=item.itemid%>&type=<%=item.rtype%>&item=<%=item.itemname%>" class="btn btn-info float-right btn-sm">View</a>
                                    
                            </div>
                        </div>
                    </div>
                     <% } %>
                    <% } else { %>
                        <div class="col-sm">
                            <p>No items</p>
                        </div>
                    <% }  %>

                    </div>
                    </div>
                </div>
                
                

     </div>
       
     <%-- </form>--%>
   

</asp:Content>
