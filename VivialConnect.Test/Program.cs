using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using NUnitLite;
using VivialConnect.Mappings;

namespace VivialConnect.Test
{
    class Program
    {
        static int Main(string[] args)
        {            
            return new AutoRun(typeof(VcTest).GetTypeInfo().Assembly).Execute(args);
        }
    }
}
