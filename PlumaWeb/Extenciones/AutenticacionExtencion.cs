using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using PlumaWeb.DTOs;
using System.Security.Claims;

namespace PlumaWeb.Extenciones
{
    public class AutenticacionExtencion : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorage;
        private ClaimsPrincipal sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

        public AutenticacionExtencion(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task ActualizarEstadoAutenticacion(SessionDTO? sessionUsuario)
        {
            ClaimsPrincipal claimsPrincipal;

            if (sessionUsuario != null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Name, sessionUsuario.Username),
                    new Claim(ClaimTypes.Role, sessionUsuario.Perfil.Nombre)
                }, "JwtAuth"));

                await _sessionStorage.GuardarEnStorage("session", sessionUsuario);
            }
            else
            {
                claimsPrincipal = sinInformacion;
                await _sessionStorage.RemoveItemAsync("session");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }



        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var sessionUsuario = await _sessionStorage.ObtenerDeStorage<SessionDTO>("session");

            if(sessionUsuario == null)
                return await Task.FromResult(new AuthenticationState(sinInformacion));

            var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, sessionUsuario.Username),
                new Claim(ClaimTypes.Role, sessionUsuario.Perfil.Nombre)
            }, "JwtAuth"));

            return await Task.FromResult(new AuthenticationState(claimsPrincipal));
        }
    }
}
