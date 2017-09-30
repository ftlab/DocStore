using Doc.Core;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Doc.X
{
    public class XTokenReader : ITokenReader
    {
        private readonly XmlReader _reader;

        private XmlNodeType _prevNode = XmlNodeType.None;

        public XTokenReader(XmlReader reader)
        {
            _reader = reader;
        }

        public XmlReader Reader
            => _reader;

        public XmlNodeType PrevNode
        { get => _prevNode; private set => _prevNode = value; }

        public int LineNumber
            => ((IXmlLineInfo)Reader)?.LineNumber ?? 0;

        public int LinePosition
            => ((IXmlLineInfo)Reader)?.LinePosition ?? 0;

        public void Dispose()
        {

        }

        public IEnumerable<IToken> Read()
        {
            while (Reader.Read())
            {
                if (Reader.NodeType == XmlNodeType.XmlDeclaration
                    || Reader.NodeType == XmlNodeType.None
                    || Reader.NodeType == XmlNodeType.Whitespace
                    || Reader.NodeType == XmlNodeType.SignificantWhitespace)
                    continue;
                else if (Reader.NodeType == XmlNodeType.Element)
                {
                    foreach (var token in OnElement())
                        yield return token;
                }
                else if (Reader.NodeType == XmlNodeType.EndElement)
                {
                    foreach (var token in OnEndElement())
                        yield return token;
                }
                else if (Reader.NodeType == XmlNodeType.Text)
                {
                    foreach (var token in OnText())
                        yield return token;
                }
                else throw new NotSupportedException(Reader.NodeType.ToString());

                PrevNode = Reader.NodeType;
            }
            yield break;
        }

        private IEnumerable<IToken> OnEndElement()
        {
            yield return new XEndPropertyToken()
            {
                Name = Reader.LocalName,
                Namespace = Reader.NamespaceURI
            };
        }

        private IEnumerable<IToken> OnText()
        {
            yield return new StringToken()
            {
                Value = Reader.Value,
            };
        }

        private IEnumerable<IToken> OnElement()
        {
            yield return new XStartPropertyToken()
            {
                Name = Reader.LocalName,
                Namespace = Reader.NamespaceURI,
            };
            if (Reader.IsEmptyElement)
            {
                yield return NullToken.Instance;

                yield return new XEndPropertyToken()
                {
                    Name = Reader.LocalName,
                    Namespace = Reader.NamespaceURI,
                };
            }
        }

        public bool HasLineInfo()
            => ((IXmlLineInfo)Reader)?.HasLineInfo() ?? false;
    }
}
