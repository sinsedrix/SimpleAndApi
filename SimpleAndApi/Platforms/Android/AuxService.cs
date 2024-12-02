#if ANDROID
using Android.Content;
using Android.OS;
using Android.Util;

namespace SimpleAndApi.Platforms.Android
{
    //[Service]
    [Service(Name = "org.tool2team.simpleandapi.AuxService")]
    public class AuxService : Service
    {
        private bool _isRunning;

        public override IBinder? OnBind(Intent? intent)
        {
            return null; // Nous n'avons pas de liaison à une activité, donc nous retournons null
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Log.Info("AuxService", "Service créé");
            _isRunning = true;
        }

        public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
        {
            Log.Info("AuxService", "Service démarré");

            // Tâche en arrière-plan : afficher "Hello World" toutes les 5 secondes
            Task.Run(() =>
            {
                Log.Debug("AuxService", "Tâche en arrière-plan exécutée.");
                Program.Main(["5003"]);
            });

            return StartCommandResult.Sticky; // Continue même après la fermeture de l'application
        }

        public override void OnDestroy()
        {
            _isRunning = false;
            Log.Info("AuxService", "Service arrêté");
            base.OnDestroy();
        }
    }
}
#endif