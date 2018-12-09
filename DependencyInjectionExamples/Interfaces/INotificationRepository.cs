using System;
using System.Collections.Generic;

namespace DependencyInjectionExamples.Interfaces
{
    public interface INotificationRepository
    {
        IEnumerable<string> GetNotifications();
    }
}
