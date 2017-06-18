using DocModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocStore.Core.ACID
{
    /// <summary>
    /// Базовый механизм блокирования
    /// </summary>
    /// <typeparam name="TObject">тип объекта</typeparam>
    public abstract class BaseLocker<TObject> : ILocker<TObject>
    {
        /// <summary>
        /// Транзакция
        /// </summary>
        private readonly BaseTransaction _transaction;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="transaction">транзакция</param>
        protected BaseLocker(
            BaseTransaction transaction)
        {
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
        }

        /// <summary>
        /// Транзакция
        /// </summary>
        protected BaseTransaction Transaction => _transaction;

        /// <summary>
        /// Транзакция
        /// </summary>
        ITransaction ILocker<TObject>.Transaction => Transaction;

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        protected virtual void ClearLock(
            TObject obj) =>
            ClearLock(Enumerable.Repeat(obj, 1));

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        protected abstract void ClearLock(
            IEnumerable<TObject> objs);

        /// <summary>
        /// Усилить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        protected virtual void GainLock(
            TObject obj
            , LockType lockType) =>
            GainLock(Enumerable.Repeat(obj, 1), lockType);

        /// <summary>
        /// Усилить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        protected abstract void GainLock(
            IEnumerable<TObject> objs
            , LockType lockType);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        protected virtual void SetLock(
            TObject obj
            , LockType lockType) =>
            SetLock(Enumerable.Repeat(obj, 1), lockType);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        protected abstract void SetLock(
            IEnumerable<TObject> objs
            , LockType lockType);

        /// <summary>
        /// Очистка ресурсов
        /// </summary>
        void IDisposable.Dispose() =>
            Dispose();

        /// <summary>
        /// Очистка ресурсов
        /// </summary>
        protected abstract void Dispose();

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        void ILocker<TObject>.ClearLock(
            TObject obj) =>
            ClearLock(obj);

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        void ILocker<TObject>.ClearLock(
            IEnumerable<TObject> objs) =>
            ClearLock(objs);

        /// <summary>
        /// Усилить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        void ILocker<TObject>.GainLock(
            TObject obj
            , LockType lockType) =>
            GainLock(obj, lockType);

        /// <summary>
        /// Усилить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        void ILocker<TObject>.GainLock(
            IEnumerable<TObject> objs
            , LockType lockType) =>
            GainLock(objs, lockType);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        void ILocker<TObject>.SetLock(
            TObject obj
            , LockType lockType) =>
            SetLock(obj, lockType);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        void ILocker<TObject>.SetLock(
            IEnumerable<TObject> objs
            , LockType lockType) =>
        SetLock(objs, lockType);
    }
}
