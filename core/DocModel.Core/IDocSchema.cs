using System;
using System.Collections.Generic;
using System.Text;

namespace DocModel.Core
{
    public interface IDocSchema
    {
        IDocType Type { get; }

        IDictionary<string, INodeSchema> Elements { get; }
    }
}
