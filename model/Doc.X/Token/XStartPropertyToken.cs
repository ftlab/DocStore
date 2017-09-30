using Doc.Core;

namespace Doc.X
{
    public class XStartPropertyToken : StartPropertyToken
    {
        public string Namespace { get; set; }

        object SchemaType { get; set; }
    }
}
