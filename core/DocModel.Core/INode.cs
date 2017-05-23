using System.ComponentModel;

namespace DocModel.Core
{
    public interface INode : INodeInfo, INotifyPropertyChanged
    {
        IDoc Parent { get; }
        NodeType NodeType { get; }
        INode Previous { get; }
        INode Next { get; }
        void AddAfterSelf(INode node);
        void AddAfterSeolf(IEnumerable<INode> nodes);

    }
}
