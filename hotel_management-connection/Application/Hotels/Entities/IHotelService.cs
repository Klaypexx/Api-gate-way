﻿using Domain.Hotels.Entities;

namespace Application.Hotels.Entities
{
    public interface IHotelService
    {
        Task<IReadOnlyList<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        Task Add(Hotel hotel);
        Task Update(Hotel hotel);
        Task Delete(int id);
    }
}
