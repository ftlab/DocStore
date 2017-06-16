using DocModel.Core;
using System;
using System.Collections.Generic;
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
        protected abstract BaseTransaction Transaction { get; }

        /// <summary>
        /// Транзакция
        /// </summary>
        ITransaction ILocker<TObject, TSource>.Transaction => Transaction;

        /// <summary>
        /// Удалить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        protected abstract void ClearLock(
            TObject obj);

        /// <summary>
        /// Усилить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        protected abstract void GainLock(
            TObject obj
            , LockType lockType
            , TSource source = null);

        /// <summary>
        /// Установить блокировку
        /// </summary>
        /// <param name="obj">объект</param>
        /// <param name="lockType">тип блокировки</param>
        /// <param name="source">источник</param>
        protected abstract void SetLock(
            TObject obj
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
    }
}
