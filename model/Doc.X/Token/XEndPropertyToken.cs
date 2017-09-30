using Doc.Core;

namespace Doc.X
{
    public class XEndPropertyToken : EndPropertyToken
    {
        public string Namespace { get; set; }

        object SchemaType { get; set; }
    }
}
