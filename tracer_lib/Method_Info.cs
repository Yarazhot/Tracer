using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace tracer_lib
{
    public class Method_Info
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string time { get; set; }
        [XmlAttribute("class")]
        [JsonPropertyName("class")]
        public string class_name { get; set; }
        [XmlIgnore]
        public Stopwatch stopwatch;
        [XmlElement("method")]
        public List<Method_Info> methods { get; set; }
        public Method_Info()
        {
        }
    }
}
