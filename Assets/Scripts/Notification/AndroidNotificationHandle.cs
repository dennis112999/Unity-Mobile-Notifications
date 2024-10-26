using UnityEngine;

namespace Notification
{
#if UNITY_ANDROID
    using Unity.Notifications.Android;
    using UnityEngine.Android;
    using System;

    public class AndroidNotificationHandle
    {
        private string channelId;

        public void PlatformInitialize()
        {
            channelId = Application.identifier;

            var channel = new AndroidNotificationChannel()
            {
                Id = channelId,
                Name = "LocalNotificationChannel",
                Importance = Importance.High,
                Description = "LocalNotificationChannel",
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);

            if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
            {
                Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
            }
        }

        public void AllClearNotification()
        {
            AndroidNotificationCenter.CancelAllScheduledNotifications();
            AndroidNotificationCenter.CancelAllNotifications();
        }

        public void AddScheduledNotification(string title, string message, int badgeCount, int elapsedTime)
        {
            var notification = new AndroidNotification()
            {
                Title = title,
                Text = message,
                Number = badgeCount,
                SmallIcon = "icon_0",
                FireTime = DateTime.Now.AddSeconds(elapsedTime),
            };

            AndroidNotificationCenter.SendNotification(notification, channelId);
        }
    }

#endif
}
