using Application.Foundation.Entities;
using Infrastructure.Database;

namespace Infrastructure.Foundation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelManagementDbContext _context;

        public UnitOfWork(HotelManagementDbContext context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}