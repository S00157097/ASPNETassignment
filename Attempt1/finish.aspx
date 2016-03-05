<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="finish.aspx.cs" Inherits="Attempt1.finish" EnableViewState="true" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Finish</title>

    <meta name="author" content="Dmitrijs Savostijanovs" />
    <meta name="description" content="Last page." />
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
            <h1>You've Finished The Quiz</h1>

            <asp:Label runat="server" ID="lblScore" />
            <br />
            <asp:Label runat="server" ID="lblTimeSpent" />
            <br />
            <asp:Label runat="server" ID="lblTotalPeople" />
            <br />
            <asp:Label runat="server" ID="lblAverage" />

            <form runat="server" id="formFinish">
                <asp:Button runat="server" ID="btnAgain" Text="Repeat The Quiz" OnClick="btnAgain_Click" />
            </form>
        </main>

        <footer>Dmitrijs Savostijanovs 2016</footer>
    </div>
</body>
</html>
