using System.Net;
using APIV1.Models;
using APIV1.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIV1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly ILogger<ClientController> _logger;

    public ClientController(IClientService clientService, ILogger<ClientController> logger)
    {
        _clientService = clientService;
        _logger = logger;
    }

    /// <summary>
    /// Получение всех клиентов
    /// </summary>
    /// <param name="limit">Ограничение сверху количества возвращаемых клиентов</param>
    /// <param name="offset">Ограничение снизу количества возвращаемых клиентов</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /client/3/0
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpGet("{limit:int}/{offset:int}")]
    [ProducesResponseType(typeof(List<Client>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(int limit, int offset)
    {
        try
        {
            var allClients = await _clientService.GetAllClientsAsync(limit, offset);
            return Ok(allClients);
        }
        catch (ArgumentException e)
        {
            return BadRequest($"{e.Message}");
        }
    }
    
    /// <summary>
    /// Получение клиента по имени и фамилии
    /// </summary>
    /// <param name="name">Имя клиента</param>
    /// <param name="surname">Фамилия клиента</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /client/Tom/Cruse
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpGet("{name}/{surname}")]
    [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetClient(string name, string surname)
    {
        try
        {
            var client = await _clientService.GetClientAsync(name, surname);
            return Ok(client);
        }
        catch (ArgumentException e)
        {
            return BadRequest($"{e.Message}");
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteClient(Guid id)
    {
        try
        {
            var deletedClient = await _clientService.DeleteClientAsync(id);
            return Ok(deletedClient);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    }
    
    [HttpPost()]
    public async Task<IActionResult> AddClient([FromBody] Client client)
    {
        try
        {
            var addedClient = await _clientService.AddClientAsync(client);
            return Created($"/api/v1/clients/{addedClient.Id}", addedClient);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    } 
    
    [HttpPut()]
    public async Task<IActionResult> ChangeClientAddress(Guid id, [FromBody] Address address)
    {
        try
        {
            var updatedClient = await _clientService.ChangeClientAddressAsync(id, address);
            return Ok(updatedClient);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    } 
    
}