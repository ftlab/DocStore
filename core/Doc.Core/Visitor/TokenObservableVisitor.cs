using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Наблюдаемый посетитель токенов
    /// </summary>
    public class TokenObservableVisitor : TokenVisitor
    {
        /// <summary>
        /// Наблюдатель токенов
        /// </summary>
        public ITokenObserver Observer { get; set; }

        /// <summary>
        /// Посетить считыватель токенов
        /// </summary>
        /// <param name="reader"></param>
        public override void Visit(ITokenReader reader)
        {
            Observer?.OnStartVisit();

            base.Visit(reader);

            Observer?.OnEndVisit();
        }

        /// <summary>
        /// Посетить окончание атрибута
        /// </summary>
        /// <param name="token"></param>
        protected override void VisitEndAttribute(EndAttributeToken token) => Observer?.OnEndAttribute(token);

        /// <summary>
        /// Постетить окончание объекта
        /// </summary>
        /// <param name="token"></param>
        protected override void VisitEndObject(EndObjectToken token) => Observer?.OnEndObject(token);

        /// <summary>
        /// Посетить окончание свойства
        /// </summary>
        /// <param name="token"></param>
        protected override void VisitEndProperty(EndPropertyToken token) => Observer?.OnEndProperty(token);

        /// <summary>
        /// Посетить Null ссылку
        /// </summary>
        /// <param name="token"></param>
        protected override void VisitNull(NullToken token) => Observer?.OnNull(token);

        /// <summary>
        /// Посетить начало атрибута
        /// </summary>
        /// <param name="token"></param>
        protected override void VisitStartAttribute(StartAttributeToken token) => Observer?.OnStartAttribute(token);

        /// <summary>
        /// Посетить начало объекта
        /// </summary>
        /// <param name="token"></param>
        protected override void VisitStartObject(StartObjectToken token) => Observer?.OnStartObject(token);

        /// <summary>
        /// Посетить начало свойства
        /// </summary>
        /// <param name="token"></param>
        protected override void VisitStartProperty(StartPropertyToken token) => Observer?.OnStartProperty(token);

        /// <summary>
        /// Посетить строку
        /// </summary>
        /// <param name="token"></param>
        protected override void VisitString(StringToken token) => Observer?.OnString(token);
    }
}
