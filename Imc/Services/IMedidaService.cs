using Imc.Models;

namespace Imc.Services
{
    public interface  IMedidaService
    {
        Task<List<Medida>> GetMedidas();
        Task SaveMedidas(List<Medida> medidas);
    }
}
