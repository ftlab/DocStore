using DocModel.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;

namespace DocModel.Json
{
    public class JDoc : IDoc
    {
        INode IDoc.Root => Root;

        public JNode Root => throw new NotImplementedException();
    }
}
