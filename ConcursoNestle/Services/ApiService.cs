using System.Net.Http;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<bool> RegistrarBloqueoDesbloqueo(string nombreEstudiante, bool esBloqueo)
    {
        // Asegúrate de que el nombre no esté vacío
        if (string.IsNullOrEmpty(nombreEstudiante))
        {
            return false; // O maneja el error de alguna otra manera
        }

        // Cambia el URL para apuntar correctamente a tu API en el servidor MVC
        var url = "http://localhost:5196/Bloqueo/Registrar"; // Asegúrate de que este sea el URL correcto

        var data = new
        {
            NombreEstudiante = nombreEstudiante,
            EsBloqueo = esBloqueo
        };

        var jsonData = JsonConvert.SerializeObject(data);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                // Lee la respuesta de error para obtener más detalles
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error al registrar el bloqueo: {errorContent}");
                return false;
            }
        }
        catch (Exception ex)
        {
            // Maneja excepciones de conexión o problemas de red
            Console.WriteLine($"Error en la solicitud: {ex.Message}");
            return false;
        }
    }
}


