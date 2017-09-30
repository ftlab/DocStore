using Doc.Core;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Doc.X
{
    public class XTokenReader : ITokenReader
    {
        private readonly XmlReader _reader;

        private readonly Path _path = new Path();

        private XmlNodeType _prevNode = XmlNodeType.None;

        public XTokenReader(XmlReader reader)
        {
            _reader = reader;
        }

        public XmlReader Reader => _reader;

        public Path Path => _path;

        public XmlNodeType PrevNode { get => _prevNode; private set => _prevNode = value; }

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
            
            yield return new Token()
            {
                Path = Path.GetFullPath(),
                Type = TokenType.EndProperty,
            };
            if (Reader.LocalName != Path.Pop())
                throw new NotSupportedException();
        }

        private IEnumerable<IToken> OnText()
        {
            yield return new Token()
            {
                Path = Path.GetFullPath(),
                Type = TokenType.Value,
                Value = Reader.Value,
            };
        }

        private IEnumerable<IToken> OnElement()
        {
            Path.Push(Reader.LocalName);

            yield return new Token()
            {
                Path = Path.GetFullPath(),
                Type = TokenType.StartProperty,
            };
            if (Reader.IsEmptyElement)
            {
                yield return new Token()
                {
                    Path = Path.GetFullPath(),
                    Type = TokenType.Null,
                };
                yield return new Token()
                {
                    Path = Path.GetFullPath(),
                    Type = TokenType.EndProperty
                };
                if (Path.Pop() != Reader.LocalName)
                    throw new NotSupportedException();
            }
        }
    }
}
