using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Censor.DataModel
{
    public class T_DocumentTypeLock
    {
        public long Id { get; set; }

        public string TransactionName { get; set; }

        public ushort DocumentTypeId { get; set; }

        public string Comment { get; set; }

        public string LockSource { get; set; }

        public byte Level { get; set; }
    }
}
