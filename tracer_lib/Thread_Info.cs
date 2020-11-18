using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace tracer_lib
{
    public class Thread_Info
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string time { get; set; }
        [XmlElement("method")]
        public List<Method_Info> methods { get; set; }
        public Thread_Info()
        {
        }
        public Thread_Info(int id)
        {
            this.id = id.ToString();
        }
    }
}
