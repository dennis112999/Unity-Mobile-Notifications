# Unity - MobileNotifications
 
A cross-platform notification manager for Unity, designed to handle local notifications on both Android and iOS. The `NotificationManager` utilizes platform-specific handlers (`AndroidNotificationHandle` and `iOSNotificationHandle`) to streamline the scheduling and clearing of notifications.

## Features
- **Cross-Platform**: Supports both Android and iOS notifications.
- **Notification Scheduling**: Schedule notifications with custom title, message, badge count, and delay.
- **Clear Notifications**: Clear all scheduled and delivered notifications on demand.

## Installation

1. Clone or download this repository.
2. Copy the `NotificationManager` and platform-specific scripts (`AndroidNotificationHandle.cs` and `iOSNotificationHandle.cs`) into your Unity project's `Scripts` folder.
3. Attach the `NotificationManager` script to a GameObject in your initial scene (e.g., an empty GameObject named `NotificationManager`).

## Setup

To configure your Unity project for notifications:
1. **Android**: Ensure that `android.permission.POST_NOTIFICATIONS` is enabled in `AndroidManifest.xml`.
2. **iOS**: Set up necessary configurations for iOS notifications (optional for basic use).

## Usage

### Initializing the Notification Manager

In your main script (e.g., `Start()` method of your main GameObject), initialize the `NotificationManager`:

```csharp
void Start()
{
    NotificationManager.Instance.Initialize();
}
