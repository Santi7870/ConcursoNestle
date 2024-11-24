using ConcursoNestle.Services;
using ConcursoNestle.Models;

namespace ConcursoNestle.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly UsuarioService _usuarioService;

        public LoginPage()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService(App.DatabasePath);
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string correo = correoEntry.Text;
            string clave = claveEntry.Text;

            if (_usuarioService.ValidarLogin(correo, clave))
            {
                var usuario = _usuarioService.ObtenerUsuarioPorCorreo(correo);

                // Guardamos el nombre completo del usuario
                Preferences.Set("UsuarioLogeado", $"{usuario.Name} {usuario.Surname}");

                // Asignar la nueva página como MainPage
                Application.Current.MainPage = new NavigationPage(new HomePageLoggedIn());
            }
            else
            {
                await DisplayAlert("Error", "Correo o clave incorrectos", "OK");
            }
        }

    }
}


