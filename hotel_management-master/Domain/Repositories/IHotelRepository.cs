﻿using Domain.Entities;

namespace Domain.Repositories;

public interface IHotelRepository
{
    IReadOnlyList<Hotel> GetAllHotels();
    Hotel GetHotelById(int id);

    void Save( Hotel hotel );

    void Update( Hotel hotel );

    void Delete( int id );
}
