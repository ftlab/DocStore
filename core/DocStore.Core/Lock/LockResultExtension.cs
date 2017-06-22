using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.Lock
{
    /// <summary>
    /// Доп. методы к результату получения блокировки
    /// </summary>
    public static class LockResultExtension
    {

        /// <summary>
        /// Успешное получение блокировки
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool IsGranted(this LockResult result)
        {
            if (result >= 0)
                return true;

            return false;
        }
    }
}
