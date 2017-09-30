using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public interface IToken
    {
        TokenType Type { get; }

        string Path { get; }

        object Value { get; }
    }
}
