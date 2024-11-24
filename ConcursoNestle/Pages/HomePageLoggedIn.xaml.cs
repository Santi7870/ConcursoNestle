namespace ConcursoNestle.Pages
{
    public partial class HomePageLoggedIn : ContentPage
    {
        private readonly ApiService _apiService;

        public string UsuarioLogeado { get; set; }

        public HomePageLoggedIn()
        {
            InitializeComponent();

            UsuarioLogeado = Preferences.Get("UsuarioLogeado", "Invitado");
            BindingContext = this;
            _apiService = new ApiService();
        }

        // Evento que se ejecuta cuando se hace clic en el botón de bloquear
        private async void OnLockButtonClicked(object sender, EventArgs e)
        {
            // Obtener el nombre completo del usuario desde las preferencias
            var nombreEstudiante = Preferences.Get("UsuarioLogeado", null);

            // Verificar si el nombre no es nulo o vacío
            if (string.IsNullOrEmpty(nombreEstudiante))
            {
                await DisplayAlert("Error", "No se pudo obtener el nombre del estudiante.", "OK");
                return;
            }

            // Llamar al servicio para registrar el bloqueo con el nombre del estudiante
            var exito = await _apiService.RegistrarBloqueoDesbloqueo(nombreEstudiante, true); // true para bloqueo

            if (exito)
            {
                await DisplayAlert("Bloqueo", "La aplicación ha sido bloqueada.", "OK");

                // Navegar a la página de bloqueo
                await Navigation.PushAsync(new LockPage());
            }
            else
            {
                await DisplayAlert("Error", "No se pudo registrar el bloqueo.", "OK");
            }
        }
    }
}






