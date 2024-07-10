using Application.Hotels.Repositories;
using Domain.Hotels.Entities;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Hotels.Repositories;

public class HotelRepository : IHotelRepository
{
    private readonly HotelManagementDbContext _dbContext;
    private readonly DbSet<Hotel> _entities;

    public HotelRepository(HotelManagementDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = _dbContext.Set<Hotel>();
    }

    public async Task Add(Hotel hotel)
    {
        await _entities.AddAsync(hotel);
    }
    public async Task<IReadOnlyList<Hotel>> GetAllHotels()
    {
        return await _entities.ToListAsync();
    }

    public async Task Update(Hotel hotel)
    {
        Hotel existingHotel = await GetHotelById(hotel.Id);
        existingHotel.Update(hotel);
    }

    public async Task Delete(int id)
    {
        Hotel existingHotel = await GetHotelById(id);
        _entities.Remove(existingHotel);
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        return await _entities.FirstOrDefaultAsync(h => h.Id == id);
    }
}
