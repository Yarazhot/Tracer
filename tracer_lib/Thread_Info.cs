using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tracer_lib
{
    public class Thread_Info
    {
        public string id;
        public string time;
        public List<Method_Info> methods;
        public Thread_Info(int id)
        {
            this.id = id.ToString();
        }
    }
}
