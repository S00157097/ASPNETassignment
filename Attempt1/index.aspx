<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Attempt1.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Begin The Quiz</title>

    <meta name="author" content="Dmitrijs Savostijanovs" />
    <meta name="description" content="Main page where you need to sign up to begin a simple quiz." />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>

    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet" />
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <div id="wrap">
        <nav></nav>
        <header></header>

        <main>
            <h1>Enter Your Details</h1>

            <form runat="server" id="formSignUp">

                <ul>
                    <!-- LABEL - CONTROL - REQUIRED? - REGEX? -->
                    <li>
                        <asp:Label runat="server" ID="lblFirstName" Text="First Name" AssociatedControlID="txtFirstName" />
                        <asp:TextBox runat="server" ID="txtFirstName" placeholder="First Name" />
                        <asp:RequiredFieldValidator runat="server" ID="reqFirstName" ErrorMessage="First Name Is Required" ControlToValidate="txtFirstName" Display="None" />
                        <asp:RegularExpressionValidator runat="server" ID="regexFirstName" ValidationExpression="^[A-Za-z '-]+$" ErrorMessage="Invalid First Name" ControlToValidate="txtFirstName" Display="None" />
                    </li>

                    <li>
                        <asp:Label runat="server" ID="lblLastName" Text="Last Name" AssociatedControlID="txtLastName" />
                        <asp:TextBox runat="server" ID="txtLastName" placeholder="Last Name" />
                        <asp:RequiredFieldValidator runat="server" ID="reqLastName" ErrorMessage="Last Name Is Required" ControlToValidate="txtLastName" Display="None" />
                        <asp:RegularExpressionValidator runat="server" ID="regexLastName" ValidationExpression="^[A-Za-z '-]+$" ErrorMessage="Invalid Last Name" ControlToValidate="txtLastName" Display="None" />
                    </li>

                    <li>
                        <asp:Label runat="server" ID="lblEmail" Text="Email" AssociatedControlID="txtEmail" />
                        <asp:TextBox runat="server" ID="txtEmail" placeholder="someone@mail.com" />
                        <asp:RequiredFieldValidator runat="server" ID="reqEmail" ErrorMessage="Email Is Required" ControlToValidate="txtEmail" Display="None" />
                        <asp:RegularExpressionValidator runat="server" ID="regexMail" ValidationExpression="^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[a-z]{2,}$" ErrorMessage="Invalid Email" ControlToValidate="txtEmail" Display="None" />
                        <!-- Regex: (Any letters/numbers and other characters)@(letters, numbers, dot, dash)+dot2 or more letters -->
                    </li>

                    <li>
                        <asp:Label runat="server" ID="lblNationality" Text="Nationality" AssociatedControlID="lstNationality" />
                        <asp:DropDownList runat="server" ID="lstNationality" />
                    </li>
                </ul>

                <asp:Button CssClass="button" runat="server" ID="btnSubmit" Text="Start The Quiz" />

                <asp:ValidationSummary CssClass="validation" runat="server" ID="valSummary" DisplayMode="List" ShowSummary="true" ShowMessageBox="false" />
            </form>
        </main>

        <footer>Dmitrijs Savostijanovs 2016</footer>
    </div>
</body>
</html>
