using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public abstract class BaseToken : IToken
    {
        public abstract TokenType Type { get; }

        public override string ToString()
        {
            return $"{Type}";
        }
    }
}
