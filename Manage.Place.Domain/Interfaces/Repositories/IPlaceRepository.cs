using Manage.Place.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manage.Place.Domain.Interfaces.Repositories
{
    public interface IPlaceRepository : IRepository<Places>
    {
        Places GetByName(string name);
    }
}
