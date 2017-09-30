using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public class TokenObservableVisitor : TokenVisitor
    {
        public ITokenObserver Observer { get; set; }

        public override void Visit(ITokenReader reader)
        {
            Observer?.OnStartVisit();

            base.Visit(reader);

            Observer?.OnEndVisit();
        }

        protected override void OnEndProperty(EndPropertyToken token)
        {
            Observer?.OnEndProperty(token);
        }

        protected override void OnStartProperty(StartPropertyToken token)
        {
            Observer?.OnStartProperty(token);
        }
    }
}
