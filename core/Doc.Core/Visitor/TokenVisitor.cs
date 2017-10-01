using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Посетитель токенов
    /// </summary>
    public abstract class TokenVisitor : ITokenVisitor
    {
        /// <summary>
        /// Посетить считыватель
        /// </summary>
        /// <param name="reader"></param>
        public virtual void Visit(ITokenReader reader)
        {
            foreach (var token in reader.Read())
            {
                try
                {
                    if (token.Type == TokenType.StartProperty)
                        VisitStartProperty((StartPropertyToken)token);
                    else if (token.Type == TokenType.EndProperty)
                        VisitEndProperty((EndPropertyToken)token);
                    else if (token.Type == TokenType.StartObject)
                        VisitStartObject((StartObjectToken)token);
                    else if (token.Type == TokenType.EndObject)
                        VisitEndObject((EndObjectToken)token);
                    else if (token.Type == TokenType.StartAttribute)
                        VisitStartAttribute((StartAttributeToken)token);
                    else if (token.Type == TokenType.EndAttribute)
                        VisitEndAttribute((EndAttributeToken)token);
                    else if (token.Type == TokenType.Null)
                        VisitNull((NullToken)token);
                    else if (token.Type == TokenType.String)
                        VisitString((StringToken)token);
                }
                catch (Exception e)
                {
                    TokenVisitException.Raise(token, reader, e);
                }
            }
        }

        /// <summary>
        /// Посетить строку
        /// </summary>
        /// <param name="token"></param>
        protected abstract void VisitString(StringToken token);

        /// <summary>
        /// Посетить Null ссылку
        /// </summary>
        /// <param name="token"></param>
        protected abstract void VisitNull(NullToken token);

        /// <summary>
        /// Посетить окончание атрибута
        /// </summary>
        /// <param name="token"></param>
        protected abstract void VisitEndAttribute(EndAttributeToken token);

        /// <summary>
        /// Посетить начало атрибута
        /// </summary>
        /// <param name="token"></param>
        protected abstract void VisitStartAttribute(StartAttributeToken token);

        /// <summary>
        /// Посетить окончание объекта
        /// </summary>
        /// <param name="token"></param>
        protected abstract void VisitEndObject(EndObjectToken token);

        /// <summary>
        /// Посетить начало объекта
        /// </summary>
        /// <param name="token"></param>
        protected abstract void VisitStartObject(StartObjectToken token);

        /// <summary>
        /// Посетить окончание свойства
        /// </summary>
        /// <param name="token"></param>
        protected abstract void VisitEndProperty(EndPropertyToken token);

        /// <summary>
        /// Посетить начало свойства
        /// </summary>
        /// <param name="token"></param>
        protected abstract void VisitStartProperty(StartPropertyToken token);
    }

}
