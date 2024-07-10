using Application.Foundation.Entities;
using Application.Hotels.Entities;
using Application.Hotels.Repositories;
using Domain.Hotels.Entities;

namespace Application.Hotels.Services
{
    public class HotelService : IHotelService
    {
        private IHotelRepository _hotelRepository;
        private readonly IUnitOfWork _unitOfWork;
        public HotelService(IHotelRepository hotelRepository, IUnitOfWork unitOfWork)
        {
            _hotelRepository = hotelRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(Hotel hotel)
        {
            await _hotelRepository.Add(hotel);
            await _unitOfWork.Save();
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
        public async Task Update(Hotel hotel)
        {
            await _hotelRepository.Update(hotel);
            await _unitOfWork.Save();
        }
        public async Task Delete(int id)
        {
            await _hotelRepository.Delete(id);
            await _unitOfWork.Save();
        }
    }
}
