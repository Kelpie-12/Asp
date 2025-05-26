using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class CalcController:Controller
    {
        public string Sum(int a,int b)
        {
            int sum = a + b;
            return "" + sum;
        }
    }
}
