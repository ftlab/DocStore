﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DocModel.Core
{
    public interface IDocSchema<TType>
    {
        IDocType<TType> Type { get; }

        IDictionary<string, INodeSchema> Elements { get; }
    }
}
