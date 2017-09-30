namespace Doc.Core
{
    public interface ILineInfo
    {

        int LineNumber { get; }

        int LinePosition { get; }

        bool HasLineInfo();
    }
}
