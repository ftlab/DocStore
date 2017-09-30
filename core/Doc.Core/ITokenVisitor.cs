using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public interface ITokenVisitor
    {
        void Visit(ITokenReader reader);
    }
}
