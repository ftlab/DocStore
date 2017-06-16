using System;
using DocModel.Core;

namespace DocModel.Censor
{
    public class DocumentElement : IDocType<ushort>
    {
        public ushort TypeId => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();
    }
}
