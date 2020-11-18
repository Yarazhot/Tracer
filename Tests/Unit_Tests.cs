using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using tracer_lib;

namespace Tests
{
    public static class Unit_Tests
    {
        public static void Method1(ITracer tracer)
        {
            //ITracer tracer = new Tracer();
            var slow_class = new Slow_Class(tracer);
            var fast_class = new Fast_Class(tracer);
            Thread thread = new Thread(StartFastMethods);
            thread.Start(tracer);
            slow_class.Slow();
            slow_class.SuperSlow();
            thread.Join();
        }
        public static void StartFastMethods(object tracer)
        {
            var fast_class = new Fast_Class(tracer as ITracer);
            fast_class.Fast();
            fast_class.SuperFast();
            fast_class.Fast();
        }
    }
}
