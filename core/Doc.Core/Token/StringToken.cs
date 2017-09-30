using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public class StringToken : BaseToken
    {
        public override TokenType Type => TokenType.String;

        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}
