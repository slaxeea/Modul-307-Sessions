using System;
using System.Web.Mvc;

namespace BBBaden_M307_Sessions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string input)
        {
            Session.Remove("input");
            Session.Remove("correct");
            Session.Add("input", input);

            int guess = 0;
            int counter = Convert.ToInt32(Session["counter"])+1;
            Session.Add("counter", counter);
            int number = Convert.ToInt32(Session["number"]);

            try
            {
                guess = Convert.ToInt32(input);
            }
            catch
            {
                Session.Add("text", "Incorrect input lol");
            }
            if (!String.IsNullOrEmpty(input) && guess != 0)
            {
                if (guess > number)
                {
                    Session.Add("text", "Input was too big");
                    Session.Add("correct", "not correct");
                }
                if (guess < number)
                {
                    Session.Add("text", "Input was too small");
                    Session.Add("correct", "not correct");
                }
                if (guess == number)
                {
                    Session.Add("text", "Your guess was correct");
                    Session.Add("correct", "correct");
                }
            }
            else
            {
                Session.Add("text", "Invalid input lol");
            }

            return View();
        }
    }
}