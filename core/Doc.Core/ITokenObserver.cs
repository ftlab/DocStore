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

        void OnEndObject(EndObjectToken token);

        void OnStartObject(StartObjectToken token);

        void OnStartAttribute(StartAttributeToken token);

        void OnNull(NullToken token);

        void OnEndAttribute(EndAttributeToken token);

        void OnString(StringToken token);
    }
}
