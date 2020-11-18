using System;
using System.Threading;
using tracer_lib;

namespace Tests
{
    class Slow_Class
    {
        private ITracer tracer;

        public Slow_Class(ITracer tracer)
        {
            this.tracer = tracer;
        }

        public void Slow()
        {
            tracer.StartTrace();
            Console.WriteLine("Slow");
            Thread.Sleep(50);
            tracer.StopTrace();
        }

        public void SuperSlow()
        {
            tracer.StartTrace();
            Console.WriteLine("SuperSlow");
            Thread.Sleep(100);
            Slow();
            Slow();
            Slow();
            tracer.StopTrace();

        }
    }
}