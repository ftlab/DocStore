using DocModel.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Xml.Linq;

namespace DocModel.Json
{
    public class JDoc: IDoc
    {
        private readonly JObject _raw;

        public JDoc(JObject raw)
        {
            _raw = raw ?? throw new ArgumentNullException(nameof(raw));
            JValue
        }
    }
}
