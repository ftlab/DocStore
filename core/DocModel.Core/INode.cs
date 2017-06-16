using System.Collections.Generic;
using System.ComponentModel;

namespace DocModel.Core
{
    public interface INode : IDictionary<string, INode>, INotifyPropertyChanged
    {
        IDoc Doc { get; }
        INodeInfo Info { get; }
        INode Parent { get; }
        NodeType NodeType { get; }
        INode Previous { get; }
        INode Next { get; }
        void AddAfterSelf(INode node);
        void AddAfterSelf(IEnumerable<INode> nodes);
    }
}
