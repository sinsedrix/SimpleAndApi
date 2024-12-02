#if ANDROID
using Android.Content;
using Android.OS;
using Android.Util;

namespace SimpleAndApi.Platforms.Android
{
    //[Service]
    [Service(Name = "org.tool2team.simpleandapi.MainService")]
    public class MainService : Service
    {
        private bool _isRunning;

        public override IBinder? OnBind(Intent? intent)
        {
            return null; // Nous n'avons pas de liaison à une activité, donc nous retournons null
        }

        public override void OnCreate()
        {
            base.OnCreate();
            _isRunning = true;
            // Cette méthode est appelée lorsque le service est créé
        }

        public override StartCommandResult OnStartCommand(Intent? intent, StartCommandFlags flags, int startId)
        {
            // Le service est démarré, et le code principal peut être exécuté ici
            Task.Run(() =>
            {
                Log.Debug("MainService", "Tâche en arrière-plan exécutée.");
                Program.Main(["5001"]);
            });

            // Retourne START_STICKY pour que le service continue après la fermeture de l'activité
            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            _isRunning = false;
            Log.Info("MainService", "Service arrêté");
            base.OnDestroy();
        }
    }
}
#endif