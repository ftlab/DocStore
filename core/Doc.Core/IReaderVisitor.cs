﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public interface IReaderVisitor
    {
        void Visit(IReader reader);
    }
}
