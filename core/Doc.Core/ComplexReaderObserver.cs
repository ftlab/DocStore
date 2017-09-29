using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public class ComplexReaderObserver : IReaderObserver
    {
        private readonly List<IReaderObserver> _childs = new List<IReaderObserver>();

        public List<IReaderObserver> Childs => _childs;

        public ComplexReaderObserver Add(IReaderObserver observer)
        {
            Childs.Add(observer ?? throw new ArgumentNullException(nameof(observer)));
            return this;
        }

        public void OnEndVisit() => Childs.ForEach(c => c.OnEndVisit());

        public void OnStartVisit() => Childs.ForEach(c => c.OnStartVisit());
    }
}
