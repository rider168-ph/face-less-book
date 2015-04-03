using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FaceLessBook.UnitTests.Commands.CommandWithValidationBaseClass
{
    [TestClass]
    public class When_a_command_is_newly_instantiated
    {
        protected FakeCommandBase TestCommand;

        [TestInitialize]
        public void Setup()
        {
            TestCommand = new FakeCommandBase();
        }

        [TestMethod]
        public void It_should_validate()
        {
            Assert.IsTrue(TestCommand.Validate().IsValid, "Command Base returns false");
        }

    }
}
