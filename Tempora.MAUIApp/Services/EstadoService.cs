using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Tempora.MAUIApp.Models;

namespace Tempora.MAUIApp.Services
{
    public class EstadoService
    {
        private const string _endPoint = "api/Estado";
        private readonly HttpClient _http;

        public EstadoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Estado>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<Estado>>(_endPoint) ?? new List<Estado>();
        }

    }
}
