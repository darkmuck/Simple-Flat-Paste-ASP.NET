<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="Simple_Paste_Bin._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-size: medium;
        }
        .style2
        {
            font-size: medium;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="mainDiv" class="style1" runat="server">
    
        <strong style="font-size: medium">Simple Flat Paste
        <br />
        <span id="spanErrorMessage" runat="server"></span>
        <br />
        </strong><span class="style2">Subject:<br />
        </span>
        <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
        <br />
        <br />
        <span class="style2">Text:</span><br />
        <span class="style2">
        <asp:TextBox ID="txtText" runat="server" Height="320px" TextMode="MultiLine" 
            Width="549px"></asp:TextBox>
        <br />
        <br />
        </span>
        <asp:Button ID="btnPaste" runat="server" Text="Paste" />


        <br />
    
        <br />
        
        Pastes:

    </div>
    </form>
</body>
</html>
