<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Our_FYPJ2019.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type ="text/javascript">
 
        function choose() {
            var types = document.getElementById('<%=ddltypes.ClientID%>');
            var ddltypes = types.options[types.selectedIndex].text;
            var ddlplastic = document.getElementById('<%=ddlplastic.ClientID%>'); //dropdownlist
            var ddlbatt = document.getElementById("<%=ddlbatteries.ClientID%>");
            var ddlpaper = document.getElementById("<%=ddlpaper.ClientID%>");
            var ddlmetal = document.getElementById("<%= ddlmetal.ClientID%>");
            var ddlelec = document.getElementById("<%=ddlelectronics.ClientID%>");

            var plastic = document.getElementById('<%= plastics.ClientID%>');
            var metal = document.getElementById('<%=metal.ClientID%>');
            var paper = document.getElementById('<%=paper.ClientID%>');
            var batteries = document.getElementById('<%=batteries.ClientID%>');
            var electronics = document.getElementById('<%=electronics.ClientID%>');

            if (ddltypes == "Metals") {
                metal.style.display = "";
                paper.style.display = "none";
                batteries.style.display = "none";
                electronics.style.display = "none";
                plastic.style.display = "none";
                
            }

            else if (ddltypes == "Paper") {
                paper.style.display = "";
                metal.style.display = "none";
                batteries.style.display = "none";
                electronics.style.display = "none";
                plastic.style.display = "none";
               
            }

            else if (ddltypes == "Batteries/Bulbs") {
                paper.style.display = "none";
                metal.style.display = "none";
                batteries.style.display = "";
                electronics.style.display = "none";
                plastic.style.display = "none";
                
            }

            else if (ddltypes == "Electronics") {
                paper.style.display = "none";
                metal.style.display = "none";
                batteries.style.display = "none";
                electronics.style.display = "";
                plastic.style.display = "none";
                
            }

            else if (ddltypes == "Plastics") {
                paper.style.display = "none";
                metal.style.display = "none";
                batteries.style.display = "none";
                electronics.style.display = "none";
                plastic.style.display = "";
                plastictype.style.display = "";
                
            }

           
        }
        
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }

        <%--$("#<%=btnSubmit.ClientID%>").click(function (e) {
           var img = document.getElementById('<%=imgUpload.ClientID%>');
            if (img.files.length > 4) {
                e.preventDefault();
            }
         
        }--%>

      
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
     
     <h2>Listing</h2>
    <br />
    
     <%--<form id="fm_contact" runat="server" class="form-horizontal">--%>
         <% foreach (var item in itemList) { %>
         <div class="form-group">
            <asp:Label runat="server" for="tbitem" ID="lbitem" CssClass="control-label">Item name : </asp:Label>
                 <asp:TextBox ID="tbitem" runat="server" CssClass="form-control">

                 </asp:TextBox><asp:RequiredFieldValidator ID="nameval" runat="server" ErrorMessage="Item name is required" ForeColor ="red" Text ="*" ControlToValidate="tbitem"></asp:RequiredFieldValidator>
         </div>

         <div class="form-group">
            
            <asp:Label runat="server" for="ddltypes" ID="lbltypes" CssClass="control-label" Text="Recyclable Types : ">
            </asp:Label>
            <asp:DropDownList ID="ddltypes" CssClass ="form-control" runat="server" onchange="choose();return false">
                <asp:ListItem Value =""></asp:ListItem>
                <asp:ListItem Text= "Plastics" Value ="1"></asp:ListItem>
                <asp:ListItem Text="Paper" Value ="2"></asp:ListItem>
                <asp:ListItem Text="Metals" Value ="3"></asp:ListItem>
                <asp:ListItem Text= "Batteries/Bulbs" Value ="4"></asp:ListItem>
                <asp:ListItem Text= "Electronics" Value ="5"></asp:ListItem>
            </asp:DropDownList>
              <asp:RequiredFieldValidator ID="typeval" runat="server" ErrorMessage="Types is needed" Text ="*" ControlToValidate="ddltypes" ForeColor ="red"></asp:RequiredFieldValidator>
         </div>
          
         <% if (item.rtype == "Plastics") { %>
          <!-- plastics -->
         <div class ="form-group" runat ="server" id ="plastics"> 
                  <asp:label runat="server" id="lblplastic" cssclass="control-label" text="Plastic types : ">
                   </asp:label>
                   <asp:dropdownlist id="ddlplastic" cssclass ="form-control" runat="server" onchange ="choose()">
                        <asp:listitem Value ="" Text =""></asp:listitem>
                        <asp:listitem Text ="Plastic bottles" value ="1"></asp:listitem>
                        <asp:listitem Text ="Plastic utensils" value ="2"></asp:listitem>
                        <asp:listitem Text ="Plastic containers" value ="3"></asp:listitem>
                        <asp:listitem Text ="Plastic bags" value ="4"></asp:listitem>
                        <asp:listitem Text ="Squeezable bottles" value ="5"></asp:listitem>
                    </asp:dropdownlist>
                 <%-- <asp:RequiredFieldValidator ID="ptypeval" runat="server" ErrorMessage="Plastic Types is needed" Text ="*" ControlToValidate="ddlplastic" ForeColor ="red"></asp:RequiredFieldValidator>--%>
         </div>

         <% } else if (item.rtype == "Paper") { %>

         <!-- paper-->
         <div class="form-group" runat ="server" id ="paper">
             <asp:label runat="server" id="lblpaper" cssclass="control-label" text="Paper Type : ">
                   </asp:label>
                    <asp:dropdownlist id="ddlpaper" cssclass ="form-control" runat="server">
                        <asp:listitem Value ="" Text =""></asp:listitem>
                        <asp:listitem Text ="newspaper" value ="1"></asp:listitem>
                        <asp:listitem Text ="cardboard" value ="2"></asp:listitem>
                        <asp:listitem Text ="white computer paper" value ="3"></asp:listitem>
                        <asp:listitem Text ="magazine" value ="4"></asp:listitem>
                        <asp:listitem Text ="coloured office paper" value ="5"></asp:listitem>
                    </asp:dropdownlist>
             <%--<asp:RequiredFieldValidator ID="paperval" runat="server" ErrorMessage="An item is needed" Text ="*" ControlToValidate="ddlpaper" ForeColor ="red"></asp:RequiredFieldValidator>--%>
         </div>

         <% } else if (item.rtype == "Metals") { %>
         <!--metals-->
         <div class="form-group" runat ="server" id ="metal">
            <asp:label runat="server" id="lblmetal" cssclass="control-label" text="Metal Type ">
                </asp:label>
                 <asp:dropdownlist id="ddlmetal" cssclass ="form-control" runat="server">
                    <asp:listitem Value =""></asp:listitem>
                    <asp:listitem Text ="Canned drinks/foods" value ="1"></asp:listitem>
                    <asp:listitem Text ="Frying pans" value ="3"></asp:listitem>
                    <asp:listitem Text ="Woks" value ="4"></asp:listitem>
                    <asp:listitem Text ="Cooking bowls" value ="5"></asp:listitem>
                    <asp:listitem Text ="tin" value ="5"></asp:listitem>
                </asp:dropdownlist>
             <%--<asp:RequiredFieldValidator ID="metalval" runat="server" ErrorMessage="An item is needed" Text ="*" ControlToValidate="ddlmetal" ForeColor ="red"></asp:RequiredFieldValidator>--%>
         </div>
        
         <% } else if (item.rtype == "Batteries/Bulbs") { %>
         <!-- batteries -->
          <div class="form-group" runat ="server" id ="batteries">
            <asp:label runat="server" id="lblbatteries" cssclass="control-label" text="Batteries Type : ">
                </asp:label>
                <asp:dropdownlist id="ddlbatteries" cssclass ="form-control" runat="server">
                    <asp:listitem Value ="" Text =""></asp:listitem>
                    <asp:listitem Text ="lead batteries" value ="0"></asp:listitem>
                    <asp:listitem Text ="nickel-cadmium batteries" value ="1"></asp:listitem>
                    <asp:listitem Text ="lithium-ion batteries" value ="2"></asp:listitem>
                    <asp:listitem Text ="alkaline batteries" value ="3"></asp:listitem>
                    <asp:listitem Text ="nickel-metal-hydride batteries" value ="4"></asp:listitem>
                </asp:dropdownlist>
              <%--<asp:RequiredFieldValidator ID="battval" runat="server" ErrorMessage="An item is needed" Text ="*" ControlToValidate="ddlbatteries" ForeColor ="red"></asp:RequiredFieldValidator>--%>
         </div>

         <% } else if (item.rtype == "Electronics") { %>
         <!--electronics-->
          <div class="form-group" runat ="server" id ="electronics">
            <asp:label runat="server" id="lblelectronics" cssclass="control-label" text="Electronics Type : ">
                </asp:label>
                <asp:dropdownlist id="ddlelectronics" cssclass ="form-control" runat="server">
                    <asp:listitem Value ="" Text =""></asp:listitem>
                    <asp:listitem Text ="computers (cpus, monitors, peripherals, keyboards)" value ="0"></asp:listitem>
                    <asp:listitem Text ="office equipment (photocopiers, printers, fax machines)" value ="1"></asp:listitem>
                    <asp:listitem Text ="televisions" value ="2"></asp:listitem>
                    <asp:listitem Text ="consumer electronics (vcrs, stereos, home/office phones)" value ="3"></asp:listitem>
                    <asp:listitem Text ="cell phones" value ="4"></asp:listitem>
                </asp:dropdownlist>
              <%--<asp:RequiredFieldValidator ID="elecval" runat="server" ErrorMessage="An item is needed" Text ="*" ControlToValidate="ddlelectronics" ForeColor ="red"></asp:RequiredFieldValidator>--%>
              <br />
         </div>
         <%}  %>

         <!--weight-->
         <% if (item.rtype != "Plastics") { %>
         <div class="form-group" runat="server" id ="weight">
             <asp:Label runat="server" ID="lblweight" CssClass="control-label">Weight : </asp:Label>
             <div class="input-group mb-3">
            
                <asp:TextBox ID="tbweight" runat="server" CssClass="form-control" onkeypress="return isNumber(event)"></asp:TextBox>
                <div class="input-group-append">
                    <span class="input-group-text" id="basic-addon2">Kg</span>
                </div>
             
            </div> 
             <asp:RangeValidator ID="weightrval" runat="server" ErrorMessage="Min weight is 5kg" ControlToValidate="tbweight" MinimumValue="5" MaximumValue="100000000" ForeColor="red" Type="Integer" ></asp:RangeValidator>
         </div>
         <% } else { %>

             <div class ="form-group" runat="server" id ="qty">
                <asp:Label runat="server" ID="lblqty" CssClass="control-label">Quantity : </asp:Label>
                <asp:TextBox ID="tbqty" runat="server" CssClass="form-control" onkeypress="return isNumber(event)"></asp:TextBox>
                 <asp:RangeValidator ID="qtyrval" runat="server" ErrorMessage="Min quantity is 50" ForeColor="red" MinimumValue="50" MaximumValue="10000000" ControlToValidate="tbqty" Type="Integer" ></asp:RangeValidator>
             </div>

         <% } %>

         <div class="form-group" >
             <asp:Label ID="lbldesc" runat="server" for="tadesc" CssClass="control-label" Text="Description : ">
             </asp:Label>
             <textarea id="tadesc" runat="server" class="form-control" rows="4" cols="20"></textarea>
             <asp:RequiredFieldValidator ID="descval" runat="server" ErrorMessage="Description is required" ForeColor="Red" Text="*" ControlToValidate="tadesc"></asp:RequiredFieldValidator>
         </div>

         <div class="row">
            <div class="col-sm-6">
                <asp:Label runat="server"  ID="lbladdress" CssClass="control-label">Address</asp:Label>
                 <asp:TextBox ID="tbaddress" runat="server" CssClass="form-control" placeholder="Enter Full address" ></asp:TextBox>
             <asp:RequiredFieldValidator ID="addval" runat="server" ErrorMessage="Address is required" ForeColor ="Red" Text ="*" ControlToValidate ="tbaddress"></asp:RequiredFieldValidator>
            </div>

            <div class="col-sm-6">
                 <asp:Label runat="server" ID="lblpc" CssClass="control-label">Postal code : </asp:Label>
                <asp:TextBox ID="tbpc" runat="server" CssClass="form-control" onkeypress="return isNumber(event)"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="pcval" runat="server" ErrorMessage="Postal Code is Required" ForeColor ="Red" Text ="*" ControlToValidate ="tbpc"></asp:RequiredFieldValidator>
                 <asp:RegularExpressionValidator ID="rpostalcodeval" runat="server" ErrorMessage="Invalid Postal Code" ControlToValidate ="tbpc" ValidationExpression ="\d{6}"></asp:RegularExpressionValidator>
            </div>
        </div>

       
          <div class ="row">
             <div class ="col-sm-6">
                 <asp:label runat="server" id="Label1" cssclass="control-label" text="Estates : ">
                </asp:label>
                <asp:dropdownlist id="ddlestate" cssclass ="form-control" runat="server">
                    <asp:listitem Value =""></asp:listitem>
                    <asp:listitem Text ="Ang Mo Kio" ></asp:listitem>
                    <asp:listitem Text ="Bukit Timah"></asp:listitem>
                    <asp:listitem Text ="Bukit Batok"></asp:listitem>
                    <asp:listitem Text ="Bukit Panjang"></asp:listitem>
                    <asp:listitem Text ="Bukit Merah"></asp:listitem>
                    <asp:listitem Text ="Bishan"></asp:listitem>
                    <asp:listitem Text ="Bedok"></asp:listitem>
                    <asp:listitem Text ="Choa Chu Kang"></asp:listitem>
                    <asp:listitem Text ="Clementi"></asp:listitem>
                    <asp:listitem Text ="Geylang"></asp:listitem>
                    <asp:listitem Text ="Hougang" ></asp:listitem>
                    <asp:listitem Text ="Jurong West" ></asp:listitem>
                    <asp:listitem Text ="Jurong East" ></asp:listitem>
                    <asp:listitem Text ="Kallang" ></asp:listitem>
                    <asp:listitem Text ="Marina Parade" ></asp:listitem>
                    <asp:listitem Text ="Punggol" ></asp:listitem>
                    <asp:listitem Text ="Pasir Ris" ></asp:listitem>
                    <asp:listitem Text ="Queenstown" ></asp:listitem>
                    <asp:listitem Text ="Sembawang" ></asp:listitem>
                    <asp:listitem Text ="SengKang" ></asp:listitem>
                    <asp:listitem Text ="Serangoon" ></asp:listitem>
                    <asp:listitem Text ="Tao Payoh" ></asp:listitem>
                    <asp:listitem Text ="Tampines" ></asp:listitem>
                    <asp:listitem Text ="Woodlands" ></asp:listitem>
                    <asp:listitem Text ="Yishun" ></asp:listitem>

                </asp:dropdownlist>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Estates is required" ForeColor ="Red" Text ="*" ControlToValidate ="ddlestate"></asp:RequiredFieldValidator>
             </div>

             <div class ="col-sm-6">
                 <asp:Label runat="server" ID="lblunitnum" CssClass="control-label">Unit number : </asp:Label>
                 <div class ="input-group mb-3">
                     <div class="input-group-prepend">
                         <span class="input-group-text" id="basic-addon1">#</span>
                     </div>
                    <asp:TextBox ID="tbunitnum" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
                 <asp:RequiredFieldValidator ID="runitnumval" runat="server" ErrorMessage="Unit number is required" ForeColor ="Red" Text ="*" ControlToValidate ="tbunitnum"></asp:RequiredFieldValidator>
             </div>
             
         </div>
         <div class ="row">
             <div class ="col-sm-3">
                 <asp:HiddenField ID="himg" runat="server" Value ="1"/>
                 <asp:Label ID="lblimg" runat="server" Text="" ForeColor ="red"></asp:Label>
                 <asp:FileUpload ID="imgUpload" AllowMultiple="true" CssClass ="form-control-file" runat="server" /> <!--onchange="previewFile()"-->
                 <asp:RequiredFieldValidator ID="imgval" runat="server" ErrorMessage="Image is required" Text ="*" ForeColor ="red" ControlToValidate="imgUpload"></asp:RequiredFieldValidator>
                 <%--<asp:Image ID="img1dp" runat="server" />
                 <asp:Image ID="img2dp" runat="server" />
                 <asp:Image ID="img3dp" runat="server" />
                 <asp:Image ID="img4dp" runat="server" />--%>

            <br />
            <br />
                
             </div>
             
         </div>
         <div class ="row">
             <div class ="col-sm-1">
                  <asp:Button ID="btnSubmit" runat="server" CssClass ="btn btn-success" Text="Edit" OnClick="btnSubmit_Click" />
             </div>
         </div>

          <% } %>
    <%--</form>--%>
   
 </div>
</asp:Content>

