using DocStore.Censor.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Data;

namespace DocStore.Censor.Model
{
    public class LockRepository : IDisposable
    {
        private DbConnection _conn;

        private DbTransaction _tran;

        public LockRepository(DbConnection conn, DbTransaction tran)
        {
            _conn = conn ?? throw new ArgumentNullException(nameof(conn));
            _tran = tran;
        }

        private DbConnection Conn
        {
            get
            {
                if (_conn == null) throw new NullReferenceException(nameof(_conn));
                return _conn;
            }
        }

        private DbTransaction Tran => _tran;

        public void WriteLocks(IEnumerable<T_DocumentLock> locks)
        {
            if (locks == null) throw new ArgumentNullException(nameof(locks));

            var builder = new DataReaderBuilder<T_DocumentLock>()
                .AddMap(x => x.Id)
                .AddMap(x => x.TransactionName)
                .AddMap(x => x.DocumentTypeId)
                .AddMap(x => x.DomainKey)
                .AddMap(x => x.Comment)
                .AddMap(x => x.LockSource)
                .AddMap(x => x.Level);

            using (var reader = builder.Create(locks))
            {
                BulkWrite(nameof(T_DocumentTypeLock), reader);
            }
        }

        private void BulkWrite(string tableName, IDataReader reader)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _conn = null;
            _tran = null;
        }
    }
}
