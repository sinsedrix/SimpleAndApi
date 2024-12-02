#if ANDROID
using Android.Content;
using Android.OS;
using Android.Runtime;

namespace SimpleAndApi.Platforms.Android
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownerShip) : base(handle, ownerShip)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            CreateNotificationChannel();
        }

        public void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channel = new NotificationChannel(
                    "MainFgServiceChannel",
                    "Service Notifications",
                    NotificationImportance.Default)
                {
                    Description = "Notifications pour le service MainFg"
                };

                var manager = GetSystemService(NotificationService) as NotificationManager;
                manager?.CreateNotificationChannel(channel);

                var channel2 = new NotificationChannel(
                    "AuxFgServiceChannel",
                    "Service Notifications",
                    NotificationImportance.Default)
                {
                    Description = "Notifications pour le service AuxFg"
                };

                manager?.CreateNotificationChannel(channel2);
            }
        }
    }
}
#endif