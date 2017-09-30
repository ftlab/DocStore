using System;

namespace Doc.Core
{
    public class ReaderVisitor : IReaderVisitor
    {
        private readonly IReaderObserver _observer;

        public ReaderVisitor(IReaderObserver observer)
        {
            _observer = observer ?? throw new ArgumentNullException(nameof(observer));

        }

        public IReaderObserver Observer => _observer;

        public void Visit(IReader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            Observer.OnStartVisit();
            while (reader.Read())
            {
                if (reader.NodeType == NodeType.None)
                    continue;
                else if (reader.NodeType == NodeType.Property)
                    VisitProperty(reader);
            }
            Observer.OnEndVisit();
        }

        protected virtual void VisitProperty(IReader reader)
        {
            
        }
    }
}
