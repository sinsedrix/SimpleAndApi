#if ANDROID
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;

namespace SimpleAndApi.Platforms.Android
{
    //[Service]
    [Service(Name = "org.tool2team.simpleandapi.MainFgService")]
    public class MainFgService : Service
    {
        private bool _isRunning;

        public override IBinder? OnBind(Intent? intent) => null;

        public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
        {
            Log.Debug("MainFgService", "Service démarré en mode foreground");

            // Démarrer le service en mode foreground
            var notification = new Notification.Builder(this, "MainFgServiceChannel")
                .SetContentTitle("Service en cours d'exécution")
                .SetContentText("Le service est actif.")
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .Build();

            StartForeground(1, notification, ForegroundService.TypeDataSync);

            // Logique principale 
            Task.Run(() =>
            {
                Log.Debug("MainFgService", "Tâche en arrière-plan exécutée.");
                Program.Main(["5002"]);
            });

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Log.Debug("MainFgService", "Service arrêté !");
        }
    }
}
#endif