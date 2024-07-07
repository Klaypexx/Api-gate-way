using Domain.Hotels.Entities;

namespace Application.Hotels.Repositories;

public interface IHotelRepository
{
    Task Add(Hotel hotel);
    Task<IReadOnlyList<Hotel>> GetAllHotels();
    Task<Hotel> GetHotelById(int id);


    Task Update(Hotel hotel);

    Task Delete(int id);

    void Authorization();
}
