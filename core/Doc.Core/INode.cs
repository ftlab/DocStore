using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public interface INode
    {
        NodeType Type { get; }

        string Path { get; }

        string Value { get; }
    }
}
