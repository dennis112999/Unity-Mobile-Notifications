using UnityEngine;

namespace Notification
{
    public class NotificationManager : MonoBehaviour
    {
        private static NotificationManager _instance;
        public static NotificationManager Instance { get { return _instance; } }

        private static bool initialized;

#if UNITY_ANDROID
        private AndroidNotificationHandle androidManager;
#elif UNITY_IOS
        private IOSNotificationHandle iosManager;
#endif

        private void Awake()
        {
            if (_instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(this);

#if UNITY_ANDROID
            androidManager = new AndroidNotificationHandle();
#elif UNITY_IOS
        iosManager = new IOSNotificationHandle();
#endif
        }

        public void Initialize()
        {
            if (initialized) return;

            initialized = true;

#if UNITY_ANDROID
            androidManager.PlatformInitialize();
#elif UNITY_IOS
        iosManager.PlatformInitialize();
#endif

            AllClearNotification();
        }

        public void AllClearNotification()
        {
#if UNITY_ANDROID
            androidManager.AllClearNotification();
#elif UNITY_IOS
        iosManager.AllClearNotification();
#endif
        }

        public void AddScheduledNotification(string title, string message, int badgeCount, int elapsedTime, int notificationId)
        {
#if UNITY_ANDROID
            androidManager.AddScheduledNotification(title, message, badgeCount, elapsedTime);
#elif UNITY_IOS
        iosManager.AddScheduledNotification(title, message, badgeCount, elapsedTime, notificationId);
#endif
        }
    }

}