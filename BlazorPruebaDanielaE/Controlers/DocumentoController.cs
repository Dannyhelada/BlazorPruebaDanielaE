using BlazorPruebaDanielaE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BlazorPruebaDanielaE.Controlers
{
    public class DocumentoController
    {
        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _options;

        public DocumentoController(HttpClient http)
        {
            _http = http;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public void SetToken(string token)
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<Documento>> ObtenerDocumentos()
        {
            var response = await _http.GetAsync("https://mainserver.ziursoftware.com/Ziur.API/basedatos_01/ZiurServiceRest.svc/api/DocumentosFillsCombos");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Documento>>(json, _options) ?? new List<Documento>();
        }



    }
}

