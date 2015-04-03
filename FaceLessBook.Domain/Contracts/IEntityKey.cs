namespace FaceLessBook.Domain.Contracts
{
    public interface IEntityKey
    {
        /// <summary>
        /// The entity's unique (and URL-safe) public identifier
        /// </summary>
        /// <remarks>
        /// This is the identifier that should be exposed via the web, etc.
        /// </remarks>
        string Key { get; }
    }
}
