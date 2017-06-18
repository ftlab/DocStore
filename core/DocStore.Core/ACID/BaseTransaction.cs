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

        private readonly string _source;

        protected BaseTransaction(
            string source)
            : this(Guid.NewGuid().ToString(), source)
        {

        }

        protected BaseTransaction(
            string name
            , string source)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _source = source;
        }

        public virtual string Name => _name;

        public virtual string Source => _source;

        public abstract void Commit();

        public abstract void Rollback();

        public abstract void Dispose();
    }
}
