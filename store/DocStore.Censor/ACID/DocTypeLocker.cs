using DocModel.Censor;
using DocStore.Core.ACID;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Censor.ACID
{
    public class DocTypeLocker : BaseLocker<DocumentElement, string>
    {
        public DocTypeLocker(CensorTransaction transaction) : base(transaction)
        {
        }

        protected override BaseTransaction Transaction => throw new NotImplementedException();

        protected override void ClearLock(DocumentElement obj)
        {
            throw new NotImplementedException();
        }

        protected override void GainLock(DocumentElement obj, LockType lockType, string source = null)
        {
            throw new NotImplementedException();
        }

        protected override void SetLock(DocumentElement obj, LockType lockType, string source = null)
        {
            throw new NotImplementedException();
        }
    }
}
