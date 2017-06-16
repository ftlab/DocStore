using DocModel.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.ComponentModel;

namespace DocModel.Json
{
    public class JNode : INode
    {
        public INode this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IDoc Doc => throw new NotImplementedException();

        public INodeInfo Info => throw new NotImplementedException();

        public INode Parent => throw new NotImplementedException();

        public NodeType NodeType => throw new NotImplementedException();

        public INode Previous => throw new NotImplementedException();

        public INode Next => throw new NotImplementedException();

        public ICollection<string> Keys => throw new NotImplementedException();

        public ICollection<INode> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Add(string key, INode value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<string, INode> item)
        {
            throw new NotImplementedException();
        }

        public void AddAfterSelf(INode node)
        {
            throw new NotImplementedException();
        }

        public void AddAfterSelf(IEnumerable<INode> nodes)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, INode> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, INode>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, INode>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<string, INode> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(string key, out INode value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
