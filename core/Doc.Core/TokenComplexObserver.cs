using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Комплексный наблюдатель токенов
    /// </summary>
    public class TokenComplexObserver : ITokenObserver
    {
        /// <summary>
        /// наблюдатели
        /// </summary>
        public readonly List<ITokenObserver> Observers = new List<ITokenObserver>();

        /// <summary>
        /// Добавить наблюдателя
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public TokenComplexObserver Add(ITokenObserver observer)
        {
            Observers.Add(observer);
            return this;
        }

        /// <summary>
        /// Окончание атрибута
        /// </summary>
        /// <param name="token"></param>
        public virtual void OnEndAttribute(EndAttributeToken token) => Observers.ForEach(o => o.OnEndAttribute(token));

        /// <summary>
        /// Окончание объекта
        /// </summary>
        /// <param name="token"></param>
        public virtual void OnEndObject(EndObjectToken token) => Observers.ForEach(o => o.OnEndObject(token));

        /// <summary>
        /// Окончание свойства
        /// </summary>
        /// <param name="token"></param>
        public virtual void OnEndProperty(EndPropertyToken token) => Observers.ForEach(o => o.OnEndProperty(token));

        /// <summary>
        /// Окончание посещения
        /// </summary>
        public virtual void OnEndVisit() => Observers.ForEach(o => o.OnEndVisit());

        /// <summary>
        /// Null ссылка
        /// </summary>
        /// <param name="token"></param>
        public virtual void OnNull(NullToken token) => Observers.ForEach(o => o.OnNull(token));

        /// <summary>
        /// Начало атрибута
        /// </summary>
        /// <param name="token"></param>
        public virtual void OnStartAttribute(StartAttributeToken token) => Observers.ForEach(o => o.OnStartAttribute(token));

        /// <summary>
        /// Начало объекта
        /// </summary>
        /// <param name="token"></param>
        public virtual void OnStartObject(StartObjectToken token) => Observers.ForEach(o => o.OnStartObject(token));

        /// <summary>
        /// Начало свойства
        /// </summary>
        /// <param name="token"></param>
        public virtual void OnStartProperty(StartPropertyToken token) => Observers.ForEach(o => o.OnStartProperty(token));

        /// <summary>
        /// Начало посещения
        /// </summary>
        public virtual void OnStartVisit() => Observers.ForEach(o => o.OnStartVisit());

        /// <summary>
        /// Строка
        /// </summary>
        /// <param name="token"></param>
        public virtual void OnString(StringToken token) => Observers?.ForEach(o => o.OnString(token));
    }
}
