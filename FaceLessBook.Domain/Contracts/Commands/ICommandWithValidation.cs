namespace FaceLessBook.Domain.Contracts.Commands
{
    /// <summary>
    /// Business Rules and UI Validation Constraints
    /// </summary>
    public interface ICommandWithValidation : ICommand
    {
        ICommandValidationResult Validate();
        void ExecuteIfValid();
    }
}
