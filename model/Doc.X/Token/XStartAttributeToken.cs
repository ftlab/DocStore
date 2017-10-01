using Doc.Core;

namespace Doc.X
{
    public class XStartAttributeToken : StartAttributeToken
    {
        public string Namespace { get; set; }

        object SchemaType { get; set; }
    }
}
