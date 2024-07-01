using Domain.Entities;

namespace Domain.Repositories;

public interface IHotelRepository
{
    Task<string> GetAllHotels();
/*    Hotel GetHotelById(int id);

    void Save( Hotel hotel );

    void Update( Hotel hotel );

    void Delete( int id );*/
}
