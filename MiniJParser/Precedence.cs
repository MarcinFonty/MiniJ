using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniJParser
{
    internal enum Precedence
    {
        ASSIGNMENT = 2,
        CONDITIONAL = 3,
        SUM = 4,
        PRODUCT = 5,
        EXPONENT = 6,
        PREFIX = 7,
        POSTFIX = 8,
        CALL = 9
    }
}
