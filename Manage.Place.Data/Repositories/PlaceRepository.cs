using Manage.Place.Domain.Entities;
using Manage.Place.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Manage.Place.Data.Repositories
{
    public class PlaceRepository : BaseRepository<Places>, IPlaceRepository
    {
        public PlaceRepository(DbContext context) : base(context)
        {
        }

        public Places GetByName(string name) =>
            _dbSet
            .Where(x => x.PlaceName.ToLower() == name.ToLower()).FirstOrDefault();
    }
}
