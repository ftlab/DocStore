using Doc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.J.Observer
{
    public class JsonBuilder : ITokenObserver
    {
        private readonly TextWriter _writer;

        private int Depth;

        public JsonBuilder(TextWriter writer)
        {
            _writer = writer ?? throw new ArgumentNullException(nameof(writer));
        }

        public TextWriter Writer => _writer;

        private void Shift()
        {
            if (Depth > 0)
                Writer.Write(new String(Enumerable.Repeat('\t', Depth).ToArray()));
        }

        public void OnEndAttribute(EndAttributeToken token)
        {

        }

        public void OnEndObject(EndObjectToken token)
        {
            Writer.Write("}");
            Depth--;
        }

        public void OnEndProperty(EndPropertyToken token)
        {

        }

        public void OnEndVisit()
        {
            Writer.Write("}");
            Depth--;
        }

        public void OnNull(NullToken token)
        {

        }

        public void OnStartAttribute(StartAttributeToken token)
        {
            Writer.WriteLine();
            Shift();
            Writer.Write($"\"_{token.Name}\": ");
        }

        public void OnStartObject(StartObjectToken token)
        {
            Writer.Write("{");
            Depth++;
        }

        public void OnStartProperty(StartPropertyToken token)
        {
            Writer.WriteLine();
            Shift();
            Writer.Write($"\"{token.Name}\": ");
        }

        public void OnStartVisit()
        {
            Writer.Write("{");
            Depth++;
        }

        public void OnString(StringToken token)
        {
            Writer.Write($"\"{token.Value}\"");
        }
    }
}
