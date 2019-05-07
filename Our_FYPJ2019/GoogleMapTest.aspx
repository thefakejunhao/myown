<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GoogleMapTest.aspx.cs" Inherits="Our_FYPJ2019.GoogleMapTest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
        #map {
            height: 100%;
        }

        .hiddencol {
            display: none;
        }

        #right-panel {
            font-family: 'Roboto','sans-serif';
            line-height: 30px;
            padding-left: 10px;
            overflow: scroll
        }

        #right-panel select, #right-panel input {
            font-size: 15px;
        }

        #right-panel select {
            width: 100%;
        }

        #right-panel i {
            font-size: 12px;
        }

        #right-panel {
            height: 500px;
            float: right;
            width: 390px;
        }

        @media print {
            #map {
                height: 500px;
                margin: 0;
            }

            #right-panel {
                float: none;
                width: auto;
                overflow: scroll;
            }
        }
    </style>

    <script>

        function choose() {
            var choice = document.getElementById('<%=ddlchoice.ClientID%>');
            var ddlchoice = choice.options[choice.selectedIndex].text;
            var divrange = document.getElementById('divrange');

            if (ddlchoice == "Postal code") {
                divrange.style.display = "";
            }

            else if (ddlchoice == "Estate" || ddlchoice == "Address") {
                divrange.style.display = "none";
            }

        }

        function viewmaps() {
            var displaymap = document.getElementById("displaymap");
            var displaytable = document.getElementById("displaytable");
            var floatingpanel = document.getElementById("floating-panel");
            displaymap.style.display = "";
            displaytable.style.display = "none";
            floatingpanel.style.display = "";
        }

        function viewtables() {
            var displaymap = document.getElementById("displaymap");
            var displaytable = document.getElementById("displaytable");
            var floatingpanel = document.getElementById("floating-panel");
            displaymap.style.display = "none";
            displaytable.style.display = "";
            floatingpanel.style.display = "none";
        }

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }



    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />

    <div class="container">
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <%-- <form id ="form1" runat="server">--%>

        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
        <div class="row">
            <div class="col-sm-4">
                <asp:Label ID="Label2" runat="server" Text="Search : "></asp:Label>
                <div class="input-group mb-3">
                    <div class="input-group-append">
                        <asp:DropDownList ID="ddlchoice" CssClass="form-control" runat="server" onchange="choose();">
                            <asp:ListItem Selected="True" Value="Estate"></asp:ListItem>
                            <asp:ListItem Value="Postal code"></asp:ListItem>
                            <asp:ListItem Value="Address"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:TextBox ID="tbsearch" CssClass="form-control" runat="server"></asp:TextBox>
                    <div class="input-group-append">
                        <asp:Button ID="searchbtn" runat="server" Text="Search" CssClass="btn btn-warning" OnClick="searchbtn_Click" />
                    </div>
                </div>

                <div id="divrange" style="display: none">
                    <asp:Label ID="Label1" runat="server" Text="Include range : "></asp:Label>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="tbrange" CssClass="form-control" runat="server" placeholder="Optional" onkeypress="return isNumber(event)"></asp:TextBox>
                        <div class="input-group-append">
                            <%--<asp:Button ID="btnRange" runat="server" Text="Get" CssClass ="btn btn-warning" OnClick="btnRange_Click"/>--%>
                            <span class="input-group-text" id="basic-addon1">Km</span>
                        </div>
                    </div>
                </div>
            </div>



            <div class="col-sm-3">
                <asp:Label runat="server" for="ddltypes" ID="lbltypes" CssClass="control-label" Text="Types : "></asp:Label>
                <div class="input-group mb-2">
                    <asp:DropDownList ID="ddltypes" CssClass="form-control" runat="server" onchange="this.form.submit()">
                        <asp:ListItem Selected="True" Value=""></asp:ListItem>
                        <asp:ListItem Text="Plastics" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Paper" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Metals" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Batteries/Bulbs" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Electronics" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

        </div>

        <h5><u>Results</u></h5>

        <!-- TOggle -->
        <div class="row">

            <div class="col-sm-2">


                <button type="button" class="btn btn-outline-dark active" id="viewtable" onclick="viewtables()">Table</button>

                <button type="button" class="btn btn-outline-dark" id="viewmap" onclick="viewmaps()">Map</button>


            </div>
        </div>

        <br />

        <div class="row" id="displaytable">
            <% if (itemList != null)
                { %>
            <div class="col-sm">
                <asp:GridView ID="usergridview" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                    AllowPaging="True" PageSize="10" OnPageIndexChanging="usergridview_PageIndexChanging" BackColor="White" BorderColor="Black" BorderStyle="Solid" ForeColor="Black" GridLines="None" OnSelectedIndexChanged="usergridview_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="No">
                            <ItemTemplate>
                                <span>
                                    <%#Container.DataItemIndex + 1%>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="Item id">
                            <HeaderStyle CssClass="hiddencol" />
                            <ItemStyle CssClass="hiddencol" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Name" DataField="username" />
                        <asp:BoundField HeaderText="Item" DataField="itemname" />
                        <asp:BoundField HeaderText="Category" DataField="rtype" />
                        <asp:BoundField HeaderText="Address" DataField="address" />
                        <asp:BoundField HeaderText="Postal code" DataField="PostalCode" />

                        <asp:BoundField DataField="estate" HeaderText="Estate" />

                        <asp:CommandField ShowSelectButton="true" SelectText="View" ButtonType="Button">
                            <ItemStyle ForeColor="#0033CC" />
                        </asp:CommandField>

                    </Columns>

                </asp:GridView>
            </div>
            <% }
                else
                {%>
            <div class="col-sm">
                <p style="color: red"><strong>No results return. Please search again</strong></p>
            </div>


            <% } %>
        </div>

        <br />

        <div class="row" id="displaymap" style="display: none">
            <!-- Maps -->
            <div class="col-sm">
                <div id="map" style="height: 50%"></div>
            </div>

        </div>


        <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>

    <script>

        var markerCluster;
        var markerArray = [];
        var map;
        var arr;

        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        $(window).resize(function () {
            var h = $(window).height(),
                offsetTop = 40; // Calculate the top offset

            $('#map').css('height', (h - offsetTop));
        }).resize();

        function initMap() {
            console.log("initmap")
            var infoWindow;
            var map;
            infoWindow = new google.maps.InfoWindow;            

            // Try HTML5 geolocation.
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(function (position) {
                    var pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude
                    };

                    infoWindow.setPosition(pos);
                    infoWindow.setContent('Location found.');
                    infoWindow.open(map);
                    //map.setCenter(pos);

                }, function () {
                    handleLocationError(true, infoWindow, map.getCenter());
                });
            } else {
                // Browser doesn't support Geolocation
                handleLocationError(false, infoWindow, map.getCenter());
            }

            map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: { lat: 1.3521, lng: 103.8198 }
            });

            markerCluster = new MarkerClusterer(map, [],
                {
                    imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m'
                });

                //Show radius in map
                <% if (range != null) { %>
                var pos = {
                    lat: parseFloat(<%= UserLat %>),
                            lng: parseFloat(<%= UserLng %>)
                };

                var currentMarker = new google.maps.Marker({
                    position: pos,
                    //map:map
                });

                infoWindow.setPosition(pos);
                infoWindow.setContent('Your location.');
                //infoWindow.open(map);

                var x = parseInt(<%= range %>) * 1000; //Get radius

                // Add circle overlay and bind to marker
                var circle = new google.maps.Circle({
                    map: map,
                    fillColor: '#AA0000',
                    fillOpacity: 0.3,
                    strokeColor: '#ff0000',
                    strokeOpacity: 1.0,
                    strokeWeight: 1.5,
                    radius: x
                });

                circle.bindTo('center', currentMarker, 'position');
                    <% } %>

                    <% if (itemList != null) { %>
                        <% foreach (var item in itemList)  { %> 
                            addMarker("<%= item.PostalCode %>", "<%= item.username %>", "<%= item.address %>", "<%= item.id%>", "<%= item.itemname %>", <%= item.latitude %>, <%= item.longitude %>, "<%= item.rtype %>", "<%= item.estate %>");
                        <% } %>
                    <% } %>

            infoWindow.open(map);
        }      

        //Add markers to map
        function addMarker(postalcode, user, addr, itemid, item, LatValue, LngValue, rtype, estate) {

            //console.log("marker");
            var infowindow = new google.maps.InfoWindow;
            var service = new google.maps.places.PlacesService(map);
            var iconurl;

            if (rtype == "Plastics") {
                iconurl = "http://maps.google.com/mapfiles/ms/icons/red-dot.png";
            }

            else if (rtype == "Metals") {
                iconurl = "http://maps.google.com/mapfiles/ms/icons/blue-dot.png";
            }

            else if (rtype == "Paper") {
                iconurl = "http://maps.google.com/mapfiles/ms/icons/yellow-dot.png";
            }

            else if (rtype == "Electronics") {
                iconurl = "http://maps.google.com/mapfiles/ms/icons/purple-dot.png";
            }

            else if (rtype == "Batteries/Bulbs") {
                iconurl = "http://maps.google.com/mapfiles/ms/icons/pink-dot.png";
            }

            var marker = new google.maps.Marker({
                position: { lat: parseFloat(LatValue), lng: parseFloat(LngValue) },
                map: map,
                icon: {
                    url: iconurl,
                    scaledSize: new google.maps.Size(45, 45),
                }
            });

            markerArray.push(marker);
            markerCluster.addMarker(marker);

            google.maps.event.addListener(marker, 'click', function () {
                infowindow.setContent('<div>' + "<strong>User</strong> : " + user + "<br>" + '<strong>Zipcode : </strong>' + postalcode +
                    '<br>' + "<strong>Address</strong>: " + addr + "<br>" + "<strong>Estate</strong>: " + estate + "<br>" +
                    "<strong>Item : </strong>" + item + '<br>' + '</div>');
                infowindow.open(map, this);
            });

        }

    </script>

    <script src="https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/markerclusterer.js">
    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyABeTLZq3IydVrWOAKPgxo1lpKLlpUj4I4&libraries=places&callback=initMap">
    </script>
</asp:Content>
