using Domain.Hotels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hotels
{
    public interface IHotelService
    {
        IReadOnlyList<Hotel> GetAllHotels();
        Hotel GetHotelById(int id);

        void Save(Hotel hotel);

        void Update(Hotel hotel);

        void Delete(int id);
    }
}
