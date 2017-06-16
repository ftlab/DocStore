using DocModel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocModel.Censor
{
    public class Indentity : IDocIdentity<long, short>
    {
        public long Id => throw new NotImplementedException();

        public DocumentElement Type => throw new NotImplementedException();

        long IDocIdentity<long, short>.Id => Id;

        IDocType<short> IDocIdentity<long, short>.Type => (IDocType<short>)Type;
    }
}
