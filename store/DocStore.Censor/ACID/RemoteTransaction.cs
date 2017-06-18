using DocStore.Core.ACID;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Censor.ACID
{
    public class RemoteTransaction : BaseTransaction
    {
        public RemoteTransaction(string name, string source)
            : base(name, source)
        {

        }

        public override void Commit() { }

        public override void Dispose() { }

        public override void Rollback() { }
    }
}
