using Application.Hotels.Entities;
using Domain.Hotels.Entities;
using HotelManagement.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers;

// Описание работы с web api https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio
[ApiController]
[Route( "hotels" )]
[Authorize]
// http-протокол https://developer.mozilla.org/ru/docs/Web/HTTP
// методы http - https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods
public class HotelsController : ControllerBase
{
    private readonly IHotelService _hotelService;

    // DI-контейнер
    public HotelsController(IHotelService hotelService )
    {
        _hotelService = hotelService;
    }

    // Http-метод GET
    // GET подразумевает что мы запрашиваем данные с сервера, не меняем состояние на нем
    // может содержать query-параметре в качестве метода фильтра/уточнения запроса данных
    [HttpGet( "" )]
    public async  Task<IActionResult> GetHotels()
    {
        IReadOnlyList<Hotel> hotels = await _hotelService.GetAllHotels();

        return Ok( hotels );
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetHotelsById([FromRoute] int id)
    {
        Hotel hotel = await _hotelService.GetHotelById(id);

        return Ok(hotel);
    }

    // Http-метод POST
    // POST метод подразумевает изменение состояния на сервере, например, создание нового отеля
    // Также содержит body - тело запроса, в нем передаются данные
    [HttpPost( "" )]
    public async Task<IActionResult> CreateHotel( [FromBody] CreateHotelDto request )
    {
        Hotel hotel = new() { Name = request.Name, Address = request.Address, OpenSince = request.OpenSince };
        await _hotelService.Add( hotel );

        // возвращает http-ответ со статусом 200-ОК
        return Ok();
    }

    // Http-метод PUT
    // PUT означает изменение состояние на сервере для сущ-их данных
    [HttpPut( "{id:int}" )]
    public async Task<IActionResult> ModifyHotel( [FromRoute] int id, [FromBody] ModifyHotelDto request)
    {
        // нет валидации
        // создаем отель, когда на самом деле надо модифицировать
        // отделение методов по изменению - например изменить только адресс

        Hotel hotel = new() { Id = id, Name = request.Name, Address = request.Address };

        await _hotelService.Update( hotel );
        return Ok();
    }

    [HttpDelete( "{id:int}" )]
    public async Task<IActionResult> DeleteHotel( [FromRoute] int id )
    {
        await _hotelService.Delete( id );

        return Ok();
    }
}


