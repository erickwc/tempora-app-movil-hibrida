using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tempora.MAUIApp.Models;

namespace Tempora.MAUIApp.Services
{
    public class PeriodoService
    {
        private const string _endPoint = "api/Periodo";
        private readonly HttpClient _http;

        public PeriodoService(HttpClient http)
        {
            _http = http;
        }

        // GET: api/Periodo
        public async Task<List<Periodo>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<Periodo>>(_endPoint) ?? new List<Periodo>();
        }

        // GET: api/Periodo/5
        public async Task<Periodo> ObtenerPorId(int periodoId)
        {
            string url = $"{_endPoint}/{periodoId}";
            return await _http.GetFromJsonAsync<Periodo>(url) ?? new Periodo();
        }

        // GET: api/Periodo/totalhorasrealizadas?usuarioId=5
        public async Task<string> ObtenerTotalHorasRealizadas(int usuarioId)
        {
            string url = $"{_endPoint}/totalhorasrealizadas?usuarioId={usuarioId}";
            return await _http.GetStringAsync(url);
        }

        // GET: api/Periodo/searchbyuserid?usuarioId=5
        public async Task<List<Periodo>> BuscarPorUsuarioId(int usuarioId)
        {
            string url = $"{_endPoint}/searchbyuserid?usuarioId={usuarioId}";
            return await _http.GetFromJsonAsync<List<Periodo>>(url) ?? new List<Periodo>();
        }

        // GET: api/Periodo/contarperiodos?usuarioId=5
        public async Task<string> ContarPeriodosPorUsuario(int usuarioId)
        {
            string url = $"{_endPoint}/contarperiodos?usuarioId={usuarioId}";
            return await _http.GetStringAsync(url);
        }

        // GET: api/Periodo/search?estadoId=1&nombre=example
        public async Task<List<Periodo>> Buscar(byte? estadoId = null, string? nombre = null)
        {
            string url = $"{_endPoint}/search";

            if (estadoId.HasValue || !string.IsNullOrWhiteSpace(nombre))
            {
                var query = new List<string>();

                if (estadoId.HasValue)
                    query.Add($"estadoId={estadoId}");

                if (!string.IsNullOrWhiteSpace(nombre))
                    query.Add($"nombre={nombre}");

                url += "?" + string.Join("&", query);
            }

            return await _http.GetFromJsonAsync<List<Periodo>>(url) ?? new List<Periodo>();
        }

        // PUT: api/Periodo/5
        public async Task Editar(Periodo periodo)
        {
            string url = $"{_endPoint}/{periodo.PeriodoId}";
            await _http.PutAsJsonAsync(url, periodo);
        }

        // POST: api/Periodo
        public async Task<Periodo> Guardar(Periodo periodo)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_endPoint, periodo);

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Periodo>(content) ?? new Periodo();
        }

        // DELETE: api/Periodo/5
        public async Task Eliminar(int periodoId)
        {
            string url = $"{_endPoint}/{periodoId}";
            await _http.DeleteAsync(url);
        }

    }
}
