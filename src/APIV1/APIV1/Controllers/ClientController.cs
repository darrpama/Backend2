using System.Net;
using APIV1.Models;
using APIV1.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIV1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
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
    ///     GET api/v1/client/3/0
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
    ///     GET api/v1/client/Tom/Cruse
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
    
    /// <summary>
    /// Удаление клента по id
    /// </summary>
    /// <param name="id">Идентификатор клиента</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE api/v1/client/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
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
    
    /// <summary>
    /// Добавление клиента
    /// </summary>
    /// <param name="client">Json с полями клиента</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST api/v1/client
    ///
    ///     {
    ///        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///        "clientName": "string",
    ///        "clientSurname": "string",
    ///        "birthday": "2024-11-30T17:55:22.398Z",
    ///        "gender": "string",
    ///        "registrationDate": "2024-11-30T17:55:22.398Z",
    ///        "addressId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///        "address": {
    ///            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///            "country": "string",
    ///            "city": "string",
    ///            "street": "string"
    ///        }
    ///     }
    /// 
    /// </remarks>
    /// <returns></returns>
    /// <response code="201">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpPost()]
    [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
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
    
    /// <summary>
    /// Изменение адреса клиента
    /// </summary>
    /// <param name="id">Идентификатор клиента</param>
    /// <param name="address">Json с полями адреса</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST api/v1/client/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    ///      {
    ///          "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///          "country": "string",
    ///          "city": "string",
    ///          "street": "string"
    ///      }
    /// 
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpPut()]
    [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
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