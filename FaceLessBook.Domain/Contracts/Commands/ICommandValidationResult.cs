namespace FaceLessBook.Domain.Contracts.Commands
{
    public interface ICommandValidationResult
    {
        bool IsValid { get; }
        string GetAsMessage();
        string GetAsMessage(string delimiter);
    }
}
