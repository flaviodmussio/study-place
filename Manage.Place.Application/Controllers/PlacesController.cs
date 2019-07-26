using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Manage.Place.Application.Models.Places;
using Manage.Place.Domain.Consts;
using Manage.Place.Domain.Entities;
using Manage.Place.Domain.Events;
using Manage.Place.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Manage.Place.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : BaseController
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDomainNotificationHandler _domainNotificationHandler;

        public PlacesController(IPlaceRepository placeRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IDomainNotificationHandler domainNotificationHandler) : base(domainNotificationHandler)
        {
            _placeRepository = placeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _domainNotificationHandler = domainNotificationHandler;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var place = _placeRepository.GetAll();

            if (place.Count() is 0)
                return NotFound(new ErrorResponseModel(PlacesErrorConstants.NotExistsPlace));

            return Ok(place);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var place = _placeRepository.GetByName(name);

            if (place is null)
                return NotFound(new ErrorResponseModel(PlacesErrorConstants.NameNotFound));

            return Ok(place);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PlaceModel place)
        {
            var modelStateErrors = ModelStateErrors();

            Places places = _mapper.Map<Places>(place);
            _placeRepository.Add(places);

            await _unitOfWork.SaveChangesAsync();

            return Ok(places);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,PlaceModel placeModel)
        {
            var place = _placeRepository.GetById(id);

            if (place is null)
                return NotFound(new ErrorResponseModel(PlacesErrorConstants.IdNotFound));

            place.PlaceCity = placeModel.PlaceCity;
            place.PlaceName = placeModel.PlaceName;
            place.PlaceSlug = placeModel.PlaceSlug;
            place.PlaceState = placeModel.PlaceState;

            _placeRepository.Update(place);

            await _unitOfWork.SaveChangesAsync();

            return Ok(placeModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var place = _placeRepository.GetById(id);

            if (place is null)
                return NotFound(new ErrorResponseModel(PlacesErrorConstants.IdNotFound));

            place.Inactivate();
            _placeRepository.Update(place);

            await _unitOfWork.SaveChangesAsync();

            return Ok(id);
        }
    }
}
