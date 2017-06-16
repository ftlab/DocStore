using DocModel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.ACID
{
    public abstract class BaseDocIdentityLocker<TDocIdentity, TIdentity, TType, TSource>
        : BaseLocker<TDocIdentity, TSource>

        where TSource : class
        where TDocIdentity : IDocIdentity<TIdentity, TType>
    {
        protected BaseDocIdentityLocker(BaseTransaction transaction) : base(transaction)
        {
        }
    }
}
