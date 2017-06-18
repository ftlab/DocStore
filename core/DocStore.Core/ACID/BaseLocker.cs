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
    /// <typeparam name="TSource">тип источника</typeparam>
    public abstract class BaseLocker<TObject, TSource> : ILocker<TObject, TSource>
        where TSource : class
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
        ITransaction ILocker<TObject, TSource>.Transaction => Transaction;

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
        /// <param name="source">источник</param>
        protected virtual void GainLock(
            TObject obj
            , LockType lockType
            , TSource source = null) =>
            GainLock(Enumerable.Repeat(obj, 1), lockType, source);

        /// <summary>
        /// Усилить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        protected abstract void GainLock(
            IEnumerable<TObject> objs
            , LockType lockType
            , TSource source = null);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        protected virtual void SetLock(
            TObject obj
            , LockType lockType
            , TSource source = null) =>
            SetLock(Enumerable.Repeat(obj, 1), lockType, source);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        protected abstract void SetLock(
            IEnumerable<TObject> objs
            , LockType lockType
            , TSource source = null);

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        void ILocker<TObject, TSource>.ClearLock(
            TObject obj) =>
            ClearLock(obj);

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        void ILocker<TObject, TSource>.ClearLock(
            IEnumerable<TObject> objs) =>
            ClearLock(objs);

        /// <summary>
        /// Усилить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        void ILocker<TObject, TSource>.GainLock(
            TObject obj
            , LockType lockType
            , TSource source) =>
            GainLock(obj, lockType, source);

        /// <summary>
        /// Усилить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        void ILocker<TObject, TSource>.GainLock(
            IEnumerable<TObject> objs
            , LockType lockType
            , TSource source) =>
            GainLock(objs, lockType, source);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        void ILocker<TObject, TSource>.SetLock(
            TObject obj
            , LockType lockType
            , TSource source) =>
            SetLock(obj, lockType, source);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="objs">объекты</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        void ILocker<TObject, TSource>.SetLock(
            IEnumerable<TObject> objs
            , LockType lockType
            , TSource source) =>
        SetLock(objs, lockType, source);
    }
}
