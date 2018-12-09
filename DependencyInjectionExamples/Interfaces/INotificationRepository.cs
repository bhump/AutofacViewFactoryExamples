using System;
using System.Collections.Generic;

namespace DependencyInjectionExamples.Interfaces
{
    public interface INotificationRepository
    {
        List<string> GetNotifications();
    }
}
