<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="mapdirection.aspx.cs" Inherits="Our_FYPJ2019.mapdirection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
        #map {
            height: 800px;
            width: 100%
        }

        /* Optional: Makes the sample page fill the window. */
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">


        <br />
        <div class="row">
            <div class="col-sm">
                <h6 runat="server" id="lbldate"></h6>
                <hr />
                <asp:Label ID="lbltimeslot" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <br />

        <div class="row">
            <div class="col-sm">
                <div id="map"></div>
            </div>

            <div class="col-sm-1"></div>

            <!-- directions -->
            <div class="col-sm-4" id="directiontext" runat="server">
                <div id="right-panel"></div>

                <asp:Button ID="btnarrive" runat="server" Text="Arrived" OnClick="btnarrive_Click" CssClass="btn btn-success" />
            </div>

        </div>

        <script>

            var map, infoWindow, Marker;
            function initMap() {

                map = new google.maps.Map(document.getElementById('map'), {
                    zoom: 12,
                    center: { lat: 1.3521, lng: 103.8198 }
                });

                infoWindow = new google.maps.InfoWindow;
                var rightpanels = document.getElementById('right-panel');//right panel
                var directionsService = new google.maps.DirectionsService();
                var directionsDisplay = new google.maps.DirectionsRenderer({
                    preserveViewport: true
                });

                directionsDisplay.setMap(map);
                directionsDisplay.setPanel(rightpanels);

                // Try HTML5 geolocation.
                if (navigator.geolocation) {
                    navigator.geolocation.watchPosition(function (position) {

                        var pos = {
                            lat: position.coords.latitude,
                            lng: position.coords.longitude
                        };

                        Marker = new google.maps.Marker({
                            position: { 
                                lat: position.coords.latitude, lng: position.coords.longitude 
                            },
                            map: map,
                        });

                        calculatepath(directionsService, directionsDisplay, position.coords.latitude, position.coords.longitude);
                        reachdestination(position);
                        infoWindow.setPosition(pos);
                        infoWindow.setContent('Your Location.');
                        infoWindow.open(map);

                    }, function () {
                        handleLocationError(true, infoWindow, map.getCenter());
                    });
                } else {
                    // Browser doesn't support Geolocation
                    handleLocationError(false, infoWindow, map.getCenter());
                }

            }

            function reachdestination(postition) {
                if (postition.coords.latitude == <%= targetlat %> && postition.coords.longitude == <%= targetlng %>) {
                    alert("reached");
                }

                else {
                    alert("havent reached!");
                }
            }

            function handleLocationError(browserHasGeolocation, infoWindow) {
                infoWindow.setPosition(pos);
                infoWindow.setContent(browserHasGeolocation ?
                    'Error: The Geolocation service failed.' :
                    'Error: Your browser doesn\'t support geolocation.');
                infoWindow.open(map);
            }

            function calculatepath(directionsService, directionsDisplay, slat, slng) {

                var request = {
                    origin: new google.maps.LatLng(slat, slng),
                    destination: new google.maps.LatLng(<%= destination %>),
                    travelMode: "DRIVING",
                };

                directionsService.route(request, function (result, status) {
                    if (status == 'OK') {
                        directionsDisplay.setDirections(result);
                    }

                    else {
                        window.alert('Directions request failed due to ' + status);
                    }
                });

            }

        </script>

    </div>

    <script async defer
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB8xM6G_kR9WHsJJfTSuvU5W_mszTAF_Ps&callback=initMap">
    </script>
</asp:Content>
