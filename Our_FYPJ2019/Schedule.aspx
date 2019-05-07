<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Our_FYPJ2019.Schedule" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .coverimage {
            width: 100px;
            height: 80px;
            padding: 0px
        }
    </style>

    <script>

        //not collected
        function viewno() {
            var no = document.getElementById("GVpartno");
            var yes = document.getElementById("GVpartyes");
            var nodate = document.getElementById("nodatepart");
            var nodate2 = document.getElementById("nodatepart2");
            var collectionbutton = document.getElementById("<%= collectionbutton.ClientID %>");
            no.style.display = "";
            yes.style.display = "none";
            nodate.style.display = "";
            nodate2.style.display = "none";
            collectionbutton.style.display = "";
        }

        //collected
        function viewyes() {
            var no = document.getElementById("GVpartno");
            var yes = document.getElementById("GVpartyes");
            var nodate = document.getElementById("nodatepart");
            var nodate2 = document.getElementById("nodatepart2");
            var collectionbutton = document.getElementById("<%= collectionbutton.ClientID %>");
            no.style.display = "none";
            yes.style.display = "";
            nodate.style.display = "none";
            nodate2.style.display = "";
            collectionbutton.style.display = "none";
        }


        function salert() {
            alert("Successfullly submitted");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" container">
        <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="row">

                    <div class="col-sm">
                        <!-- Calendar -->
                        <asp:Calendar ID="Calendar2" runat="server" ForeColor="Black" Height="500px" NextPrevFormat="ShortMonth" Width="100%" TodayDayStyle-Wrap="True" OnDayRender="Calendar2_DayRender" OnSelectionChanged="Calendar2_SelectionChanged">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" BackColor="#99CCFF" />
                            <DayStyle BackColor="White" BorderColor="Black" BorderStyle="Solid"
                                BorderWidth="1px" HorizontalAlign="Left" VerticalAlign="Top" Height="75"
                                Wrap="True" CssClass="MyCalendarClass" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                            <OtherMonthDayStyle ForeColor="Black" BackColor="Silver" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True"
                                Font-Size="12pt" ForeColor="White" Height="12pt" />
                            <TodayDayStyle BackColor="White" ForeColor="Black" Height="7px" Wrap="True" />
                            <WeekendDayStyle Height="7px" />
                        </asp:Calendar>

                    </div>

                </div>
                <br />

                <!-- Header text -->
                <u>
                    <h5 runat="server" id="cdate"></h5>
                </u>

                <br />

                <!-- TOggle -->
                <div class="row" runat="server" id="toggle" visible="false">
                    <div class="col-sm-3">
                        <button type="button" class="btn btn-outline-dark active" id="viewtable" onclick="viewno()">Not Collected</button>
                        <button type="button" class="btn btn-outline-dark" id="viewmap" onclick="viewyes()">Collected</button>
                    </div>
                    <br />
                </div>

                <br />

                <div class="row" id="GVpartno">
                    <div class="col-sm">

                        <!-- not collected -->
                        <asp:GridView ID="dateGVno" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" ShowFooter="true">
                            <Columns>
                            
                                <asp:BoundField DataField="itemname" HeaderText="Item" />
                                <asp:ImageField DataImageUrlField="img" HeaderText="Image">
                                    <ControlStyle CssClass="coverimage" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ImageField>
                                <asp:BoundField DataField="price" HeaderText="Price" />
                                <asp:BoundField DataField="timeslot" HeaderText="Timeslot" />
                                <asp:BoundField DataField="address" HeaderText="Address" />
                                <asp:BoundField DataField="estate" HeaderText="Estate" />
                                <asp:BoundField DataField="postalcode" HeaderText="Postal code" />
                                <asp:BoundField DataField="unitno" HeaderText="Unit no" />

                                <asp:TemplateField HeaderText="quoteid" Visible="False">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("quoteid") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblquoteid" runat="server" Text='<%# Bind("quoteid") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="reschedule" runat="server" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="reschedule" runat="server" />
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <button type="button" data-toggle="modal" data-target="#exampleModal">
                                            Reschedule All
                                        </button>
                                    </FooterTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </div>
                    
                </div>
                
                <% if (tableListno != null) { %>
                <div class="row">
                    <div class="col-sm-3">
                        <asp:Button ID="collectionbutton" runat="server" Text="Proceed to collection" OnClick="collectionbutton_Click" CssClass="btn btn-danger"  />
                    </div>
                </div>

                <% } %>
                
                <!-- collected -->
                <div class="row" id="GVpartyes" style="display: none">
                    <div class="col-sm">
                        <asp:GridView ID="dateGVyes" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" ShowFooter="true">
                            <Columns>
                                <asp:BoundField DataField="itemname" HeaderText="Item" />
                                <asp:ImageField DataImageUrlField="img" HeaderText="Image">
                                    <ControlStyle CssClass="coverimage" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:ImageField>
                                <asp:BoundField DataField="price" HeaderText="Price" />
                                <asp:BoundField DataField="timeslot" HeaderText="Timeslot" />
                                <asp:BoundField DataField="address" HeaderText="Address" />
                                <asp:BoundField DataField="estate" HeaderText="Estate" />
                                <asp:BoundField DataField="postalcode" HeaderText="Postal code" />
                                <asp:BoundField DataField="unitno" HeaderText="Unit no" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <br />

                <div class="row" id="nodatepart">
                    <div class="col-sm">
                        <asp:Label ID="nodate" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>

                <div class="row" id="nodatepart2" style="display: none">
                    <div class="col-sm">
                        <asp:Label ID="nodate2" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <br />
                    <br />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

        
        
        <br />

        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">

                                <!-- description -->
                                <asp:Label ID="lbltadesc" runat="server" Text="Reason"></asp:Label>
                                <textarea id="tadesc" cols="20" rows="2" style="width: 100%" runat="server"></textarea>
                                <br />
                                <br />

                                <!-- Calendar -->
                                <asp:Label ID="Label1" runat="server" Text="Set collection date : "></asp:Label>
                                <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"></asp:Calendar>

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

                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                <asp:Button ControlID="btnreschedule" runat="server" Text="Reschedule" OnClick="btnreschedule_Click" data-dismiss="modal" OnClientClick="salert();" UseSubmitBehavior="false" />
                            </div>

                        </div>
                    </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
