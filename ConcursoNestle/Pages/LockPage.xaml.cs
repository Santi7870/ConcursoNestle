using ConcursoNestle.Services;
using System;

namespace ConcursoNestle.Pages
{
    public partial class LockPage : ContentPage
    {
        private readonly ApiService _apiService;

        public LockPage()
        {
            InitializeComponent();

            _apiService = new ApiService();

            // Obtener información de bloqueo de las preferencias
            string blockUser = Preferences.Get("BlockUser", "Usuario Desconocido");
            string blockTime = Preferences.Get("BlockTime", "Hora desconocida");

            // Mostrar la información en las etiquetas
            BlockedUserLabel.Text = $"Usuario que bloqueó: {blockUser}";
            BlockedTimeLabel.Text = $"Hora de bloqueo: {blockTime}";
        }

        private async void OnUnlockButtonClicked(object sender, EventArgs e)
        {
            string userName = Preferences.Get("UsuarioLogeado", "Usuario Desconocido");
            string unlockTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Preferences.Set("UnlockUser", userName);
            Preferences.Set("UnlockTime", unlockTime);

            // Registrar el desbloqueo en el servidor
            var success = await _apiService.RegistrarBloqueoDesbloqueo(userName, false);

            if (success)
            {
                await DisplayAlert("Desbloqueo", $"Desbloqueado por: {userName}\nHora: {unlockTime}", "OK");
                Application.Current.MainPage = new HomePageLoggedIn();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo registrar el desbloqueo en el servidor.", "OK");
            }
        }
    }
}




