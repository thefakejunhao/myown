<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Our_FYPJ2019.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card {
            margin-top: 50px;
            background: #eee;
            padding: 3em;
            line-height: 1.5em;
        }

        .slotvalue {
            font-weight: bold;
        }

        img {
            transition: transform 0.25s ease;
        }

            img:hover {
                -webkit-transform: scale(1.5);
                transform: scale(1.5);
            }

        hr {
            color: black;
            background-color: black;
        }


        .btn {
            float: right;
        }
    </style>

    <script>
        function salert() {
            alert("Successfullly submitted");
        }

        //function yesorno() {
        //    var confirmation = window.confirm("Are you sure?");
        //    if (!confirmation) {
        //        return false;
        //    }
        //}

        <%--document.getElementById("<%= itemdel.ClientID %>").addEventListener("click", function (event) {
            var confirmation = window.confirm("Are you sure?");
            if (!confirmation) {
                event.preventDefault();
            }
            
        });--%>
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <% foreach (var item in itemList)
                 { %>
        <div class="card">
            <div class="container-fliud">
                <div class="wrapper row">
                    <div class="preview col-md-6">

                        <div class="row">

                            <div class="col-sm">
                                <img src="<%=item.image1 %>" class="img-thumbnail" style="height: 150px; width: 90%" />
                            </div>

                            <div class="col-sm">
                                <img src="<%=item.image2 %>" class="img-thumbnail" style="height: 150px; width: 90%" />
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col-sm">
                                <img src="<%=item.image3 %>" class="img-thumbnail" style="height: 150px; width: 90%" />
                            </div>

                            <div class="col-sm">
                                <img src="<%=item.image4 %>" class="img-thumbnail" style="height: 150px; width: 90%" />
                            </div>
                        </div>
                        <br />

                    </div>

                    <div class="details col-md-6">

                        <div class="btn" id="report" runat="server">
                            <button type="button" class="btn btn-primary" data-toggle="modal" style="margin-bottom: 10px; cursor: pointer;" data-target="#changepw_modal">Report</button>
                        </div>

                        <!-- Modal -->
                        <div class="modal fade" id="changepw_modal" role="dialog">
                            <div class="modal-dialog">

                                <!-- Modal content-->
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h4 class="modal-title">Report Listing</h4>
                                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    </div>

                                    <div class="modal-body">
                                        <h3></h3>
                                        <asp:Label ID="lbl" runat="server" Text="Why do you want to report this listing?"></asp:Label>
                                        <asp:DropDownList ID="ddlReason" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Text="--Select--"></asp:ListItem>
                                            <asp:ListItem Text="Prohibited item"></asp:ListItem>
                                            <asp:ListItem Text="Irrelevant item/Content"></asp:ListItem>
                                            <asp:ListItem Text="Offensive Content"></asp:ListItem>
                                            <asp:ListItem Text="Spam"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnReport" runat="server" CssClass="btn btn-primary" Text="Report" OnClick="btnReport_Click" />
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <asp:Label ID="lblResult" runat="server" Text="" ForeColor="#33CC33"></asp:Label>

                        <h1 class="product-title"><%=item.itemname %></h1>
                        <br />

                        <h6 class="product-description">Username : <%=item.username %></h6>
                        <br />

                        <h6>Description</h6>
                        <p class="product-description"><%=item.desc %></p>

                        <h6>Item Details</h6>

                        <p>Category :<span> <%=item.rtype %></span></p>
                        <% if (item.rtype == "Plastics")
                            { %>

                        <p>Item : <span><%=item.plastic %></span></p>

                        <% }
                            else if (item.rtype == "Paper")
                            { %>

                        <p>Paper Type :  <span><%=item.paper %></span></p>
                        <%}
                            else if (item.rtype == "Batteries/Bulbs")
                            { %>

                        <p>Batteries Type :  <span><%=item.batteries %></span></p>
                        <%}
                            else if (item.rtype == "Electronics")
                            { %>

                        <p>Electronics Type :  <span><%=item.electronics %></span></p>
                        <% }
                            else if (item.rtype == "Metals")
                            {%>
                        <p>Metal Type :  <span><%=item.metal %></span></p>
                        <% } %>


                        <% if (item.rtype != "Plastics")
                            { %>
                        <p>Weight : <span><%=item.weight %>Kg </span></p>
                        <% }
                            else
                            { %>
                        <p>Quantity : <span><%=item.qty %></span></p>
                        <% }  %>
                        <h6>Location</h6>
                        <p>Address : <span><%=item.address %></span></p>
                        <p>Unit no : #<span><%=item.unitno %></span></p>
                        <p>Postal Code : <span><%=item.postalcode %></span></p>
                        <p>Estate : <span><%=item.estate %></span></p>
                        <p>Last updated on <span style="color: red"><%=item.date %> </span></p>
                        <hr />

                        <%--<strong><p>Quotation</p></strong>--%>
                        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>

                        <!-- Schedule modal button -->
                        <button type="button" class="btn btn-primary" data-toggle="modal" runat="server" data-target="#ScheduleModal" id="schedulebutton">
                            Quotation
                        </button>

                        <!-- schedule model body -->
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
                                                <div class="input-group mb-3">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text" id="basic-addon1">$</span>
                                                    </div>
                                                    <asp:TextBox ID="tbprice" runat="server" CssClass="form-control" placeholder="Quote price"></asp:TextBox>
                                                </div>

                                                <!-- description -->
                                                <asp:Label ID="lbltadesc" runat="server" Text="Description : "></asp:Label>
                                                <textarea id="tadesc" cols="20" rows="2" style="width: 100%" runat="server"></textarea>
                                                <br />
                                                <br />

                                                <!-- suggestion -->
                                                <div id="suggestionpart" runat="server" visible="false">
                                                    <asp:Label ID="lblsuggestion" runat="server" Text=""></asp:Label>
                                                    <br />

                                                    <asp:Button ID="btnyes" runat="server" Text="Yes" OnClick="btnyes_Click" CssClass="btn btn-success" />
                                                    <asp:Button ID="btnno" runat="server" Text="No" OnClick="btnno_Click" CssClass="btn btn-danger" />

                                                    <br />

                                                </div>

                                                <!--calender -->
                                                <asp:Label ID="Label1" runat="server" Text="Set collection date : "></asp:Label>
                                                <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" OnDayRender="Calendar2_DayRender"></asp:Calendar>

                                                <!--radiobutton-->
                                                <div runat="server" id="timeslot" visible="false">
                                                    <br />
                                                    Set TimeSlot for :                                                         
                                                    <asp:Label ID="datetimeslot" runat="server" Text="" CssClass="slotvalue"></asp:Label>

                                                    <!-- new -->
                                                    <!-- 9am - 12pm -->
                                                    <div class="card-header">
                                                        <asp:RadioButton ID="rb1" runat="server" Text="9am - 12pm" />
                                                    </div>
                                                    <ul class="list-group list-group-flush" runat="server" id="ul1">
                                                        <li class="list-group-item" id="li1" runat="server">(Available)</li>
                                                    </ul>

                                                    <!-- 1pm - 4pm -->
                                                    <div class="card-header">
                                                        <asp:RadioButton ID="rb2" runat="server" Text="1pm - 4pm" />
                                                    </div>
                                                    <ul class="list-group list-group-flush" runat="server" id="ul2">
                                                        <li class="list-group-item" id="li2" runat="server">(Available)</li>
                                                    </ul>

                                                    <!-- 4pm - 7pm -->
                                                    <div class="card-header">
                                                        <asp:RadioButton ID="rb3" runat="server" Text="4pm - 7pm" />
                                                    </div>
                                                    <ul class="list-group list-group-flush" runat="server" id="ul3">
                                                        <li class="list-group-item" id="li3" runat="server">(Available)</li>
                                                    </ul>

                                                    <!-- 8pm - 10pm -->
                                                    <div class="card-header">
                                                        <asp:RadioButton ID="rb4" runat="server" Text="8pm - 10pm" />
                                                    </div>
                                                    <ul class="list-group list-group-flush" runat="server" id="ul4">
                                                        <li class="list-group-item" id="li4" runat="server">(Available)</li>
                                                    </ul>

                                                </div>

                                            </div>
                                            <!-- //&&&&&schedule body ends here&&&&&// -->

                                            <!-- Schedule Button button -->
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                <asp:Button ID="send" runat="server" Text="send" OnClick="send_Click" CssClass="btn btn-success" UseSubmitBehavior="false" data-dismiss="modal"
                                                    OnClientClick="salert();" />
                                            </div>

                                        </div>
                                    </div>

                                    <!-- MEssage -->
                                    <asp:Label ID="buyermsg" runat="server" Text="" ForeColor="red"></asp:Label>
                                    <asp:Label ID="submit" runat="server" Text="" ForeColor="red"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <!-- //*****schedule model body ends here ****// -->

                        <br />
                        <hr />
                        <asp:HiddenField ID="buyer" runat="server" Value="jw" />
                        <asp:HiddenField ID="status" runat="server" Value="no" />



                        <% if (states != null)
                            { %>
                        <% if (states.ToLower() == "seller")
                            { %>
                        <asp:Button ID="itemdel" runat="server" Text="Delete" CssClass="btn btn-danger" onclientclick="return confirm('add record?');" OnClick="itemdel_Click"/>
                        <a href="/Edit.aspx?user=<%=item.username%>&id=<%=item.id%>&type=<%=item.rtype%>&item=<%=item.itemname%>" class="btn btn-warning" role="button" aria-pressed="true">Edit</a>

                        <% } %>

                        <% }
                             else
                             { %>
                        <p>Empty</p>
                        <% }  %>


                        <div class="action">
                            <a href="/chat.aspx?itemid=<%=item.id%>&item=<%=item.itemname%>&buyer=alex&seller=<%=item.username%>" class="btn btn-warning" role="button" aria-pressed="true">Chat</a>


                            <br />


                        </div>

                    </div>
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
