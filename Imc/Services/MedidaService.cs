using Blazored.LocalStorage;
using Imc.Models;
using System.Text.Json;

namespace Imc.Services
{
    public class MedidaService : IMedidaService
    {
        private readonly ILocalStorageService _localStorageService;
        public MedidaService(ILocalStorageService localStorageService)
        {
              _localStorageService = localStorageService;
        }

        private string medidasLocalStorageKey => "medidakey";

        public async Task<List<Medida>> GetMedidas()
        {
            var medidaJson = await _localStorageService.GetItemAsync<string>(medidasLocalStorageKey);
            
            if (medidaJson == null) {
                return new();
            }

            return JsonSerializer.Deserialize<List<Medida>>(medidaJson);
        }

        public async Task SaveMedidas(List<Medida> medidas)
        {
            var medidasJson = JsonSerializer.Serialize(medidas);


            await _localStorageService.SetItemAsync(medidasLocalStorageKey, medidasJson);


        }
    }
}
