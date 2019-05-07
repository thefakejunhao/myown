<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="slot.aspx.cs" Inherits="Our_FYPJ2019.slot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <br />
        <div class="row">
            <div class="col-sm">
                <div class="card" style="width: 30rem;">
                    <div class="card-body">
                        <div class="container">
                            <br />
                            <h5 runat="server" id="title"></h5>
                            <hr />
                            <!-- 9am - 12pm -->
                            <div class="row">
                                <div class="col-sm">
                                    <div class="card" style="width: 18rem;" runat="server" id="li1" visible="false">
                                        <div class="card-header">
                                            9am - 12pm
                                        </div>
                                        <ul class="list-group list-group-flush" runat="server" id="slot1">
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <!-- 1pm to 4pm -->
                            <div class="row">
                                <div class="col-sm">
                                    <div class="card" style="width: 18rem;" runat="server" id="li2" visible="false">
                                        <div class="card-header">
                                            1pm - 4pm
                                        </div>
                                        <ul class="list-group list-group-flush" runat="server" id="slot2">
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <!-- 4pm to 7pm -->
                            <div class="row">
                                <div class="col-sm">
                                    <div class="card" style="width: 18rem;" runat="server" id="li3" visible="false">
                                        <div class="card-header">
                                            4pm - 7pm
                                        </div>
                                        <ul class="list-group list-group-flush" runat="server" id="slot3">
                                        </ul>
                                    </div>
                                </div>
                            </div>

                            <!-- 8pm to 10pm -->
                            <div class="row">
                                <div class="col-sm">
                                    <div class="card" style="width: 18rem;" runat="server" id="li4" visible="false">
                                        <div class="card-header">
                                            8pm - 10pm
                                        </div>
                                        <ul class="list-group list-group-flush" runat="server" id="slot4">
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
