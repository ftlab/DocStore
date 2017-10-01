using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public sealed class TokenComplexObserver : ITokenObserver
    {
        public readonly List<ITokenObserver> Observers = new List<ITokenObserver>();

        public TokenComplexObserver Add(ITokenObserver observer)
        {
            Observers.Add(observer);
            return this;
        }

        public void OnEndAttribute(EndAttributeToken token) => Observers.ForEach(o => o.OnEndAttribute(token));

        public void OnEndObject(EndObjectToken token) => Observers.ForEach(o => o.OnEndObject(token));

        public void OnEndProperty(EndPropertyToken token) => Observers.ForEach(o => o.OnEndProperty(token));

        public void OnEndVisit() => Observers.ForEach(o => o.OnEndVisit());

        public void OnNull(NullToken token) => Observers.ForEach(o => o.OnNull(token));

        public void OnStartAttribute(StartAttributeToken token) => Observers.ForEach(o => o.OnStartAttribute(token));

        public void OnStartObject(StartObjectToken token) => Observers.ForEach(o => o.OnStartObject(token));

        public void OnStartProperty(StartPropertyToken token) => Observers.ForEach(o => o.OnStartProperty(token));

        public void OnStartVisit() => Observers.ForEach(o => o.OnStartVisit());

        public void OnString(StringToken token) => Observers?.ForEach(o => o.OnString(token));
    }
}
