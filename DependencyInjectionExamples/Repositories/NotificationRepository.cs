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

        public List<string> GetNotifications()
        {
            var list = new List<string>
            {
                "Profile added.",
                "Profile updated.",
                "Profile deleted."
            };

            return list;
        }
    }
}
