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

        void ScheduleTestNotification()
        {
            NotificationManager.Instance.AddScheduledNotification(
                "Reminder",
                "Don't forget to check the app!",
                1,       // Badge count
                1,     // Fire in 10 minutes
                2001     // Notification ID
            );
        }

        void ClearNotifications()
        {
            NotificationManager.Instance.AllClearNotification();
        }
    }
}
