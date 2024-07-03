using Domain.Configurations.Entities;
using Domain.Hotels.Entities;
using Domain.Hotels.Repositories;
using Newtonsoft.Json;
using System.Text.Json;

namespace Infrastructure;

public class HotelApiClient : IHotelRepository
{

    private HttpClient _client = new HttpClient();
    private HotelApiDomain _hotelApiDomain;

    public HotelApiClient(HotelApiDomain hotelApiDomain)
    {
        _hotelApiDomain = hotelApiDomain;
    }

    public async Task<IReadOnlyList<Hotel>> GetAllHotels()
    {
        HttpResponseMessage response = await _client.GetAsync(_hotelApiDomain.Address + "hotels");
        string responseString = await response.Content.ReadAsStringAsync();
        IReadOnlyList<Hotel> hotels = JsonConvert.DeserializeObject<IReadOnlyList<Hotel>>(responseString);
        return hotels;
    }

    /*    public void Save( Hotel hotel )
        {
            _dbContext.Set<Hotel>().Add( hotel );
            _dbContext.SaveChanges();
        }

        public void Update( Hotel hotel )
        {
            Hotel existingHotel = GetHotelById( hotel.Id );
            existingHotel.CopyFrom( hotel );
            _dbContext.SaveChanges();
        }

        public void Delete( int id )
        {
            Hotel existingHotel = GetHotelById( id );
            _dbContext.Set<Hotel>().Remove( existingHotel );
            _dbContext.SaveChanges();
        }

        public Hotel GetHotelById( int id )
        {
            return _dbContext.Set<Hotel>().FirstOrDefault( h => h.Id == id );
        }*/
}
