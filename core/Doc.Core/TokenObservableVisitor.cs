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

        protected override void VisitEndAttribute(EndAttributeToken token) => Observer?.OnEndAttribute(token);

        protected override void VisitEndObject(EndObjectToken token) => Observer?.OnEndObject(token);

        protected override void VisitEndProperty(EndPropertyToken token) => Observer?.OnEndProperty(token);

        protected override void VisitNull(NullToken token) => Observer?.OnNull(token);

        protected override void VisitStartAttribute(StartAttributeToken token) => Observer?.OnStartAttribute(token);

        protected override void VisitStartObject(StartObjectToken token) => Observer?.OnStartObject(token);

        protected override void VisitStartProperty(StartPropertyToken token) => Observer?.OnStartProperty(token);

        protected override void VisitString(StringToken token) => Observer?.OnString(token);
    }
}
