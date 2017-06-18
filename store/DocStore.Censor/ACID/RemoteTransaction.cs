using DocStore.Core.ACID;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Censor.ACID
{
    public class RemoteTransaction : BaseTransaction
    {
        private string _source;

        public RemoteTransaction(string name, string source)
            : base(name)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        public string Source => _source;

        public override void Commit() { }

        public override void Dispose() { }

        public override void Rollback() { }
    }
}
