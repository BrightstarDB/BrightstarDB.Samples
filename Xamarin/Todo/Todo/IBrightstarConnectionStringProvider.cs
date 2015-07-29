using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo
{
    public interface IBrightstarConnectionStringProvider
    {
        string GetConnectionString();
    }
}
