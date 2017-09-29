using Doc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
