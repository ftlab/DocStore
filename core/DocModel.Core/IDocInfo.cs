﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocModel.Core
{
    public interface IDocInfo
    {
        int Id { get; }

        string Name { get; }

        IDictionary<string, IKeyInfo> Key { get; }

        IDictionary<string, IDocLink> Links { get; }
    }
}
