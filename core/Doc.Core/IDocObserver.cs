namespace Doc.Core
{
    /// <summary>
    /// Наблюдатель обработки документа
    /// </summary>
    public interface IDocObserver
    {
        /// <summary>
        /// Родительский наблюдатель
        /// </summary>
        IDocObserver Parent { get; }

        /// <summary>
        /// Реакция на атрибут документа
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void OnAttribute(string name, string value);

        /// <summary>
        /// Реакция на свойство документа
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        void OnProperty(string name, string value);

        void OnChildProperty();

    }
}
