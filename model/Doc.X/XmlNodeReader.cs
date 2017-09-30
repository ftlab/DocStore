using Doc.Core;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Doc.X
{
    public class XmlNodeReader : INodeReader
    {
        private readonly XmlReader _reader;

        public XmlNodeReader(XmlReader reader)
        {
            _reader = reader;
        }

        public XmlReader Reader => _reader;

        public void Dispose()
        {

        }

        public IEnumerable<INode> Read()
        {
            while (Reader.Read())
            {
                if (Reader.NodeType == XmlNodeType.Attribute)
                {
                    foreach (var node in ReadAttribute(Reader))
                        yield return node;
                }
            }
            yield break;
        }

        private IEnumerable<INode> ReadAttribute(XmlReader reader)
        {
            yield return new Node()
            {

            };
        }
    }
}
