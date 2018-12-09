using System;
using System.Collections.Generic;
using DependencyInjectionExamples.Interfaces;

namespace DependencyInjectionExamples.ViewModels
{
    public class NotificationViewModel : BaseViewModel
    {
        INotificationRepository _notificationRepository;

        public NotificationViewModel(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IEnumerable<string> Notifications
        {
            get { return _notificationRepository.GetNotifications(); }
        }
    }
}
