using System;

namespace Doc.Core
{
    /// <summary>
    /// Ошибка посещения токена
    /// </summary>
    public class TokenVisitException : Exception
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="token"></param>
        /// <param name="lineNumber"></param>
        /// <param name="linePosition"></param>
        /// <param name="inner"></param>
        public TokenVisitException(
            IToken token
            , int? lineNumber
            , int? linePosition
            , Exception inner)
            : base($"Ошибка посещения токена ({token}). Строка: {lineNumber}, позиция: {linePosition}. Сообщение: {inner?.Message}."
                  , inner)
        {
        }

        /// <summary>
        /// Вбросить ошибку посещения
        /// </summary>
        /// <param name="token"></param>
        /// <param name="info"></param>
        /// <param name="original"></param>
        /// <returns></returns>
        public static TokenVisitException Raise(
            IToken token
            , ILineInfo info
            , Exception original)
        {
            throw new TokenVisitException(
                token
                , info?.LineNumber
                , info?.LinePosition
                , original);
        }
    }
}
