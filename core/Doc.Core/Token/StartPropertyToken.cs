﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public class StartPropertyToken : BaseToken
    {
        public override TokenType Type => TokenType.StartProperty;

        public string Name { get; set; }

        public override string ToString()
        {
            return $">{Name}";
        }
    }
}
