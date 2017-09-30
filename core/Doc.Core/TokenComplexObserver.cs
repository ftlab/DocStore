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

        public void OnEndProperty(EndPropertyToken token)
        {
            Observers.ForEach(o => o.OnEndProperty(token));
        }

        public void OnEndVisit()
        {
            Observers.ForEach(o => o.OnEndVisit());
        }

        public void OnStartProperty(StartPropertyToken token)
        {
            Observers.ForEach(o => o.OnStartProperty(token));
        }

        public void OnStartVisit()
        {
            Observers.ForEach(o => o.OnStartVisit());
        }
    }
}
