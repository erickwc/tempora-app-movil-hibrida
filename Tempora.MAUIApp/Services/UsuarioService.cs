using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Tempora.MAUIApp.Models;
using BCrypt.Net;

namespace Tempora.MAUIApp.Services
{
    public class UsuarioService
    {
        private const string _endPoint = "api/Usuario";
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Usuario> Autenticar(Credenciales credenciales)
        {
            string url = _endPoint + "/autenticacion";

            HttpResponseMessage response = await _http.PostAsJsonAsync(url, credenciales);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Usuario obj = JsonSerializer.Deserialize<Usuario>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new Usuario();

                return obj;
            }

            return new Usuario();
        }

        // GET: api/Usuario
        public async Task<List<Usuario>> ObtenerTodos()
        {
            return await _http.GetFromJsonAsync<List<Usuario>>(_endPoint) ?? new List<Usuario>();
        }

        // GET: api/Usuario/5
        public async Task<Usuario> ObtenerPorId(int usuarioId)
        {
            string url = $"{_endPoint}/{usuarioId}";
            return await _http.GetFromJsonAsync<Usuario>(url) ?? new Usuario();
        }

        // GET: api/Usuario/searchbyuserid/{usuarioId}
        public async Task<string> ObtenerNombrePorId(int usuarioId)
        {
            string url = $"{_endPoint}/searchbyuserid?usuarioId={usuarioId}";
            string nombreUsuario = await _http.GetStringAsync(url);

            return nombreUsuario;
        }


        // GET: api/Usuario/search?telefono=1234567890&clave=miClave
        public async Task<List<Usuario>> Buscar(string telefono, string clave)
        {
            string url = $"{_endPoint}/search?telefono={telefono}&clave={clave}";
            return await _http.GetFromJsonAsync<List<Usuario>>(url) ?? new List<Usuario>();
        }

        // PUT: api/Usuario/5
        public async Task Editar(Usuario usuario)
        {
            string url = $"{_endPoint}/{usuario.UsuarioId}";
            await _http.PutAsJsonAsync(url, usuario);
        }

        // POST: api/Usuario
        public async Task<Usuario> Guardar(Usuario usuario)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync(_endPoint, usuario);
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Usuario>(content) ?? new Usuario();
        }

        // DELETE: api/Usuario/5
        public async Task Eliminar(int usuarioId)
        {
            string url = $"{_endPoint}/{usuarioId}";
            await _http.DeleteAsync(url);
        }

        
    }
}
