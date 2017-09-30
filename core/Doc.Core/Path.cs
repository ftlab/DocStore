using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doc.Core
{
    public class Path : Stack<string>
    {
        public string GetFirstNode() => this.FirstOrDefault();

        public string GetLastNode() => this.LastOrDefault();

        public string GetFullPath()
        {
            var builder = new StringBuilder();
            foreach (var node in this.Reverse())
            {
                builder.Append($"/{node}");
            }
            return builder.ToString();
        }

        public override string ToString() => GetFullPath();
    }
}
