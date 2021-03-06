﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    /// <summary>
    /// Считыватель токенов
    /// </summary>
    public interface ITokenReader : IDisposable, ILineInfo
    {
        /// <summary>
        /// Считать
        /// </summary>
        /// <returns></returns>
        IEnumerable<IToken> Read();
    }
}
