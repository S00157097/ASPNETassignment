using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attempt1
{
    public partial class finish : System.Web.UI.Page
    {
        protected static int score = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CheckAnswers();

                string[] data = ReturnedData();

                lblScore.Text = string.Format("Score: {0}/{1} = {2}", data[0], quiz.questions.Count, Percentage(Convert.ToInt32(data[0]), quiz.questions.Count));
                lblTimeSpent.Text = string.Format("Time Spent: {0:t}", data[1]);
                lblTotalPeople.Text = string.Format("Total Quiz Visits: {0}", data[2]);

            }
        }





        private string Percentage(int num, int total)
        {
            return string.Format("{0}/{1}", (num * 100) / quiz.questions.Count, (total * 100) / quiz.questions.Count);
        }





        protected void CheckAnswers()
        {
            bool success = false;

            if (Session["Answers"] != null)
            {
                string[] answers = (string[])Session["Answers"];

                for (int i = 0; i < answers.Length; i++)
                {
                    success = (answers[i] == quiz.questions[i + 1][quiz.questions[i + 1].Length - 1]) ? true : false;
                    score += (success) ? 1 : 0;
                }
            }
        }




        protected string[] ReturnedData()
        {
            // And Working Here
            return new string[] {
                score.ToString(),
                (DateTime.Now - (DateTime)Session["Time"] ).ToString(),
                Application["Visits"].ToString()
                // Average Score
            };
        }





        protected void btnAgain_Click(object sender, EventArgs e)
        {
            Session["Answers"] = null;
            Session["Time"] = null;

            Response.Redirect("quiz.aspx?q=1");
        }
    }
}