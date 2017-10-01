using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public abstract class TokenVisitor : ITokenVisitor
    {
        public virtual void Visit(ITokenReader reader)
        {
            foreach (var token in reader.Read())
            {
                if (token.Type == TokenType.StartProperty)
                    VisitStartProperty((StartPropertyToken)token);
                else if (token.Type == TokenType.EndProperty)
                    VisitEndProperty((EndPropertyToken)token);
                else if (token.Type == TokenType.StartObject)
                    VisitStartObject((StartObjectToken)token);
                else if (token.Type == TokenType.EndObject)
                    VisitEndObject((EndObjectToken)token);
                else if (token.Type == TokenType.StartAttribute)
                    VisitStartAttribute((StartAttributeToken)token);
                else if (token.Type == TokenType.EndAttribute)
                    VisitEndAttribute((EndAttributeToken)token);
                else if (token.Type == TokenType.Null)
                    VisitNull((NullToken)token);
                else if (token.Type == TokenType.String)
                    VisitString((StringToken)token);
            }
        }

        protected abstract void VisitString(StringToken token);

        protected abstract void VisitNull(NullToken token);

        protected abstract void VisitEndAttribute(EndAttributeToken token);

        protected abstract void VisitStartAttribute(StartAttributeToken token);

        protected abstract void VisitEndObject(EndObjectToken token);

        protected abstract void VisitStartObject(StartObjectToken token);

        protected abstract void VisitEndProperty(EndPropertyToken token);

        protected abstract void VisitStartProperty(StartPropertyToken token);
    }
}
