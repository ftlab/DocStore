using Doc.Core;

namespace Doc.X
{
    public class XEndAttributeToken : EndAttributeToken
    {
        public string Namespace { get; set; }

        object SchemaType { get; set; }
    }
}
