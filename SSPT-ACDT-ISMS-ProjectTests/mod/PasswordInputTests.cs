using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSPT_ACDT_ISMS_Project.mod;
using System;
using System.IO;

[TestClass]
public class PasswordInputTests
{
    [TestMethod]
    public void TestGetPassword_WithValidPasswordInput_ShouldReturnPassword()
    {
        // Arrange
        var input = new StringReader("securepassword\n");
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        PasswordInput passwordInput = new PasswordInput();
        string password = passwordInput.GetPassword();

        // Assert
        Assert.AreEqual("securepassword", password);
        Assert.AreEqual("***********\n", output.ToString());
    }

    [TestMethod]
    public void TestGetPassword_WithBackspaceInput_ShouldReturnPassword()
    {
        // Arrange
        var input = new StringReader("pass\bword\n");
        Console.SetIn(input);
        var output = new StringWriter();
        Console.SetOut(output);

        // Act
        PasswordInput passwordInput = new PasswordInput();
        string password = passwordInput.GetPassword();

        // Assert
        Assert.AreEqual("password", password);
        Assert.AreEqual("******\b \bword\n", output.ToString());
    }
}
