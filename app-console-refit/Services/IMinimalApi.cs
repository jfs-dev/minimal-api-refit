using Refit;
using app_console_refit.DTO;

namespace app_console_refit.Services;

public interface IMinimalApi
{
    [Get("/v1/clientes")]
    Task<List<Cliente>> Get();

    [Get("/v1/clientes/{id}")]
    Task<Cliente> Get(int id);

    [Post("/v1/clientes")]
    Task<Cliente> Post([Body] Cliente cliente);

    [Put("/v1/clientes/{id}")]
    Task<Cliente> Put(int id, [Body] Cliente cliente);

    [Delete("/v1/clientes/{id}")]
    Task<Cliente> Delete(int id);
}
