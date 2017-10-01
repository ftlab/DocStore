using Doc.Core;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Doc.X
{
    /// <summary>
    /// Считыватель токенов из XML
    /// </summary>
    public class XTokenReader : ITokenReader
    {
        /// <summary>
        /// Считыватель XML
        /// </summary>
        private readonly XmlReader _reader;

        /// <summary>
        /// Стэк элементов
        /// </summary>
        private readonly Stack<Element> _elements = new Stack<Element>();

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="reader"></param>
        public XTokenReader(XmlReader reader)
        {
            _reader = reader;
        }

        /// <summary>
        /// Считыватель документов
        /// </summary>
        public XmlReader Reader
            => _reader;

        /// <summary>
        /// Номер строки
        /// </summary>
        public int LineNumber
            => ((IXmlLineInfo)Reader)?.LineNumber ?? 0;

        /// <summary>
        /// Позиция в строке
        /// </summary>
        public int LinePosition
            => ((IXmlLineInfo)Reader)?.LinePosition ?? 0;

        /// <summary>
        /// Очистка ресурсов
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Считать токены
        /// </summary>
        /// <returns></returns>
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
            }
            yield break;
        }

        /// <summary>
        /// Токены при чтении окончания элемента
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IToken> OnEndElement()
        {
            var element = _elements.Peek();

            if (element.ComplexContent)
                yield return EndObjectToken.Instance;

            yield return new XEndPropertyToken()
            {
                Name = Reader.LocalName,
                Namespace = Reader.NamespaceURI
            };

            _elements.Pop();
        }

        /// <summary>
        /// Токены при чтении текста
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IToken> OnText()
        {
            yield return new StringToken()
            {
                Value = Reader.Value,
            };
        }

        /// <summary>
        /// Токены при чтении начала элемента
        /// </summary>
        /// <returns></returns>
        private IEnumerable<IToken> OnElement()
        {
            Element prev = null;
            if (_elements.Count > 0)
                prev = _elements.Peek();
            Element curr = new Element() { Name = Reader.LocalName };
            _elements.Push(curr);

            if (prev != null && prev.ComplexContent == false)
            {
                yield return StartObjectToken.Instance;
                prev.ComplexContent = true;
            }

            yield return new XStartPropertyToken()
            {
                Name = Reader.LocalName,
                Namespace = Reader.NamespaceURI,
            };

            if (Reader.HasAttributes)
            {
                yield return StartObjectToken.Instance;
                curr.ComplexContent = true;

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

                if (curr.ComplexContent)
                    yield return EndObjectToken.Instance;

                yield return new XEndPropertyToken()
                {
                    Name = Reader.LocalName,
                    Namespace = Reader.NamespaceURI,
                };

                _elements.Pop();
            }
        }

        /// <summary>
        /// Содержит информацию о строке
        /// </summary>
        /// <returns></returns>
        public bool HasLineInfo()
            => ((IXmlLineInfo)Reader)?.HasLineInfo() ?? false;


        /// <summary>
        /// Элемент XML
        /// </summary>
        private class Element
        {
            /// <summary>
            /// Имя элемента
            /// </summary>
            public string Name;

            /// <summary>
            /// Сложный контент
            /// </summary>
            public bool ComplexContent;
        }
    }
}
