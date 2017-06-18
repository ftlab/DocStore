using DocModel.Censor;
using DocStore.Censor.DataModel;
using DocStore.Censor.Model;
using DocStore.Core.ACID;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace DocStore.Censor.ACID
{
    public class DocTypeLocker : BaseDocTypeLocker<DocumentElement, ushort>
    {
        private DbConnection _conn;

        private DbTransaction _tran;

        public DocTypeLocker(RemoteTransaction transaction
            , DbConnection conn
            , DbTransaction tran
            ) : base(transaction)
        {
            _conn = conn ?? throw new ArgumentNullException(nameof(conn));
            _tran = tran;
        }

        public DbConnection Conn
        {
            get
            {
                if (_conn == null) throw new NullReferenceException(nameof(Conn));
                return _conn;
            }
        }

        public DbTransaction Tran => _tran;

        public new RemoteTransaction Transaction => (RemoteTransaction)base.Transaction;

        protected override void ClearLock(IEnumerable<DocumentElement> objs)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose()
        {
            _conn = null;
            _tran = null;
        }

        protected override void GainLock(IEnumerable<DocumentElement> objs, LockType lockType)
        {
            throw new NotSupportedException();
        }

        protected override void SetLock(
            IEnumerable<DocumentElement> objs
            , LockType lockType)
        {
            if (objs == null) throw new ArgumentNullException(nameof(objs));
            var locks = objs.Select(x =>
                new T_DocumentTypeLock()
                {
                    DocumentTypeId = x.TypeId,
                    Level = (byte)lockType,
                    LockSource = Transaction.Source,
                    TransactionName = Transaction.Name,
                    Comment = null,
                });

            using (var rep = new LockRepository(Conn, Tran))
                rep.WriteLocks(locks);
        }
    }
}
