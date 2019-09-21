using System.Web.Http.Results;
using NUnit.Framework;
using SPAProjectManager.InterfaceLayer;
using SPAProjectManager.Controllers;
using System.Collections.ObjectModel;
using SPAProjectManager.Models;

namespace SPAProjectManager.Tests.UnitTest
{
    [TestFixture]
   public class UserControllerTest
    {
        private IUsersBL userBL;
        private UsersController userController;

        [SetUp]
        public void TestSetUp()
        {
            userBL = new MockUserBL();
            userController = new UsersController(userBL);
        }

        [TearDown]
        public void TestTearDown()
        {
            userBL = null;
            userController = null;
        }

        [Test]
        public void GetUsersTest()
        {
            var response = userController.GetUsers();
            var responseResult = response as OkNegotiatedContentResult<Collection<SPAProjectManager.Models.Users>>;
            Assert.IsNotNull(responseResult);
            Assert.IsNotNull(responseResult.Content);
            foreach (var user in responseResult.Content)
            {
                Assert.IsNotNull(user.UserID);
                Assert.IsNotNull(user.FirstName);
                Assert.IsNotNull(user.LastName);
                Assert.IsNotNull(user.EmployeeID);
            }
        }

        [Test]
        public void AddUserTest_Success()
        {
            // Arrange
            SPAProjectManager.Models.Users model = new SPAProjectManager.Models.Users
            {
                UserID = 2,
                FirstName = "Yagavi",
                LastName = "Babu",
                EmployeeID = "1100"
            };

            // Act
            var response = userController.AddUser(model);

            // Assert
            Assert.IsTrue(response is OkResult);
        }

        [Test]
        public void AddUserTest_Error()
        {
            // Arrange
            var userController = new UsersController(null);

            SPAProjectManager.Models.Users model = new SPAProjectManager.Models.Users
            {
                UserID = 4,
                FirstName = "Yagaavi",
                LastName = "Kelen",
                EmployeeID = "1102"
            };

            // Act
            var response = userController.AddUser(model);

            // Assert
           Assert.IsTrue(response is InternalServerErrorResult);
        }

        [Test]
        public void UpdateUserTest_Success()
        {
            // Arrange
            SPAProjectManager.Models.Users model = new SPAProjectManager.Models.Users
            {
                UserID = 1,
                FirstName = "Yagavi",
                LastName = "Babu",
                EmployeeID = "1100"
            };

            // Act
            var response = userController.UpdateUser(model);

            // Assert
            Assert.IsTrue(response is OkResult);
        }

        [Test]
        public void UpdateUserTest_Error()
        {
            // Arrange
            var userController = new UsersController(null);

            SPAProjectManager.Models.Users model = new SPAProjectManager.Models.Users
            {
                UserID = 1,
                FirstName = "Yagavi",
                LastName = "Babu",
                EmployeeID = "1100"
            };

            // Act
            var response = userController.UpdateUser(model);

            // Assert
            Assert.IsTrue(response is InternalServerErrorResult);
        }

        [Test]
        public void DeleteUserTest_Success()
        {
            // Arrange
            SPAProjectManager.Models.Users model = new SPAProjectManager.Models.Users
            {
                UserID = 1,
                FirstName = "Yagavi",
                LastName = "Babu",
                EmployeeID = "1100"
            };

            // Act
            var response = userController.DeleteUser(model);

            // Assert
            Assert.IsTrue(response is OkResult);
        }

        [Test]
        public void DeleteUserTest_Error()
        {
            // Arrange
            var userController = new UsersController(null);

            SPAProjectManager.Models.Users model = new SPAProjectManager.Models.Users
            {
                UserID = 1,
                FirstName = "Yagavi",
                LastName = "Babu",
                EmployeeID = "1100"
            };

            // Act
            var response = userController.DeleteUser(model);

            // Assert
            Assert.IsTrue(response is InternalServerErrorResult);
        }
    }
}
