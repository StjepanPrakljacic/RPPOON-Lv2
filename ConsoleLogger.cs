using System;
using System.Collections.Generic;
using System.Text;

namespace lv_2
{
    class ConsoleLogger : ILogger
    {
        public void Log(ILogable data)
        {
            Console.WriteLine(data.GetStringRepresentation());
        }
    }
}
