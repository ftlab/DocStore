using DocModel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.ACID
{
    public abstract class BaseDocTypeLocker<TDocType, TType>
        : BaseLocker<TDocType>
        where TDocType : IDocType<TType>
    {
        protected BaseDocTypeLocker(BaseTransaction transaction) : base(transaction)
        {
        }
    }
}
