using Refit;
using app_console_refit.Services;
using app_console_refit.DTO;

try
{
    var minimalApi = RestService.For<IMinimalApi>("http://localhost:5054");
    
    Console.WriteLine("Incluir cliente");
    Console.WriteLine("---------------");

    var peterParker = await minimalApi.Post(new Cliente { Nome = "Peter Parker", Email = "peter.parker@marvel.com" });
    var benParker = await minimalApi.Post(new Cliente { Nome = "Ben Parker", Email = "peter.parker@marvel.com" });
    var maryJane = await minimalApi.Post(new Cliente { Nome = "Mary Jane", Email = "mary.jane@marvel.com" });
    
    Console.WriteLine($"Cliente incluído - {peterParker.Id} - {peterParker.Nome}");
    Console.WriteLine($"Cliente incluído - {benParker.Id} - {benParker.Nome}");
    Console.WriteLine($"Cliente incluído - {maryJane.Id} - {maryJane.Nome}");
    Console.WriteLine("");

    Console.WriteLine("Atualizar cliente");
    Console.WriteLine("-----------------");

    maryJane.Nome = "Mary Jane Watson";
    var maryJaneUpdate = await minimalApi.Put(maryJane.Id, maryJane);

    Console.WriteLine($"Cliente atualizado - {maryJaneUpdate.Id} - {maryJaneUpdate.Nome}");
    Console.WriteLine("");

    Console.WriteLine("Excluir cliente");
    Console.WriteLine("---------------");

    var benParkerDelete = await minimalApi.Delete(benParker.Id);
   
    Console.WriteLine($"Cliente excluído - {benParkerDelete.Id} - {benParkerDelete.Nome}");
    Console.WriteLine("");

    Console.WriteLine("Obter cliente");
    Console.WriteLine("-------------");

    var returnClienteQuery = await minimalApi.Get(peterParker.Id);

    Console.WriteLine($"Cliente obtido - {returnClienteQuery.Id} - {returnClienteQuery.Nome}");
    Console.WriteLine("");

    Console.WriteLine("Obter todos os clientes");
    Console.WriteLine("-----------------------");

    var returnAllClientesQuery = await minimalApi.Get();

    foreach (var currentCliente in returnAllClientesQuery)
    {
        Console.WriteLine($"{currentCliente.Id} - {currentCliente.Nome}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Ocorreu um erro: {ex.Message}");
}
