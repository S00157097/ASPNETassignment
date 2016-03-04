<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="quiz.aspx.cs" Inherits="Attempt1.quiz" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title runat="server" id="title"></title>

    <meta name="author" content="Dmitrijs Savostijanovs" />
    <meta name="description" content="Quiz page where all the questions appear." />
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
            <h1 runat="server" id="h1"></h1>

            <form runat="server" id="formQuiz">
                <div class="flex">
                    <asp:Table runat="server" ID="lstQuestions" />

                    <div class="container">
                        <h3 runat="server" id="txtQuestion"></h3>

                        <asp:RadioButtonList runat="server" ID="lstOptions" RepeatLayout="OrderedList" />

                        <div class="flex nav">
                            <asp:Button CssClass="nav-button" runat="server" ID="btnPrevious" Text="<< Back" OnClick="btnPrevious_Click" />
                            <asp:Button CssClass="nav-button" runat="server" ID="btnNext" Text="Save >>" OnClick="btnNext_Click" />
                        </div>
                    </div>

                </div>
            </form>
        </main>

        <footer>Dmitrijs Savostijanovs 2016</footer>
    </div>
</body>
</html>

