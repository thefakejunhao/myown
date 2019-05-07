<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="QuotationDetails.aspx.cs" Inherits="Our_FYPJ2019.QuotationDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

      <style>
 
.card {
  margin-top: 50px;
  background: #EDE7E7;
  padding: 3em;
  line-height: 1.5em; }

img {
    transition:transform 0.25s ease;
}

img:hover {
    -webkit-transform:scale(1.5);
    transform:scale(1.5);
}

    </style>

    <script>
        function choose() {
            var accept = document.getElementById('<%=ddlaccept.ClientID%>');
            var accepttext = accept.options[accept.selectedIndex].text;

            var counter = document.getElementById('counterpart');
            if (accepttext == "no") {
                counter.style.display = "";
            }
            else {
                counter.style.display = "none";
            }
        }

        function salert() {
            alert("Successfullly submitted");
        }

    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
      <%--<form id ="form1" runat="server">--%>
          <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<div class="card">
			<div class="container-fliud">
				<div class="wrapper row"> 
                    
                                          
                            <% foreach (var i in quoteList) { %>
                            <div class="preview col-md-6">
                                
                                <h5><u>Details of item</u></h5>
                                <p><strong>Category : </strong><%=i.rtype %></p>
                                <p><strong>Item : </strong><%=i.item %></p>
                                <% if (i.rtype != "Plastics") {%>
                                    <p><strong>Weight : </strong><%=i.weight %> KG</p>
                                <% } else {%>
                                    <p><strong>Quantities : </strong><%=i.qty %></p>
                                <% } %>
                               
                                
                                <div class="row">
                            
                                    <div class="col-sm">
                                      <img src="<%=i.coverimg %>" class="img-thumbnail" style="height :150px ; width :90%"/>
                                    </div>

                                    <div class="col-sm">
                                         <img src="<%=i.image2 %>" class="img-thumbnail" style="height :150px ; width :90%"/>
                                    </div>

						        </div>
                                <br />
                                <div class="row">
                                    <div class="col-sm">
                                         <img src="<%=i.image3 %>" class="img-thumbnail" style="height :150px; width :90%"/>
                                    </div>

                                    <div class="col-sm">
                                         <img src="<%=i.image4 %>" class="img-thumbnail" style="height :150px; width :90%"/>
                                    </div>
                                </div>
                                <br />
                                
                                
                                
                            </div>
                                <% if (status == "seller")
                                    { %>      
                            <div class="details col-md-6" >

                                <h5><u>Quotation from buyer</u></h5>
                                <p><strong>From : </strong> <%= i.buyer %></p>
                                <p><strong>Description : </strong> <%=i.desc %></p>
                                <p><strong>Offered price : </strong>$<%=i.price %></p>
                                <p><strong>Received On : </strong> <%=i.date %> , <%=i.time %></p>
                                <p><strong>Collection Date & TimeSlot : </strong><%=i.collectiondate %>, <%=i.timeslot %></p>
                                <hr />
                                                          
                                   <% if (i.sres == "yes" && i.status == "no")
                                       { %>
                                    <p style="color:red"><strong>*Waiting response from buyer*</strong></p>
                                    <% }
                                        else if (i.sres == "no" && i.status == "no")
                                        { %>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <h5><u>Respond to buyer</u></h5>
                                            <div id ="sellersec" runat="server">                                      
                                                <asp:Label ID="lblaccept" runat="server" Text="Accept (Yes/No) : "></asp:Label>
                                                <asp:DropDownList ID="ddlaccept" CssClass ="form-control" runat="server" onchange="choose();">
                                                    <asp:ListItem Selected ="True" Value ="1" Text ="yes"></asp:ListItem>
                                                    <asp:ListItem Value ="2" Text ="no"></asp:ListItem>
                                                </asp:DropDownList>
                                
                                                <div id ="counterpart" style="display:none">
                                                    <asp:Label ID="Label1" runat="server" Text="Reasons : "></asp:Label>
                                                    <asp:DropDownList ID="ddlreason" CssClass ="form-control" runat="server">
                                                        <asp:ListItem Value="" Selected ="True" Text=""></asp:ListItem>
                                                        <asp:ListItem Value ="1" Text ="Offer price is too low"></asp:ListItem>
                                                        <asp:ListItem Value ="2" Text ="Not available during Collection day"></asp:ListItem>
                                                        <asp:ListItem Value ="3" Text ="Both"></asp:ListItem>
                                                    </asp:DropDownList>

                                                    <asp:Label ID="lblreasondesc" runat="server" Text="Brief description"></asp:Label>
                                                    <textarea id="tareasondesc" cols="20" rows="2" style="width:100%" runat="server"></textarea>
                                                </div>
                                                <br />
                                                <asp:Button ID="sellerSubmit" runat="server" Text="Send" cssClass="btn btn-success" OnClick="sellerSubmit_Click"/><br />
                                               
                                            </div>
                                             <asp:Label ID="sellermsg" runat="server" ForeColor="red"></asp:Label>
                                        </ContentTemplate>
                                        </asp:UpdatePanel>
                                    <% }
                                        else if (i.status == "yes")
                                        { %>
                                        <p style="color:green"><strong>You have accepted the Quotation!</strong></p>
                                    <% }  %>
                                </div>
                                <% } else if (status == "buyer") {  %>
                                     <div class="details col-md-6" >
                                        <h5><u>Quotation to seller</u></h5>                              
                                        <p><strong>Message to : </strong><%= i.seller %></p>
                                        <p><strong>Description : </strong> <%=i.desc %></p>
                                        <p><strong>Price offered : </strong>$<%=i.price %></p>
                                        <p><strong>Sent on : </strong> <%=i.date %> , <%=i.time %></p>
                                        <p><strong>Collection Date & TimeSlot : </strong><%=i.collectiondate %>, <%=i.timeslot %></p>
                                        <hr />
                             
                                        <% if (i.sres == "no" && i.status == "no"/* && i.buyerres == "no" && i.buyeraccept == "no"*/) { %>
                                        <h5><u>Response from seller</u></h5>
                                            <p style="color:red"><strong>*Waiting for Seller's response*</strong></p>
                                        <% } else if (i.sres == "yes" && i.status == "no" /*&& i.buyerres == "no" && i.buyeraccept == "no"*/) { %>
                                                    
                                            <h5><u>Response from seller</u></h5>
                                            <p style="color :red"><strong>*Quotation is rejected by seller*</strong></p>
                                            <p><strong>Received on : </strong><%=i.sellerdate %></p>
                                            <p><strong>Reason for rejecting : </strong><br /><%=i.reason %></p>
                                            <p><strong>Brief description for reason : </strong><br /><%= i.reasondesc %></p>

                                            <!-- Schedule modal button -->
                                            <button type="button" class="btn btn-primary" data-toggle="modal" runat="server" data-target="#ScheduleModal" id="schedulebutton">
                                                Quotation
                                            </button>
                                            
                                            <div class="modal fade" id="ScheduleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="modal-dialog" role="document">
                                                    <div class="modal-content">

                                                        <!-- SChedule header -->
                                                        <div class="modal-header">
                                                            <h5 class="modal-title" id="exampleModalLongTitle">Quotation</h5>
                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                <span aria-hidden="true">&times;</span>
                                                            </button>
                                                        </div>

                                                        <!-- schedule body -->
                                                        <div class="modal-body">
                                                            
                                                             <!-- price -->
                                                            <asp:Label ID="lblprice" runat="server" Text="Price : "></asp:Label>                                       
                                                            <div class ="input-group mb-3">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" id="basic-addon1">$</span>
                                                                </div>
                                                                <asp:TextBox ID="tbuserprice" runat="server" CssClass="form-control" placeholder="Quote price"></asp:TextBox>
                                                            </div>    

                                                            <!-- description -->
                                                            <asp:Label ID="lbltadesc" runat="server" Text="Description : "></asp:Label>
                                                            <textarea id="tauserdesc" cols="20" rows="2" style="width:100%" runat="server"></textarea>
                                                            <br />
                                                            <br />

                                                            <!--calender -->
                                                            <asp:Label ID="Label2" runat="server" Text="Set collection date : "></asp:Label>
                                                            <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender"></asp:Calendar>                                                                                                                      
                                                
                                                            <!--radiobutton-->
                                                            <div runat="server" id="timeslot" visible="false">  
                                                            <br />                                               
                                                                 Set TimeSlot for :                                                         
                                                                <asp:Label ID="datetimeslot" runat="server" Text="" CssClass="slotvalue"></asp:Label>
                                                                                                     
                                                                <!-- new -->
                                                                <!-- 9am - 12pm -->
                                                                <div class="card-header">                                                          
                                                                    <asp:RadioButton ID="rb1" runat="server" Text ="9am - 12pm"/>                                                      
                                                                </div>
                                                                <ul class="list-group list-group-flush" runat ="server" id="ul1"> 
                                                                    <li class="list-group-item" id="li1" runat="server">(Available)</li>
                                                                </ul>

                                                                <!-- 1pm - 4pm -->
                                                                <div class="card-header">                                                          
                                                                    <asp:RadioButton ID="rb2" runat="server" Text ="1pm - 4pm"/>                                                          
                                                                </div>
                                                                <ul class="list-group list-group-flush" runat="server" id="ul2">  
                                                                    <li class="list-group-item" id="li2" runat="server">(Available)</li>
                                                                </ul>

                                                                <!-- 4pm - 7pm -->
                                                                <div class="card-header">                                                          
                                                                    <asp:RadioButton ID="rb3" runat="server" Text ="4pm - 7pm"/>                                                          
                                                                </div>
                                                                <ul class="list-group list-group-flush" runat ="server" id="ul3">   
                                                                    <li class="list-group-item" id="li3" runat="server">(Available)</li>
                                                                </ul>

                                                                <!-- 8pm - 10pm -->
                                                                <div class="card-header">                                                          
                                                                    <asp:RadioButton ID="rb4" runat="server" Text ="8pm - 10pm"/>                                                          
                                                                </div>
                                                                <ul class="list-group list-group-flush" runat ="server" id="ul4">    
                                                                    <li class="list-group-item" id="li4" runat="server">(Available)</li>
                                                                </ul>

                                                            </div>                                       
                                                        </div>
                                                        <!-- //&&&&&schedule body ends here&&&&&// -->

                                                        <!-- Schedule Button button -->
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                            <asp:Button ID="buyerbutton" runat="server" Text="Send" cssClass="btn btn-success" OnClick="buyerbutton_Click" data-dismiss="modal" UseSubmitBehavior="false" OnClientClick="salert()"/> 
                                                        </div>

                                                    </div>
                                                    </div>

                                                    <!-- MEssage -->
                                                    <asp:Label ID="buyermsg" runat="server" Text="" ForeColor="red"></asp:Label>
                                                     <asp:Label ID="submit" runat="server" Text="" ForeColor="red"></asp:Label>
                                                    </ContentTemplate>
                                            </asp:UpdatePanel>                                
                                            </div>
                                            
                                    
                                            

                                            
                                        <% } else if (i.status == "yes") { %>
                                            <p style="color:green"><strong>Seller has accepted the Quotation !</strong></p>

                                        <% }  %>
                                        </div>



                                    <% } %>
                            <% } %>
                           
				</div>
			</div>
		</div>
          <br />
          <div class="row">
              <div class="col-sm">
                    <h5><u>History</u></h5>
                   
                  
                  <asp:GridView ID="quotegv" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                      <Columns>
                          <asp:TemplateField HeaderText="No">
                            <ItemTemplate>
                         <span>
                         <%#Container.DataItemIndex + 1%>
                         </span>
                         </ItemTemplate>
                         </asp:TemplateField>
                        
                          <asp:BoundField HeaderText="Offered price($)" DataField="price" />
                          <asp:BoundField HeaderText="Buyer's Description" DataField="desc" />
                          <asp:BoundField HeaderText="Send Date" DataField="date" />
                         
                          <asp:BoundField DataField="status" HeaderText="Accepted (Y/N)" />
                          <asp:BoundField DataField="reason" HeaderText="Reason" />
                          <asp:BoundField DataField="reasondesc" HeaderText="Seller's description" />
                          <asp:BoundField DataField="sellerdate" HeaderText="Respond Date" />
                          
                      </Columns>
                  </asp:GridView>
            </div>
          </div>
       <%--</form>  --%>
        <br />
        <br />
	</div>
</asp:Content>
