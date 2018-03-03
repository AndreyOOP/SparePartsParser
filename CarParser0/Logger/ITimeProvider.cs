using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarParser0.Logger
{
    public interface ITimeProvider
    {
        string getCurrentTime();
    }
}
