using ConcursoNestle.Services;
using ConcursoNestle.Models;

namespace ConcursoNestle.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Name = nameEntry.Text,
                Surname = surnameEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };

            var dbService = new DatabaseService();
            dbService.SaveUser(user);

            await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
            await Navigation.PopAsync(); // Regresar a la página de inicio
        }
    }
}
