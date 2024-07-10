using Domain.Hotels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels.Entities
{
    public interface IHotelService
    {
        Task Add(Hotel hotel);
        Task<IReadOnlyList<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);


        Task Update(Hotel hotel);

        Task Delete(int id);
    }
}
