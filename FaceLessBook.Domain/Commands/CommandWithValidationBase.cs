using FaceLessBook.Domain.Contracts.Commands;

namespace FaceLessBook.Domain.Commands
{
    public abstract class CommandWithValidationBase : ICommandWithValidation
    {
        private readonly CommandValidationResult _validationResult;

        public CommandWithValidationBase()
        {
            _validationResult = new CommandValidationResult();
        }

        //ICommand implementation
        public abstract void Execute();

        #region ICommandWithValidation implementation
        /// <summary>
        /// Business Rules and Validations
        /// </summary>
        /// <returns>List of Errors</returns>
        public virtual ICommandValidationResult Validate()
        {
            return _validationResult;
        }

        public void ExecuteIfValid()
        {
            if (_validationResult.IsValid)
                Execute();
        }

        #endregion

        protected void AddValidationError(string errorMessage)
        {
            _validationResult.AddError(errorMessage);
        }
    }
}
