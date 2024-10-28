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
    public class DiaService
    {
        private const string _endPoint = "api/Dia";
        private readonly HttpClient _http;

        public DiaService(HttpClient http)
        {
            _http = http;
        }

        // GET: api/Dia
        public async Task<List<Dia>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<Dia>>(_endPoint) ?? new List<Dia>();
        }

        // GET: api/Dia/5
        public async Task<Dia> ObtenerPorId(long diaId)
        {
            string url = $"{_endPoint}/{diaId}";
            return await _http.GetFromJsonAsync<Dia>(url) ?? new Dia();
        }

        // GET: api/Dia/SearchByDate?fecha=2024-10-25&idPeriodo=1
        public async Task<List<Dia>> BuscarPorFechaYPeriodo(DateTime fecha, int idPeriodo)
        {
            string url = $"{_endPoint}/searchbydate?fecha={fecha:yyyy-MM-dd}&idPeriodo={idPeriodo}";
            return await _http.GetFromJsonAsync<List<Dia>>(url) ?? new List<Dia>();
        }

        // GET: api/Dia/SearchByPeriodoId?idPeriodo=1
        public async Task<List<Dia>> BuscarPorPeriodoId(int idPeriodo)
        {
            string url = $"{_endPoint}/searchbyperiodoid?idPeriodo={idPeriodo}";
            return await _http.GetFromJsonAsync<List<Dia>>(url) ?? new List<Dia>();
        }

        // GET: api/Dia/SumarHorasTotalesPorPeriodo?periodoId=1
        public async Task<string> SumarHorasTotalesPorPeriodo(int periodoId)
        {
            string url = $"{_endPoint}/sumarhorastotales?periodoId={periodoId}";
            return await _http.GetStringAsync(url);
        }

        // PUT: api/Dia/5
        public async Task Editar(Dia dia)
        {
            string url = $"{_endPoint}/{dia.DiaId}";
            await _http.PutAsJsonAsync(url, dia);
        }

        // POST: api/Dia
        public async Task<Dia> Guardar(Dia dia)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_endPoint, dia);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Dia>(content) ?? new Dia();
        }

        // DELETE: api/Dia/5
        public async Task Eliminar(long diaId)
        {
            string url = $"{_endPoint}/{diaId}";
            await _http.DeleteAsync(url);
        }

    }
}
