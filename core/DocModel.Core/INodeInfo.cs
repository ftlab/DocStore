using System;
using System.Collections.Generic;
using System.Text;

namespace DocModel.Core
{
    public interface INodeInfo
    {
        //
        // Summary:
        //     Gets the current line number.
        int LineNumber { get; }
        //
        // Summary:
        //     Gets the current line position.
        int LinePosition { get; }

        //
        // Summary:
        //     Gets a value indicating whether the class can return line information.
        //
        // Returns:
        //     true if Newtonsoft.Json.IJsonLineInfo.LineNumber and Newtonsoft.Json.IJsonLineInfo.LinePosition
        //     can be provided; otherwise, false.
        bool HasLineInfo();
    }
}
