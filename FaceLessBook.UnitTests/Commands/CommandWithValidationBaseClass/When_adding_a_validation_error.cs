using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FaceLessBook.UnitTests.Commands.CommandWithValidationBaseClass
{
    [TestClass]
    public class When_adding_a_validation_error : When_a_command_is_newly_instantiated
    {
        [TestMethod]
        public void It_should_add_error_and_validate_return_false()
        {
            TestCommand.AddError();

            Assert.IsFalse(TestCommand.Validate().IsValid);
        }
    }
}
