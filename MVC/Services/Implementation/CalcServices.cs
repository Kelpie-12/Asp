using MVC.Model;

namespace MVC.Services.Implementation
{
    public class CalcServices : ICalcServices
    {
        public double Division(Calculator c)
        {
            if (c.B != 0)
            {
                return c.Total = c.A / c.B;
            }
            else
            {
                c.ErrorMessage = "На ноль делить нельзя";
            }
            return 0;
        }

        public double Minus(Calculator c)
        {
            return c.Total = c.A - c.B;
        }

        public double Multi(Calculator c)
        {
            return c.Total = c.A * c.B;
        }

        public double Sum(Calculator c)
        {
            return c.Total = c.A + c.B;
        }
    }
}
