namespace ConcursoNestle
{
    public partial class App : Application
    {
        public static string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            MainPage = new NavigationPage(new Pages.HomePage());
        }
    }

}


