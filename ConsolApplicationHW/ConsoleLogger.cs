using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApplicationHW
{
    class ConsoleLogger : ILogger
    {
        public string Log(string message)
        {
            string res = string.Empty;
            res += DateTime.Now;
            res += " - ";
            res += message;
            return res;
        }
    }
}
