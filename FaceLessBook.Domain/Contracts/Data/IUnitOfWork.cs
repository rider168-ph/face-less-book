using FaceLessBook.Domain.Models;

namespace FaceLessBook.Domain.Contracts.Data
{
    /// <summary>
    /// Default Interface for the FaceLessBook "Unit of Work"
    /// Using Unit of Work Design Pattern
    /// </summary>
    public interface IUnitOfWork
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IFriendRepository Friends { get; }  // custom repository
        IRepository<User> Users { get; }    // using generic repository
    }
}
