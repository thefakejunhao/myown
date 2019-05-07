<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SellerListing.aspx.cs" Inherits="Our_FYPJ2019.SellerListing" %>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<form id ="form1" runat="server">--%>
   
    <div class ="container" >
        <br />
        <div class ="row">
            
            <div class ="col-sm-4">
                <div class="input-group mb-3">
                  <asp:TextBox ID="tbsearch" CssClass="form-control" runat="server"></asp:TextBox>
                  <div class="input-group-append">
                    <asp:Button ID="searchbutton" runat="server" Text="Search" CssClass ="btn btn-warning"/>
                  </div>
                </div>
            </div>
            
            
        </div>
        
            
                 
                <div class = "row">
                   
                    <% if (Selleritems != null) { %> 
                    <% foreach (var item in Selleritems) { %>
                            
                    <div class="col-sm-6 col-md-4 col-lg-3 mt-4">
                        <div class="card card-inverse card-info">
                            <img class="card-img-top" src="<%=item.image1 %>" style ="height : 200px ; width : 100%"> 
                            <div class="card-block">
                                <figure class="profile">
                                    <img src="<%=item.image1 %>" class="profile-avatar" alt="">
                                </figure>
                                <h4 class="card-title mt-3"><%=item.itemname %></h4>
                                <div class="meta card-text">
                                
                                    <% if (item.rtype != "Plastics")
                                                   {%>
                                        <a><%=item.weight %>KG</a>
                                    <% } else if (item.rtype == "Plastics") { %>
                                        <a><%=item.qty %> QTY</a>
                                    <% } %>
                                </div>
                                <div class="card-text">
                                    <%=item.desc %>
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
                        <p>No Items </p>
                        </div>
                    <% } %>
                    
                </div>
                
                

     </div>
       
     <%-- </form>--%>
</asp:Content>
