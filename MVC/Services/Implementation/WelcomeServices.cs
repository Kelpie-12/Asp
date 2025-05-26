namespace MVC.Services.Implementation
{
    public class WelcomeServices : IWelcomeServices
    {

        public string GetMessage()
        {
            string res = string.Empty;
            if (DateTime.Now.Hour >= 5 && DateTime.Now.Hour <= 10)
            {
                res = "Доброе утро!";
            }
            else if (DateTime.Now.Hour >= 11 & DateTime.Now.Hour <= 17)
            {
                res = "Добрый день!";
            }
            else if (DateTime.Now.Hour >= 18 & DateTime.Now.Hour <= 22)
            {
                res = "Добрый вечер!";
            }
            else if (DateTime.Now.Hour >= 23 & DateTime.Now.Hour >= 4)
            {
                res = "Доброй ночи!";
            }
            else
            {
                res = "Error";
            }
            return res;
        }
    }
}
