using System;
using System.Collections.Generic;
using System.Text;

namespace DocModel.Core
{
    public interface IDocIdentity<TIdentity, TType>
    {
        TIdentity Id { get; }
        IDocType<TType> Type { get; }
    }
}
