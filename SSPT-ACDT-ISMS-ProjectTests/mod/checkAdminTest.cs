using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SSPT_ACDT_ISMS_Project.mod.Tests
{


    [TestClass]
    public class CheckAdminTests
    {
        [TestMethod]
        public void TestIsAdmin_WithValidAdminCredentials_ShouldReturnTrue()
        {
            // Arrange
            string username = "zybertrack";
            string password = "12qwasyxcvfgtz&/";
            string connectionString = "Server=localhost,1433;Database=ISMS-REPO;User=sa;Password=12qwasyxcvfgtz&/;Encrypt=False;\r\n";

            // Act
            bool isAdmin = checkAdmin.isAdmin(username, password, connectionString);

            // Assert
            Assert.IsTrue(isAdmin);
        }

        [TestMethod]
        public void TestIsAdmin_WithInvalidAdminCredentials_ShouldReturnFalse()
        {
            // Arrange
            string username = "su";
            string password = "su";
            string connectionString = "Server=localhost,1433;Database=ISMS-REPO;User=sa;Password=12qwasyxcvfgtz&/;Encrypt=False;\r\n";

            // Act
            bool isAdmin = checkAdmin.isAdmin(username, password, connectionString);

            // Assert
            Assert.IsFalse(isAdmin);
        }
    }

}
