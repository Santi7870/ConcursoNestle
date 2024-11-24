using System;

namespace ConcursoNestle.Pages
{
    public partial class HomePageLoggedIn : ContentPage
    {
        public string UsuarioLogeado { get; set; }

        public HomePageLoggedIn()
        {
            InitializeComponent();

            // Obtén el nombre del usuario desde Preferences y configúralo como propiedad
            UsuarioLogeado = Preferences.Get("UsuarioLogeado", "Invitado");

            // Establece el BindingContext para que la página pueda acceder a las propiedades
            BindingContext = this;
        }
    }

}



