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
        // Validar que el nombre del estudiante no sea nulo o vacío
        if (string.IsNullOrEmpty(nombreEstudiante))
        {
            return false;
        }

        var url = "http://localhost:5196/Bloqueo/Registrar"; // Asegúrate de que este sea el URL correcto

        // Crear el objeto con los datos para enviar
        var data = new
        {
            NombreEstudiante = nombreEstudiante,
            EsBloqueo = esBloqueo,
            Hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") // Incluimos la hora y fecha del evento
        };

        var jsonData = JsonConvert.SerializeObject(data);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        using (var client = new HttpClient())
        {
            try
            {
                var response = await client.PostAsync(url, content);

                // Verifica si la solicitud fue exitosa
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la solicitud: {ex.Message}");
                return false;
            }
        }
    }

}


