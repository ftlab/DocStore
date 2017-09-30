using Doc.Core;
using System;
using System.Xml;

namespace Doc.X
{
    public class XReader : IReader
    {
        private readonly XmlReader _reader;

        public XReader(XmlReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public XmlReader Reader => _reader;

        public NodeType NodeType
        {
            get
            {
                if (Reader.NodeType == XmlNodeType.None)
                    return NodeType.None;
                else if (Reader.NodeType == XmlNodeType.Element)
                    return NodeType.Property;
                else if (Reader.NodeType == XmlNodeType.Attribute)
                    return NodeType.Property;
                else if (Reader.NodeType == XmlNodeType.Text)
                    return NodeType.Value;
                else throw new NotSupportedException(Reader.NodeType.ToString());
            }
        }

        public string PropertyName => Reader.LocalName;

        public bool Read()
        {
            bool? skip = Reader.Read();
            while (skip == true)
            {
                if (
                       Reader.NodeType == XmlNodeType.CDATA
                    || Reader.NodeType == XmlNodeType.Comment
                    || Reader.NodeType == XmlNodeType.DocumentType
                    || Reader.NodeType == XmlNodeType.EndEntity
                    || Reader.NodeType == XmlNodeType.Entity
                    || Reader.NodeType == XmlNodeType.EntityReference
                    || Reader.NodeType == XmlNodeType.None
                    || Reader.NodeType == XmlNodeType.Notation
                    || Reader.NodeType == XmlNodeType.ProcessingInstruction
                    || Reader.NodeType == XmlNodeType.SignificantWhitespace
                    || Reader.NodeType == XmlNodeType.Whitespace
                    || Reader.NodeType == XmlNodeType.XmlDeclaration)
                    skip = Reader.Read();
                else if (
                    Reader.NodeType == XmlNodeType.Attribute
                    || Reader.NodeType == XmlNodeType.Document
                    || Reader.NodeType == XmlNodeType.Element
                    || Reader.NodeType == XmlNodeType.EndElement
                    )
                    skip = null;
                else throw new NotSupportedException(Reader.NodeType.ToString());
            }
            return skip ?? true;
        }



    }
}
