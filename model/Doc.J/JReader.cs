using Doc.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.J
{
    public class JReader : IReader
    {

        private readonly JsonReader _reader;

        public JReader(JsonReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public bool Read()
        {
            return _reader.Read();
        }
        
    }
}
