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
        static Dictionary<int, string[]> questions = new Dictionary<int, string[]>()
        {
            {1, new[] { "How much is 2 + 2?", "0", "1 + 1 + 1 + 1", "???", "7"} },
            {2, new[] { "Which number is the biggest?", "10", "5", "100", "7"} },
            {3, new[] { "What is the capital of France?", "Paris", "Germany", "Moscow", "Dublin"} },
            {4, new[] { "How to spell \"Dog\"?", "Dawg", "Dog", "Cat", "Haund"} },
            {5, new[] { "What is H2O?", "Water", "Fire", "Air", "Sand"} },
            {6, new[] { "Which animal can fly?", "Penguin", "Rhino", "Pancake", "Parrot"} }
        };



        protected string GetQueryString()
        {
            return (Request.QueryString["q"] != null) ? Request.QueryString["q"] : "1";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string q = GetQueryString();

            if (!IsPostBack)
            {
                title.Text = string.Format("Quiz - Question {0}", q);
                h1.InnerHtml = string.Format("Question {0}", q);


            }

            if (GetQueryString() == "1")
                btnPrevious.Enabled = false;

            else if (GetQueryString() == "6")
                btnNext.Enabled = false;

            CreateTable(6);
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

                foreach (RadioButton opt in lstOptions.Items)
                {
                    if (opt.Text == options[Convert.ToInt32(GetQueryString()) - 1])
                        opt.Checked = true;
                }
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
            string[] answers = new string[6];
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
            Response.Redirect(string.Format("quiz.aspx?q={0}", NewPage(false)));
        }

        protected int NewPage(bool less)
        {
            int q = Convert.ToInt32(GetQueryString());

            if (less)
                q = (q == 1) ? 6 : --q;
            else
                q = (q == 6) ? 1 : ++q;

            return q;
        }
    }
}