using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.ACID
{
    /// <summary>
    /// Механизм блокирования
    /// </summary>
    /// <typeparam name="TObject">Тип объекта</typeparam>
    public interface ILocker<TObject> : IDisposable
    {
        /// <summary>
        /// Транзакция
        /// </summary>
        ITransaction Transaction { get; }

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        void SetLock(
            TObject obj
            , LockType lockType);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        void SetLock(
            IEnumerable<TObject> objs
            , LockType lockType);

        /// <summary>
        /// Усиление блокировки
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        void GainLock(
            TObject obj
            , LockType lockType);

        /// <summary>
        /// Усиление блокировки
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        void GainLock(
            IEnumerable<TObject> objs
            , LockType lockType);

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        void ClearLock(
            TObject obj);

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        void ClearLock(
            IEnumerable<TObject> objs);
    }
}
