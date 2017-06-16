using DocStore.Core.ACID;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DocStore.Censor.ACID
{
    public class CensorTransaction : BaseTransaction
    {
        private readonly DbConnection _conn;

        private DbTransaction _tran;

        public CensorTransaction(
            DbConnection conn
            , string name)
            : base(name)
        {
            _conn = conn ?? throw new ArgumentNullException(nameof(conn));

            if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();
            _tran = Conn.BeginTransaction();
        }

        private DbConnection Conn => _conn;

        private DbTransaction Tran => _tran;

        public override void Commit() => Tran.Commit();

        public override void Dispose()
        {
            if (Tran != null)
            {
                Tran.Dispose();
                _tran = null;
            }
        }

        public override void Rollback() => Tran.Rollback();
    }
}
