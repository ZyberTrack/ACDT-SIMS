using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SSPT_ACDT_ISMS_Project.mod.Tests
{
    [TestClass]
    public class ConsoleMenuTests
    {
        [TestMethod]
        public void TestConsoleMenu_Display_WithValidSelection()
        {
            // Arrange
            var input = new StringReader("DownArrow\nEnter\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var menuOptions = new List<string> { "Option1", "Option2", "Option3" };
            var consoleMenu = new ConsoleMenu(menuOptions);

            // Act
            int choice = consoleMenu.Display();

            // Assert
            Assert.AreEqual(0, choice); // Expected choice based on input

            // Verify the console output
            string expectedOutput = "Menü:\n(1) Option1\n(2) Option2\n(3) Option3\n\nWählen Sie eine Option mit den Pfeiltasten.";
            Assert.AreEqual(expectedOutput, output.ToString().Trim());
        }

        [TestMethod]
        public void TestConsoleMenu_Display_WithInvalidSelection()
        {
            // Arrange
            var input = new StringReader("InvalidKey\nDownArrow\nEnter\n");
            Console.SetIn(input);
            var output = new StringWriter();
            Console.SetOut(output);
            var menuOptions = new List<string> { "Option1", "Option2", "Option3" };
            var consoleMenu = new ConsoleMenu(menuOptions);

            // Act
            int choice = consoleMenu.Display();

            // Assert
            Assert.AreEqual(0, choice); // Expected choice based on input

            // Verify the console output
            string expectedOutput = "Menü:\n(1) Option1\n(2) Option2\n(3) Option3\n\nWählen Sie eine Option mit den Pfeiltasten.";
            Assert.AreEqual(expectedOutput, output.ToString().Trim());
        }
    }

}