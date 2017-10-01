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

        private readonly Stack<Element> _elements = new Stack<Element>();

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
                var currentNode = Reader.NodeType;

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

                PrevNode = currentNode;
            }
            yield break;
        }

        private IEnumerable<IToken> OnEndElement()
        {

            if (PrevNode == XmlNodeType.EndElement)
                yield return EndObjectToken.Instance;

            yield return new XEndPropertyToken()
            {
                Name = Reader.LocalName,
                Namespace = Reader.NamespaceURI
            };

            _elements.Pop();
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
            _elements.Push(new Element() { Name = Reader.LocalName });


            if (PrevNode == XmlNodeType.Element)
                yield return StartObjectToken.Instance;

            yield return new XStartPropertyToken()
            {
                Name = Reader.LocalName,
                Namespace = Reader.NamespaceURI,
            };

            if (Reader.HasAttributes)
            {
                for (int i = 0; i < Reader.AttributeCount; i++)
                {
                    Reader.MoveToAttribute(i);

                    yield return new XStartAttributeToken()
                    {
                        Name = Reader.LocalName,
                        Namespace = Reader.NamespaceURI,
                    };

                    yield return new StringToken()
                    {
                        Value = Reader.Value,
                    };

                    yield return new XEndAttributeToken()
                    {
                        Name = Reader.LocalName,
                        Namespace = Reader.NamespaceURI,
                    };
                }
            }

            if (Reader.IsEmptyElement)
            {
                yield return NullToken.Instance;

                yield return new XEndPropertyToken()
                {
                    Name = Reader.LocalName,
                    Namespace = Reader.NamespaceURI,
                };

                _elements.Pop();
            }
        }

        public bool HasLineInfo()
            => ((IXmlLineInfo)Reader)?.HasLineInfo() ?? false;


        private class Element
        {
            public string Name;

            public bool SimpleContent = true;
        }
    }
}
