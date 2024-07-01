using Domain.Entities;
using Domain.Repositories;
using System.Net.Http;
using System;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Infrastructure.Foundation.Repositories;

public class EFHotelRepository : IHotelRepository
{

    public HttpClient _client = new HttpClient();

    public async Task<string> GetAllHotels()
    {
        _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = _client.GetAsync("http://localhost:5065/hotels").Result;
        return response.Content.ReadAsStringAsync().Result;
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
