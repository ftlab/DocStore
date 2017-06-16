using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.ACID
{
    /// <summary>
    /// Транзакция
    /// </summary>    
    public interface ITransaction : IDisposable
    {
        /// <summary>
        /// Имя транзакции
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Принять изменения
        /// </summary>
        void Commit();

        /// <summary>
        /// Откатить изменения
        /// </summary>
        void Rollback();
    }
}
