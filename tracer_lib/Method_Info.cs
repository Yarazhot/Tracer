using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace tracer_lib
{
    public class Method_Info
    {
        public string name;
        public string time;
        public string class_name;
        public Stopwatch stopwatch;
        public List<Method_Info> methods;
    }
}
