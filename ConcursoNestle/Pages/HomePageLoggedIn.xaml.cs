namespace ConcursoNestle.Pages
{
    public partial class HomePageLoggedIn : ContentPage
    {
        private readonly ApiService _apiService;

        public string UsuarioLogeado { get; set; }
        public string CurrentTime => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        public HomePageLoggedIn()
        {
            InitializeComponent();

            UsuarioLogeado = Preferences.Get("UsuarioLogeado", "Invitado");
            BindingContext = this;

            _apiService = new ApiService();
        }

        private async void OnLockButtonClicked(object sender, EventArgs e)
        {
            var nombreEstudiante = Preferences.Get("UsuarioLogeado", null);

            if (string.IsNullOrEmpty(nombreEstudiante))
            {
                await DisplayAlert("Error", "No se pudo obtener el nombre del estudiante.", "OK");
                return;
            }

            // Guardar la hora actual en las preferencias como la hora de bloqueo
            string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Preferences.Set("BlockTime", currentTime);
            Preferences.Set("BlockUser", nombreEstudiante);

            // Registrar el bloqueo en el servidor
            var exito = await _apiService.RegistrarBloqueoDesbloqueo(nombreEstudiante, true);

            if (exito)
            {
                await DisplayAlert("Bloqueo", $"La aplicación ha sido bloqueada a las {currentTime}.", "OK");
                // Navegar a la página de LockPage
                Application.Current.MainPage = new LockPage();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo registrar el bloqueo.", "OK");
            }
        }
    }
}







