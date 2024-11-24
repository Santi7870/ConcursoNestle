namespace ConcursoNestle.Pages
{
    public partial class LockPage : ContentPage
    {
        public string BlockInfo { get; set; }

        public LockPage()
        {
            InitializeComponent();

            // Obtener información de bloqueo de las preferencias
            string blockUser = Preferences.Get("BlockUser", "Usuario Desconocido");
            string blockTime = Preferences.Get("BlockTime", "Fecha desconocida");

            // Asignar la información al BindingContext para mostrar en el XAML
            BlockInfo = $"Usuario que bloqueó: {blockUser}\nHora de bloqueo: {blockTime}";

            // Establecer el contexto de enlace para que el XAML pueda acceder a la propiedad
            BindingContext = this;
        }

        // Evento que se ejecuta cuando se hace clic en el botón de desbloquear
        private async void OnUnlockButtonClicked(object sender, EventArgs e)
        {
            string userName = Preferences.Get("UsuarioLogeado", "Usuario Desconocido");
            string unlockTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Guardamos el momento en que se desbloqueó
            Preferences.Set("UnlockUser", userName);
            Preferences.Set("UnlockTime", unlockTime);

            // Mostramos la información de desbloqueo
            await DisplayAlert("Desbloqueo",
                               $"Usuario que desbloqueó: {userName}\nHora de desbloqueo: {unlockTime}",
                               "OK");

            // Volver a la pantalla principal después de desbloquear
            Application.Current.MainPage = new HomePageLoggedIn();
        }
    }
}


