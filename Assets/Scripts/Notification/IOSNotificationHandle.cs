namespace Notification
{
#if UNITY_IOS
using Unity.Notifications.iOS;
using System;

public class IOSNotificationHandle
{
    public void PlatformInitialize()
    {
        // iOS-specific initialization if needed
    }

    public void AllClearNotification()
    {
        iOSNotificationCenter.RemoveAllScheduledNotifications();
        iOSNotificationCenter.RemoveAllDeliveredNotifications();
        iOSNotificationCenter.ApplicationBadge = 0;
    }

    public void AddScheduledNotification(string title, string message, int badgeCount, int elapsedTime, int notificationId)
    {
        var notification = new iOSNotification()
        {
            Identifier = $"notificationId_{notificationId}",
            Title = title,
            Body = message,
            ShowInForeground = false,
            Badge = badgeCount,
            Trigger = new iOSNotificationTimeIntervalTrigger()
            {
                TimeInterval = new TimeSpan(0, 0, elapsedTime),
                Repeats = false,
            }
        };
        iOSNotificationCenter.ScheduleNotification(notification);
    }

    public void OnApplicationPause(bool pause)
    {
        if (!pause) iOSNotificationCenter.ApplicationBadge = 0;
    }
}

#endif
}