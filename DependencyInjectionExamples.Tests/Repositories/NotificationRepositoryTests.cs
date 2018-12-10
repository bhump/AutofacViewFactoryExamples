using System;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using DependencyInjectionExamples.Interfaces;
using DependencyInjectionExamples.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DependencyInjectionExamples.Tests.Repositories
{
    [TestClass]
    public class NotificationRepositoryTests
    {
        private Mock<INotificationRepository> _notificationRepo;

        [TestInitialize]
        public void Initialize()
        {
            using (var mock = AutoMock.GetLoose())
            {
                _notificationRepo = mock.Mock<INotificationRepository>();
            }
        }

        [TestMethod]
        public void GetNotifications_Succeeded()
        {
            var repo = new NotificationRepository();

            var results = repo.GetNotifications();

            Assert.AreEqual(3, results.Count, "Not equal");
        }
    }
}
