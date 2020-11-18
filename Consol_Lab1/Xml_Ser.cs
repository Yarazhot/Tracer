using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Consol_Lab1
{
    public class Xml_Ser: ISer
    {
        public void Serialize(object obj, StreamWriter stream)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            xmlSerializer.Serialize(stream, obj, ns);
            stream.WriteLine("\n");
            stream.Flush();
        }
    }
}
