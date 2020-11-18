using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Tests;
using tracer_lib;

namespace Consol_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ITracer tracer = new Tracer();
            Unit_Tests.Method1(tracer);
            TraceResult tr = tracer.GetTraceResult();
            ISer j_ser = new Json_Ser();
            ISer x_ser = new Xml_Ser();
            //StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            //sw.AutoFlush = true;
            //Console.SetOut(sw);
            /*j_ser.Serialize(tracer.GetTraceResult(), sw);
            x_ser.Serialize(tracer.GetTraceResult(), sw);
            sw = new StreamWriter(@"D:\a.txt");
            j_ser.Serialize(tracer.GetTraceResult(), sw);
            x_ser.Serialize(tracer.GetTraceResult(), sw);*/
            Console.ReadKey();
        }
    }
}
