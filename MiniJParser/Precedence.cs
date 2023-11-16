using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    internal enum Precedence
    {
        ASSIGNMENT = 1,
        CONDITIONAL = 2,
        SUM = 3,
        PRODUCT = 4,
        EXPONENT = 5,
        PREFIX = 6,
        POSTFIX = 7,
        CALL = 8
    }
}
