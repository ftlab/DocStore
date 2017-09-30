using Doc.Core;
using Newtonsoft.Json;
using System;

namespace Doc.J
{
    public class JReader : IReader
    {
        private readonly JsonReader _reader;

        public JReader(JsonReader reader)
        {
            _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        }

        public JsonReader Reader => _reader;

        public NodeType NodeType
        {
            get
            {
                if (Reader.TokenType == JsonToken.None)
                    return NodeType.None;
                else if (Reader.TokenType == JsonToken.PropertyName)
                    return NodeType.Property;
                else throw new NotSupportedException(Reader.TokenType.ToString());
            }
        }

        public string PropertyName => Reader.Path;

        public bool Read()
        {
            bool? skip = Reader.Read();
            while (skip == true)
            {
                if (Reader.TokenType == JsonToken.Comment
                    || Reader.TokenType == JsonToken.None)
                    skip = Reader.Read();
                else if (
                    Reader.TokenType == JsonToken.Boolean
                    || Reader.TokenType == JsonToken.Bytes
                    || Reader.TokenType == JsonToken.Date
                    || Reader.TokenType == JsonToken.EndArray
                    || Reader.TokenType == JsonToken.EndObject
                    || Reader.TokenType == JsonToken.Float
                    || Reader.TokenType == JsonToken.Integer
                    || Reader.TokenType == JsonToken.Null
                    || Reader.TokenType == JsonToken.PropertyName
                    || Reader.TokenType == JsonToken.Raw
                    || Reader.TokenType == JsonToken.StartArray
                    || Reader.TokenType == JsonToken.StartObject
                    || Reader.TokenType == JsonToken.String
                    || Reader.TokenType == JsonToken.Undefined
                    )
                    skip = null;
                else throw new NotSupportedException(Reader.TokenType.ToString());

            }

            return skip ?? true;
        }

    }
}
