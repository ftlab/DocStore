using DocModel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocStore.Core.ACID
{
    public abstract class BaseDocIdentityLocker<TDocIdentity, TIdentity, TType>
        : BaseLocker<TDocIdentity>
        where TDocIdentity : IDocIdentity<TIdentity, TType>
    {
        protected BaseDocIdentityLocker(BaseTransaction transaction) : base(transaction)
        {
        }
    }
}
