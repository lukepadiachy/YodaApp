using YodaApp.Views;

namespace YodaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute("FunFactsPage", typeof(FunFactsPageView));
           // Routing.RegisterRoute("loadsheddinganswer", typeof(LoadsheddingAnswerPage));
        }
    }
}
