namespace ConcursoNestle.Pages
{
    public partial class HomePageLoggedIn : ContentPage
    {
        public string UsuarioLogeado { get; set; }

        public HomePageLoggedIn()
        {
            InitializeComponent();

            UsuarioLogeado = Preferences.Get("UsuarioLogeado", "Invitado");
            BindingContext = this;
        }

        // Evento que se ejecuta cuando se hace clic en el botón de bloquear
        private async void OnLockButtonClicked(object sender, EventArgs e)
        {
            string userName = Preferences.Get("UsuarioLogeado", "Usuario Desconocido");
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Guardamos el momento en que se bloqueó
            Preferences.Set("BlockUser", userName);
            Preferences.Set("BlockTime", time);

            // Navegar a la pantalla de bloqueo
            Application.Current.MainPage = new LockPage();
        }
    }
}





