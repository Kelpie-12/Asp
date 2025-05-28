using MVC.Model;

namespace MVC.Services
{
    public interface ICalcServices
    {
        double Sum(Calculator c);
        double Minus(Calculator c);
        double Division(Calculator c);
        double Multi(Calculator c);
    }
}
