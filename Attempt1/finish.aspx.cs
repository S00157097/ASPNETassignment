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
                if (CheckAnswers())
                {
                    // Working Here
                    string[] data = ReturnedData();
                }
            }
        }





        protected bool CheckAnswers()
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

            return success;
        }




        protected string[] ReturnedData()
        {
            // And Working Here
            return new string[] {
                score.ToString(),
                // Time Spent
                Application["Visits"].ToString()
                // Average Score
            };
        }
    }
}