<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mortgage_Calculator._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="height: 703px; width: 810px; margin-left: 15%; margin-top: 20px; margin-right: 15%;">
      
        <div style="height: 50px">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label1" runat="server" Text="Mortgage Amount"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="176px" TextMode="Number" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </div>
        </div>


        <div style="height: 50px">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
             <asp:Label ID="Label2" runat="server" Text="Length of Years"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="176px" TextMode="Number" OnTextChanged="TextBox2_TextChanged" ></asp:TextBox>
        </div>
        </div>


        <div style="height: 50px; margin-top: 0px;">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label3" runat="server" Text="Payments per Year"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="TextBox3" runat="server" Height="20px" Width="176px" TextMode="Number" OnTextChanged="TextBox3_TextChanged" ></asp:TextBox>
        </div>
        </div>


        <div style="height: 50px">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
            <asp:Label ID="Label4" runat="server" Text="Down Payment"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="TextBox4" runat="server" Height="20px" Width="176px" TextMode="Number" OnTextChanged="TextBox4_TextChanged" ></asp:TextBox>
        </div>
        </div>


         <div style="height: 50px">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
                <asp:Label ID="Label7" runat="server" Text="Interest Rate(%)"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="TextBox7" runat="server" Height="20px" Width="176px" TextMode="Number" OnTextChanged="TextBox7_TextChanged" ></asp:TextBox>
        </div>
        </div>

        <div style="height: 50px">
        <div style="height: 29px; width: 160px; margin-left: 9px; margin-top: 19px;">
                <asp:Button ID="Button3" runat="server" Text="Show Min. Payment" Height="27px" Width="146px" OnClick="Button3_Click" />
        </div>
        <div style="height: 0px; margin-top: -28px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="TextBox5" runat="server" Height="20px" Width="176px"></asp:TextBox>
        </div>
        </div>


        <div style="height: 50px">
        <div style="height: 21px; width: 160px; margin-left: 9px; margin-top: 19px;">
                <asp:Label ID="Label6" runat="server" Text="Additional Payments"></asp:Label>
        </div>
        <div style="height: 0px; margin-top: -22px; width: 223px; margin-left: 200px;">          
            <asp:TextBox ID="TextBox6" runat="server" Height="20px" Width="176px" TextMode="Number" OnTextChanged="TextBox6_TextChanged" ></asp:TextBox>
        </div>
        </div>


        <div style="height: 35px">
            <div style="height: 30px; margin-top: 4px; width: 223px; margin-left: 200px;">          
                <asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Recurring Increment" EnableViewState="False"/>
            </div>
        </div>


        <div style="margin-top: 0px">
            <div style="width: 184px; margin-top: 16px; height: 33px;">
                <asp:Button ID="Button1" runat="server" Text="Calculate" Height="27px" Width="118px" OnClick="Button1_Click" />
            </div>
            <div style="width: 184px; margin-top: -28px; height: 33px; margin-left: 220px;">
                <asp:Button ID="Button2" runat="server" Text="Reset" Height="27px" Width="118px" OnClick="Button2_Click" />
            </div>
        </div>        

        <asp:Table ID="Table1" runat="server" GridLines="Both" CellPadding="1" CellSpacing="1" Height="146px" Width="720px">
        </asp:Table>

    </div>

    
   
</asp:Content>
