using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DependencyInjectionExamples.Interfaces;

namespace DependencyInjectionExamples.ViewModels
{
    public class NotificationViewModel : BaseViewModel
    {
        INotificationRepository _notificationRepository;

        public NotificationViewModel(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;

            _notifications = _notificationRepository.GetNotifications();
        }

        private List<string> _notifications;

        public ObservableCollection<string> Notifications
        {
            get 
            {
                var collection = new ObservableCollection<string>();

                if(_searchText == null)
                {
                    _searchText = "";
                }

                if(_notifications != null)
                {
                    List<string> entities = null;

                    entities = _notifications.FindAll(s => s.Contains(_searchText));

                    if (entities != null && entities.Any())
                    {
                        collection = new ObservableCollection<string>(entities);
                    }
                }

                return collection; 
            }
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value ?? string.Empty;
                    RaisePropertyChanged();
                    this.DoSearch();
                }
            }
        }

        void DoSearch()
        {
            RaisePropertyChanged(nameof(Notifications));
        }
    }
}
