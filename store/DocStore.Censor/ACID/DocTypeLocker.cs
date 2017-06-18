using DocModel.Censor;
using DocStore.Core.ACID;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DocStore.Censor.ACID
{
    public class DocTypeLocker : BaseDocTypeLocker<DocumentElement, ushort, string>
    {
        public DocTypeLocker(RemoteTransaction transaction) : base(transaction)
        {
        }

        public new RemoteTransaction Transaction => (RemoteTransaction)base.Transaction;

        protected override void ClearLock(IEnumerable<DocumentElement> objs)
        {
            throw new NotImplementedException();
        }

        protected override void GainLock(IEnumerable<DocumentElement> objs, LockType lockType, string source = null)
        {
            throw new NotImplementedException();
        }

        protected override void SetLock(
            IEnumerable<DocumentElement> objs
            , LockType lockType
            , string source = null)
        {

        }
    }
}
