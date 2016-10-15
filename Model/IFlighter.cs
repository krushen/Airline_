using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelMVP
{
    interface IFlighter
    {
        void PrintHeader();
        void PrintStringInColor();
        void PrintHeaderTop(bool isTrue);
    }
}
