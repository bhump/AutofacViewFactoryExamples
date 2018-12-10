using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac.Extras.Moq;
using DependencyInjectionExamples.Interfaces;
using DependencyInjectionExamples.Repositories;
using DependencyInjectionExamples.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DependencyInjectionExamples.Tests.ViewModels
{
    [TestClass]
    public class UserViewModelTests
    {
        private Mock<IUserRepository> _userRepo;
        private Mock<INavigationService> _navigation;
        private Mock<IViewFactory> _viewFactory;

        public UserViewModelTests()
        {
        }

        [TestInitialize]
        public void Initialize()
        {
            using (var mock = AutoMock.GetLoose())
            {
                _userRepo = mock.Mock<IUserRepository>();
                _navigation = mock.Mock<INavigationService>();
                _viewFactory = mock.Mock<IViewFactory>();
            }
        }

        [TestMethod]
        public void GetUserName_Success()
        {
            var userName = "humpy";

            _userRepo.Setup(x => x.GetUserName())
            .Returns(userName);

            var viewModel = new UserViewModel(_userRepo.Object, _viewFactory.Object, _navigation.Object);

            var name = viewModel.UserName;

            Assert.AreEqual(userName, name, "UserNames are not equal");
        }

        [TestMethod]
        public void GetEmail_Success()
        {
            var email = "brent@snapspot.io";

            _userRepo.Setup(x => x.GetEmail())
            .Returns(email);

            var viewModel = new UserViewModel(_userRepo.Object, _viewFactory.Object, _navigation.Object);

            var mail = viewModel.Email;

            Assert.AreEqual(email, mail, "Emails are not equal");
        }

        [TestMethod]
        public void OpenNewPage_Success()
        {
            var viewModel = new UserViewModel(_userRepo.Object, _viewFactory.Object, _navigation.Object);

            ICommand openPage = viewModel.OpenPageCommand;

            var task = Task.Factory.StartNew(() => openPage.Execute(null));

            task.Wait();

            var expected = true;

            if(task.IsCompletedSuccessfully)
            {
                Assert.AreEqual(expected, task.IsCompletedSuccessfully, "Did not complete successfully");
            }
        }
    }
}
