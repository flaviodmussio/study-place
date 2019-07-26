using Bogus;
using Manage.Place.Application.Models.Places;
using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Manage.Place.Application.Tests.Models
{
    public class Fake
    {
        public Faker<PlaceModel> PlaceModel { get; set; }

        public Fake()
        {
            PlaceModel = new Faker<PlaceModel>()
                   .RuleFor(x => x.PlaceCity, f => f.Lorem.Word())
                   .RuleFor(x => x.PlaceName, f => f.Lorem.Word())
                   .RuleFor(x => x.PlaceSlug, f => f.Lorem.Word())
                   .RuleFor(x => x.PlaceState, f => f.Lorem.Word());
        }

        public int GenerateFakeId()
        {
            var random = new Random();
            return random.Next(99999, 999999);
        }

    }
}
