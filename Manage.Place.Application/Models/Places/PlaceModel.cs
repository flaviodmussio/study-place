using Manage.Place.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Place.Application.Models.Places
{
    public class PlaceModel
    {
        [Required]
        public string PlaceName { get; set; }

        [Required]
        public string PlaceCity { get; set; }

        [Required]
        public string PlaceState { get; set; }

        [Required]
        public string PlaceSlug { get; set; }
    }
}
