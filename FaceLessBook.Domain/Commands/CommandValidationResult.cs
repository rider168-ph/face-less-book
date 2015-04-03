using System.Collections.Generic;
using System.Linq;
using FaceLessBook.Domain.Contracts.Commands;

namespace FaceLessBook.Domain.Commands
{
    public class CommandValidationResult : ICommandValidationResult
    {
        readonly  IList<string> _errors = new List<string>();

        public bool IsValid
        {
            get
            {
                return _errors.Count == 0;
            }
        }

        public void AddError(string errorMessage)
        {
            _errors.Add(errorMessage);
        }

        public string GetAsMessage()
        {
            return GetAsMessage(".");
        }

        public string GetAsMessage(string delimiter)
        {
            var errorMsg = _errors.Aggregate(string.Empty, (current, error) => current + (error + delimiter));

            return errorMsg;
        }
    }
}
