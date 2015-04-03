using FaceLessBook.Domain.Commands;

namespace FaceLessBook.UnitTests.Commands.CommandWithValidationBaseClass
{
    public class FakeCommandBase : CommandWithValidationBase
    {
        public override void Execute()
        {
            
        }

        public void AddError()
        {
            base.AddValidationError("SOMETHING is WRONG..");
        }
    }
}
