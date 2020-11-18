using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consol_Lab1
{
    public interface ISer
    {
        void Serialize(object ibj, StreamWriter stream);
    }
}
