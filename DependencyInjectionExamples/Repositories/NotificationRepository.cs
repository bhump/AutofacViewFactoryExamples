using System;
using System.Collections.Generic;
using DependencyInjectionExamples.Interfaces;

namespace DependencyInjectionExamples.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        public NotificationRepository()
        {
        }

        public IEnumerable<string> GetNotifications()
        {
            var list = new List<string>();
            list.Add("Profile added.");
            list.Add("Profile updated.");
            list.Add("Profile deleted.");

            return list;
        }
    }
}
