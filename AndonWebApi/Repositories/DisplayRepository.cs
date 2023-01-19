using AndonWebApi.Context;
using AndonWebApi.Entities;
using System;

namespace AndonWebApi.Repositories
{
    public class DisplayRepository : GenericRepository<Display>, IDisplayRepository
    {
        public DisplayRepository(AppDbContext dbContext) : base(dbContext) { }

    }
}
