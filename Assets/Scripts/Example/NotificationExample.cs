using UnityEngine;
using UnityEngine.UI;

namespace Notification.Example
{
    public class NotificationExample : MonoBehaviour
    {
        public Button scheduleButton;
        public Button clearButton;

        void Start()
        {
            NotificationManager.Instance.Initialize();

            scheduleButton.onClick.AddListener(ScheduleTestNotification);
            clearButton.onClick.AddListener(ClearNotifications);
        }

        private void ScheduleTestNotification()
        {
            NotificationManager.Instance.AddScheduledNotification(
                "Reminder",
                "Don't forget to check the app!",
                1,
                1,
                2001
            );
        }

        private void ClearNotifications()
        {
            NotificationManager.Instance.AllClearNotification();
        }
    }
}
