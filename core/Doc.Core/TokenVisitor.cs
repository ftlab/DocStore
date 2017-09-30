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
                    OnStartProperty((StartPropertyToken)token);
                else if (token.Type == TokenType.EndProperty)
                    OnEndProperty((EndPropertyToken)token);
            }
        }

        protected abstract void OnEndProperty(EndPropertyToken token);

        protected abstract void OnStartProperty(StartPropertyToken token);
    }
}
