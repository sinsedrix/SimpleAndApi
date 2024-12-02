#if ANDROID
using Android.Content;
using Android.OS;
using Android.Util;

namespace SimpleAndApi.Platforms.Android
{
    //[Service]
    [Service(Name = "org.tool2team.simpleandapi.AuxFgService")]
    public class AuxFgService : Service
    {
        private bool _isRunning;

        public override IBinder? OnBind(Intent? intent) => null;

        public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
        {
            //Log.Debug("AuxFgService", "Service démarré en mode foreground");

            // Démarrer le service en mode foreground
            var notification = new Notification.Builder(this, "AuxFgServiceChannel")
                .SetContentTitle("Service en cours d'exécution")
                .SetContentText("Le service est actif.")
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .Build();

            StartForeground(1, notification);

            // Ta logique principale ici
            Task.Run(() =>
            {
                Log.Debug("AuxFgService", "Tâche en arrière-plan exécutée.");
                Program.Main(["5004"]);
            });

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            _isRunning = false;
            Log.Debug("AuxFgService", "Service arrêté !");
            base.OnDestroy();
        }
    }
}
#endif