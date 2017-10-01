using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Наблюдатель токенов
    /// </summary>
    public interface ITokenObserver
    {
        /// <summary>
        /// Начало посещения
        /// </summary>
        void OnStartVisit();

        /// <summary>
        /// Окончание посещения
        /// </summary>
        void OnEndVisit();

        /// <summary>
        /// Начало свойства
        /// </summary>
        /// <param name="token"></param>
        void OnStartProperty(StartPropertyToken token);

        /// <summary>
        /// Окончание свойства
        /// </summary>
        /// <param name="token"></param>
        void OnEndProperty(EndPropertyToken token);

        /// <summary>
        /// Окончание объекта
        /// </summary>
        /// <param name="token"></param>
        void OnEndObject(EndObjectToken token);

        /// <summary>
        /// Начало объекта
        /// </summary>
        /// <param name="token"></param>
        void OnStartObject(StartObjectToken token);

        /// <summary>
        /// Начало атрибута
        /// </summary>
        /// <param name="token"></param>
        void OnStartAttribute(StartAttributeToken token);

        /// <summary>
        /// NUll ссылка
        /// </summary>
        /// <param name="token"></param>
        void OnNull(NullToken token);

        /// <summary>
        /// Окончание атрибута
        /// </summary>
        /// <param name="token"></param>
        void OnEndAttribute(EndAttributeToken token);

        /// <summary>
        /// Строка
        /// </summary>
        /// <param name="token"></param>
        void OnString(StringToken token);
    }
}
