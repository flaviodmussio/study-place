using System;
using System.Collections.Generic;
using System.Text;

namespace Manage.Place.Domain.Entities
{
    public class Places : Entity
    {

        public Places(string placeName, string placeCity, string placeState, string placeSlug)
        {
            PlaceName = placeName;
            PlaceCity = placeCity;
            PlaceState = placeState;
            PlaceSlug = placeSlug;
        }

        public string PlaceName { get; set; }
        public string PlaceCity { get; set; }
        public string PlaceState { get; set; }
        public string PlaceSlug { get; set; }

        public Places() { }
    }
}
