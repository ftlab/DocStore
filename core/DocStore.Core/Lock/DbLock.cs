using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DocStore.Core.Lock
{
    /// <summary>
    /// Механизм блокирования в БД
    /// </summary>
    public class DbLock : ILock
    {
        /// <summary>
        /// Транзакция
        /// </summary>
        private DbTransaction _tran;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="tran">транзакция</param>
        public DbLock(DbTransaction tran)
        {
            _tran = tran ?? throw new ArgumentNullException(nameof(tran));
        }

        /// <summary>
        /// Транзакция
        /// </summary>
        public DbTransaction Tran
        {
            get
            {
                if (_disposedValue) throw new ObjectDisposedException(nameof(Tran));
                return _tran;
            }
        }

        /// <summary>
        /// Соединение к БД
        /// </summary>
        public DbConnection Conn => Tran.Connection;

        /// <summary>
        /// Получить блокировку
        /// </summary>
        /// <param name="resource">ресурс</param>
        /// <param name="mode">режим</param>
        /// <param name="owner">владелец</param>
        /// <param name="timeout">таймаут</param>
        /// <returns></returns>
        public virtual LockResult GetLock(
            string resource
            , LockMode mode
            , string owner = null
            , TimeSpan? timeout = default(TimeSpan?))
        {
            return LockResult.Granted;
        }

        #region IDisposable Support

        /// <summary>
        /// флаг - ресурс очищен
        /// </summary>
        private bool _disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Очистка ресурса
        /// </summary>
        /// <param name="disposing">полная</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue == false)
            {
                _tran = null;
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Очистка ресурса
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion
    }
}
