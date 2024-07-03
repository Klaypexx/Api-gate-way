using Domain.Hotels.Entities;
using Domain.Hotels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels
{
    public class HotelService : IHotelService
    {
        private IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public IReadOnlyList<Hotel> GetAllHotels()
        {
            IReadOnlyList<Hotel> hotels = _hotelRepository.GetAllHotels();

            return hotels;
        }
        public Hotel GetHotelById(int id)
        {
            Hotel hotel = _hotelRepository.GetHotelById(id);

            return hotel;
        }
        public void Save(Hotel hotel)
        {
            Hotel newHotel = new(hotel.Name, hotel.Address, hotel.OpenSince);
            _hotelRepository.Save(newHotel);
        }
        public void Update(Hotel hotel)
        {
            Hotel newHotel = new(hotel.Id, hotel.Name, hotel.Address);
            _hotelRepository.Update(newHotel);
        }
        public void Delete(int id)
        {
            _hotelRepository.Delete(id);
        }
    }
}
