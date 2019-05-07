<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="collection.aspx.cs" Inherits="Our_FYPJ2019.collection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .coverimage {
            width: 100px;
            height: 80px;
            padding: 0px
        }

        .hiddencol {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <br />

        <div class="row">
            <div class="col-sm">


                <div class="card">
                    <div class="card-header">
                        Venue details
                    </div>
                    <div class="card-body">
                        <blockquote class="blockquote mb-0">
                            <h5 runat="server" id="lbldate"></h5>
                            <hr />

                            <asp:Label ID="lbltimeslot" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:Label ID="lbladdress" runat="server" Text=""></asp:Label>
                        </blockquote>
                    </div>
                </div>



            </div>
        </div>

        <br />

        <!-- gridview -->
        <div class="row">
            <div class="col-sm">
                <asp:GridView ID="dateGVno" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" ShowFooter="true" OnRowCommand="dateGVno_RowCommand">
                    <Columns>

                        <asp:BoundField DataField="itemname" HeaderText="Item" />

                        <asp:ImageField DataImageUrlField="img1" HeaderText="Image">
                            <ControlStyle CssClass="coverimage" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>

                        <asp:ImageField DataImageUrlField="img2" HeaderText="Image">
                            <ControlStyle CssClass="coverimage" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>

                        <asp:ImageField DataImageUrlField="img3" HeaderText="Image">
                            <ControlStyle CssClass="coverimage" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>

                        <asp:ImageField DataImageUrlField="img4" HeaderText="Image">
                            <ControlStyle CssClass="coverimage" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:ImageField>

                        <asp:BoundField DataField="price" HeaderText="Price" />
                        <asp:BoundField DataField="unitno" HeaderText="Unit no" />

                        <asp:TemplateField HeaderText="quoteid" Visible="False">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("quoteid") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblquoteid" runat="server" Text='<%# Bind("quoteid") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="collectone" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" runat="server" CausesValidation="false" CommandName="collectone" Text="Collect" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <EditItemTemplate>
                                <asp:CheckBox ID="CBcollect" runat="server" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CBcollect" runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="btnallcollect" runat="server" Text="Collect All" OnClick="btnallcollect_Click" />
                            </FooterTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <br />
        <br />

        <div class="row">
            <div class="col-sm-3">
                <asp:LinkButton ID="linkhomepage" runat="server" OnClick="linkhomepage_Click">Back to Timeslot page</asp:LinkButton>
            </div>
        </div>

    </div>

</asp:Content>
