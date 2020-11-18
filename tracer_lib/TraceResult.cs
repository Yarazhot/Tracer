using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace tracer_lib
{
    [XmlRoot("root")]
    public class TraceResult
    {
        [XmlElement("thread")]
        [JsonPropertyName("threads")]
        public List<Thread_Info> trace_result { get; set; }
        public TraceResult() 
        {
        }
        public TraceResult(List<Thread_Info> results)
        {
            trace_result = results;
        }
    }
}
