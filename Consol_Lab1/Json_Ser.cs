using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Consol_Lab1
{
    public class Json_Ser: ISer
    {
        public void Serialize(object obj, StreamWriter stream)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Type type = obj.GetType();
            string res = JsonSerializer.Serialize(obj, obj.GetType(), options) + "\n";
            stream.Write(res);
        }
    }
}
