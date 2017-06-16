using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.ACID
{
    /// <summary>
    /// Бзовая транзакция
    /// </summary>
    public abstract class BaseTransaction : ITransaction
    {
        /// <summary>
        /// Имя транзакции
        /// </summary>
        private readonly string _name;

        protected BaseTransaction()
            : this(Guid.NewGuid().ToString())
        {

        }

        protected BaseTransaction(
            string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public virtual string Name => _name;

        public abstract void Commit();

        public abstract void Rollback();

        public abstract void Dispose();

        void ITransaction.Commit() =>
            Commit();

        void ITransaction.Rollback() =>
            Rollback();

        void IDisposable.Dispose() =>
            Dispose();
    }
}
