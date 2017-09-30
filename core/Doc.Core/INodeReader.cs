using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Считыватель узлов документа
    /// </summary>
    public interface INodeReader : IDisposable
    {
        /// <summary>
        /// Считать
        /// </summary>
        /// <returns></returns>
        IEnumerable<INode> Read();
    }
}
