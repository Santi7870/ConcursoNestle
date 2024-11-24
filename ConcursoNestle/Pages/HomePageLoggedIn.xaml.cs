using System;

namespace ConcursoNestle.Pages
{
    public partial class HomePageLoggedIn : ContentPage
    {
        public string UsuarioLogeado { get; set; }

        public HomePageLoggedIn()
        {
            InitializeComponent();

            // Obt�n el nombre del usuario desde Preferences y config�ralo como propiedad
            UsuarioLogeado = Preferences.Get("UsuarioLogeado", "Invitado");

            // Establece el BindingContext para que la p�gina pueda acceder a las propiedades
            BindingContext = this;
        }
    }

}



