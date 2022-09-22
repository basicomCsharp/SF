using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public interface ILogger
    {
        public void Event(string message);
        public void Error(string message);

    }
}
