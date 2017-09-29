using Doc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Doc.X
{
    public class XReader : IReader
    {
        private readonly XmlReader _reader;

        public XReader(XmlReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public bool Read()
        {
            throw new NotImplementedException();
        }
    }
}
