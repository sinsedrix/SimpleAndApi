#if ANDROID

namespace SimpleAndApi.Platforms.Android
{
    [Activity(Label = "org.tool2team.simpleandapi.MainActivity", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Pas de vue ou d'interface graphique ici
            // Démarre une tâche en arrière-plan ou un processus
            Task.Run(() =>
            {
                Program.Main(["5000"]);
            });
        }
    }
}

#endif
