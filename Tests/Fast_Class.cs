using System;
using System.Threading;
using tracer_lib;

namespace Tests
{
    public class Fast_Class
    {
        private ITracer tracer;

        public Fast_Class(ITracer tracer)
        {
            this.tracer = tracer;
        }

        public void SuperFast()
        {
            tracer.StartTrace();
            Console.WriteLine("SuperFast");
            tracer.StopTrace();
        }

        public void Fast()
        {
            tracer.StartTrace();
            Console.WriteLine("Fast");
            Thread.Sleep(50);
            SuperFast();
            SuperFast();
            tracer.StopTrace();

        }
    }
}