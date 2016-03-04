using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attempt1
{
    public partial class quiz : Page
    {
        // Question, Options
        public static Dictionary<int, string[]> questions = new Dictionary<int, string[]>()
        {
            {1, new[] { "How much is 2 + 2?", "0", "???", "7", "1 + 1 + 1 + 1" } },
            {2, new[] { "Which number is the biggest?", "10", "5", "7", "100" } },
            {3, new[] { "What is the capital of France?", "Germany", "Moscow", "Dublin", "Paris" } },
            {4, new[] { "How to spell \"Dog\"?", "Dawg", "Cat", "Haund", "Dog" } },
            {5, new[] { "What is H2O?", "Fire", "Air", "Sand", "Water" } },
            {6, new[] { "Which animal can fly?", "Penguin", "Rhino", "Pancake", "Parrot"} }
        };





        protected string GetQueryString()
        {
            return (Request.QueryString["q"] != null) ? Request.QueryString["q"] : "1";
        }





        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            Application["Visits"] = (int)Application["Visits"] + 1;
            Application.UnLock();

            string q = GetQueryString();

            if (!IsPostBack)
            {
                title.Text = string.Format("Quiz - Question {0}", q);
                h1.InnerHtml = string.Format("Question {0}", q);
            }


            if (GetQueryString() == "1")
                btnPrevious.Enabled = false;

            else if (GetQueryString() == (questions.Count).ToString())
                btnNext.Text = "Finish";


            CreateTable(questions.Count);
            InsertQuestion(Convert.ToInt32(q));
        }





        protected void InsertQuestion(int index)
        {
            txtQuestion.InnerHtml = questions[index][0];


            for (int i = 1; i < questions[index].Length; i++)
                lstOptions.Items.Add(questions[index][i]);


            if (Session["Answers"] != null)
            {
                string[] options = (string[])Session["Answers"];

                for (int i = 0; i < lstOptions.Items.Count; i++)
                    if (lstOptions.Items[i].Text == options[Convert.ToInt32(GetQueryString()) - 1])
                        lstOptions.Items[i].Selected = true;
            }
        }





        protected void CreateTable(int rowsParam)
        {
            byte counter = 1;


            var headerText = new TableHeaderCell();
            headerText.Text = "Qs";
            headerText.ColumnSpan = 3;

            var header = new TableHeaderRow();
            header.Cells.Add(headerText);
            lstQuestions.Rows.Add(header);


            for (int rows = 1; rows <= rowsParam; rows++)
            {
                TableRow row = new TableRow();
                lstQuestions.Rows.Add(row);

                TableCell cell = new TableCell();
                cell.Text = string.Format("<a href=\"quiz.aspx?q={0}\">{0}</a>", counter);

                row.Cells.Add(cell);

                counter++;
            }
        }





        protected void StoreInSession()
        {
            string[] answers = (Session["Answers"] != null) ? (string[]) Session["Answers"] : new string[6];

            answers[Convert.ToInt32(GetQueryString()) - 1] = lstOptions.SelectedValue;

            Session["Answers"] = answers;
        }





        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            StoreInSession();
            Response.Redirect(string.Format("quiz.aspx?q={0}", NewPage(true)));
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            StoreInSession();

            if (GetQueryString() != questions.Count.ToString())
                Response.Redirect(string.Format("quiz.aspx?q={0}", NewPage(false)));
            else
                Response.Redirect("finish.aspx");
        }





        protected int NewPage(bool less)
        {
            int q = Convert.ToInt32(GetQueryString());

            if (less)
                q = (q == 1) ? questions.Count : --q;
            else
                q = (q == questions.Count) ? 1 : ++q;

            return q;
        }
    }
}