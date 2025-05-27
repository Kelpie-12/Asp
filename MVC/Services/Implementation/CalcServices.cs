namespace MVC.Services.Implementation
{
    public class CalcServices : ICalcServices
    {
        public double Division(double a, double b)
        {
            if (a==0)
            {
                throw new Exception("На ноль делить нельзя");
                //  return -1;
            }
            else
            {
                return a / b;
            }
        }

        public double Minus(double a, double b)
        {
            return a - b;
        }

        public double Multi(double a, double b)
        {
            return a * b;
        }

        public double Sum(double a, double b)
        {
            return a + b;
        }
    }
}
