using Application.Hotels.Entities;
using Application.Hotels.Repositories;
using Domain.Hotels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IReadOnlyList<Hotel>> GetAllHotels()
        {
            IReadOnlyList<Hotel> hotels = await _hotelRepository.GetAllHotels();
            return hotels;
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            Hotel hotel = await _hotelRepository.GetHotelById(id);

            return hotel;
        }
        public async Task Add(Hotel hotel)
        {
            _hotelRepository.Add(hotel);
        }

        public async Task Update(Hotel hotel)
        {
            _hotelRepository.Update(hotel);
        }
        public async Task Delete(int id)
        {
            _hotelRepository.Delete(id);
        }
    }
}
