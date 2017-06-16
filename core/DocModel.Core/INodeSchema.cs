using System;
using System.Collections.Generic;
using System.Text;

namespace DocModel.Core
{
    /// <summary>
    /// определение
    /// </summary>
    public interface INodeSchema
    {
        NodeType Type { get; }

        IDictionary<string, INodeSchema> Properties { get; }
    }
}
