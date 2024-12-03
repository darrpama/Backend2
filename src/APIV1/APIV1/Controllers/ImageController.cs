using System.Net;
using APIV1.Models;
using APIV1.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIV1.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;
    private readonly ILogger<ClientController> _logger;

    public ImageController(IImageService imageService, ILogger<ClientController> logger)
    {
        _imageService = imageService;
        _logger = logger;
    }
    
    /// <summary>
    /// Получение изображения конкретного товара по id товара
    /// </summary>
    /// <param name="id">Id товара</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET api/v1/Image/ProductId/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpGet("ProductId/{id:guid}")]
    [ProducesResponseType(typeof(Image), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetImage(Guid id)
    {
        try
        {
            var image = await _imageService.GetImageAsync(id);
            return Ok(image);
        }
        catch (ArgumentException e)
        {
            return BadRequest($"{e.Message}");
        }
    }
    
    /// <summary>
    /// Получение изображения по id изображения
    /// </summary>
    /// <param name="id">Id изображения</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET api/v1/Image/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(Image), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetImageByProductId(Guid id)
    {
        try
        {
            var image = await _imageService.GetImageAsync(id);
            return Ok(image);
        }
        catch (ArgumentException e)
        {
            return BadRequest($"{e.Message}");
        }
    }
    
    /// <summary>
    /// Удаление изображения по id
    /// </summary>
    /// <param name="id">Идентификатор изображения</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE api/v1/Image/3fa85f64-5717-4562-b3fc-2c963f66afa6
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
            var deletedImage = await _imageService.DeleteImageAsync(id);
            return Ok(deletedImage);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    }
    
    /// <summary>
    /// Изменение изображения
    /// </summary>
    /// <param name="id">Идентификатор изображения</param>
    /// <param name="image">Строка изображения в json</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST api/v1/Image/3fa85f64-5717-4562-b3fc-2c963f66afa6
    ///
    ///      {
    ///          "image": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    ///      }
    /// 
    /// </remarks>
    /// <returns></returns>
    /// <response code="200">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpPut()]
    [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ChangeClientAddress([FromBody] Image image)
    {
        try
        {
            var updatedImage = await _imageService.UpdateImageAsync(image);
            return Ok(updatedImage);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    } 
    
    /// <summary>
    /// Добавление изображения
    /// </summary>
    /// <param name="image">Json с полями изображения</param>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST api/v1/image
    ///
    ///     {
    ///        "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    ///        "image": ""
    ///     }
    /// 
    /// </remarks>
    /// <returns></returns>
    /// <response code="201">Успешное выполнение</response>
    /// <response code="400">Ошибка API</response>
    [HttpPost()]
    [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddClient([FromBody] Image image)
    {
        try
        {
            var addedImage = await _imageService.AddImageAsync(image);
            return Created($"/api/v1/clients/{addedImage.Id}", addedImage);
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"{ex.Message}");
        }
    } 
}