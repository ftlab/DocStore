using System;
using System.Collections;
using System.Collections.Generic;

namespace DocModel.Core
{
    public interface IDoc: IDictionary<string, IDoc>
    {

    }
}
