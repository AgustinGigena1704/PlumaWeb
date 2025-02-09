using Blazored.SessionStorage;
using System.Text.Json;
using System.Text;
namespace PlumaWeb.Extenciones
{
    public static class SessionStorageExtension
    {
        public static async Task GuardarEnStorage<T>(this ISessionStorageService sessionStorage, string key, T value) where T : class
        {
            string json = JsonSerializer.Serialize(value);
            await sessionStorage.SetItemAsStringAsync(key, json);
        }

        public static async Task<T> ObtenerDeStorage<T>(this ISessionStorageService sessionStorage, string key) where T : class
        {
            var json = await sessionStorage.GetItemAsStringAsync(key);
            var item = JsonSerializer.Deserialize<T>(json);
            if (item != null)
            {
                
                return item;
            }
            else
            {
                return null;
            }
        }
    }
}
