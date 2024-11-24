using ConcursoNestle.Services;
using System;

namespace ConcursoNestle.Pages
{
    public partial class LockPage : ContentPage
    {
        private readonly ApiService _apiService;

        public string BlockInfo { get; set; }

        public LockPage()
        {
            InitializeComponent();

            _apiService = new ApiService();

            // Obtener información de bloqueo de las preferencias
            string blockUser = Preferences.Get("BlockUser", "Usuario Desconocido");
            string blockTime = Preferences.Get("BlockTime", "Fecha desconocida");

            // Formatear la hora y fecha de bloqueo para que se muestren correctamente
            BlockInfo = $"Usuario que bloqueó: {blockUser}\nHora de bloqueo: {blockTime}";

            // Establecer el contexto de enlace para que el XAML pueda acceder a la propiedad
            BindingContext = this;
        }

        // Evento que se ejecuta cuando se hace clic en el botón de desbloquear
        private async void OnUnlockButtonClicked(object sender, EventArgs e)
        {
            string userName = Preferences.Get("UsuarioLogeado", "Usuario Desconocido");
            string unlockTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Guardamos el momento en que se desbloqueó localmente
            Preferences.Set("UnlockUser", userName);
            Preferences.Set("UnlockTime", unlockTime);

            // Enviar los datos del desbloqueo al servidor
            var success = await _apiService.RegistrarBloqueoDesbloqueo(userName, false); // `false` indica desbloqueo

            if (success)
            {
                // Mostrar la información de desbloqueo
                await DisplayAlert("Desbloqueo",
                                   $"Usuario que desbloqueó: {userName}\nHora de desbloqueo: {unlockTime}",
                                   "OK");

                // Volver a la pantalla principal después de desbloquear
                Application.Current.MainPage = new HomePageLoggedIn();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo registrar el desbloqueo en el servidor.", "OK");
            }
        }
    }
}



