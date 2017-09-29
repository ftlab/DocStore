using System;

namespace Doc.Core
{
    public abstract class ReaderVisitor : IReaderVisitor
    {
        private readonly IReaderObserver _observer;

        protected ReaderVisitor(IReaderObserver observer)
        {
            _observer = observer ?? throw new ArgumentNullException(nameof(observer));
        }

        public IReaderObserver Observer => _observer;

        public void Visit(IReader reader)
        {
            if (reader == null) throw new ArgumentNullException(nameof(reader));
            while (reader.Read())
            {

            }
        }
    }
}
