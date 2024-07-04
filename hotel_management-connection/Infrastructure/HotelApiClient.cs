using Domain.Configurations.Entities;
using Domain.Hotels.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using Application.Hotels.Repositories;

namespace Infrastructure;

public class HotelApiClient : IHotelRepository
{

    private HttpClient _client = new HttpClient();
    private HotelApiDomain _hotelApiDomain;

    public HotelApiClient(HotelApiDomain hotelApiDomain)
    {
        _hotelApiDomain = hotelApiDomain;
    }

    public async Task Add(Hotel hotel)
    {
        HttpResponseMessage response = await _client.PostAsJsonAsync(_hotelApiDomain.Address, hotel);
    }
    public async Task<IReadOnlyList<Hotel>> GetAllHotels()
    {
        HttpResponseMessage response = await _client.GetAsync(_hotelApiDomain.Address);
        string responseString = await response.Content.ReadAsStringAsync();
        IReadOnlyList<Hotel> hotels = JsonConvert.DeserializeObject<IReadOnlyList<Hotel>>(responseString);
        return hotels;
    }

    public async Task<Hotel> GetHotelById(int id)
    {
        HttpResponseMessage response = await _client.GetAsync(_hotelApiDomain.Address + id);
        string responseString = await response.Content.ReadAsStringAsync();
        Hotel hotel = JsonConvert.DeserializeObject<Hotel>(responseString);
        return hotel;
    }

    public async Task Update(Hotel hotel)
    {
        HttpResponseMessage response = await _client.PutAsJsonAsync(_hotelApiDomain.Address + hotel.Id, hotel);
    }

    public async Task Delete(int id)
    {
        HttpResponseMessage response = await _client.DeleteAsync(_hotelApiDomain.Address + id);
    }
}
