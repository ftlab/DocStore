using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public interface ITokenObserver
    {
        void OnStartVisit();

        void OnEndVisit();

        void OnStartProperty(StartPropertyToken token);

        void OnEndProperty(EndPropertyToken token);
    }
}
