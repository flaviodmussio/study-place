using AutoMapper;
using Manage.Place.Application.Models.Places;
using Manage.Place.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manage.Place.Application.AutoMapper
{
    public class ModelToDomain : Profile
    {
        public ModelToDomain()
        {
            CreateMap<PlaceModel, Places>();
        }
    }
}
