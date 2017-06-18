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
            , string name
            , string source)
            : base(name, source)
        {
            _conn = conn ?? throw new ArgumentNullException(nameof(conn));

            Start();
        }

        private void Start()
        {
            if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();
            _tran = Conn.BeginTransaction();

            using (var cmd = Conn.CreateCommand())
            {
                cmd.Transaction = Tran;
                cmd.CommandText = "INSERT INTO T_CURRENTTRANSACTION (NAME, SOURCE) VALUES (@NAME, @SOURCE)";

                var pName = cmd.CreateParameter();
                pName.Value = Name;
                pName.ParameterName = nameof(Name);
                cmd.Parameters.Add(pName);
                var pSource = cmd.CreateParameter();
                pSource.Value = Source;
                pSource.ParameterName = nameof(Source);
                cmd.Parameters.Add(pSource);

                cmd.ExecuteNonQuery();
            }
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
