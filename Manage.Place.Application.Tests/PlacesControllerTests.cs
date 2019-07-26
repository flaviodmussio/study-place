using AutoMapper;
using Manage.Place.Application.Controllers;
using Manage.Place.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using FluentAssertions;
using Manage.Place.Domain.Events;
using System.Collections.Generic;
using Manage.Place.Domain.Entities;

namespace Manage.Place.Application.Tests
{
    public class PlacesControllerTests : ApplicationTestBase
    {
        private Mock<IPlaceRepository> _placeRepository;
        private Mock<IMapper> _mapper;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IDomainNotificationHandler> _domainNotificationHandler;

        public PlacesControllerTests()
        {

        }
        [Fact]
        public async Task Should_be_Return_Post_Ok_Status()
        {

            var placeModel = Fake.PlaceModel.Generate(1).FirstOrDefault();
            var place = new Places("teste", "teste", "teste", "teste"); 

            var instance = instanceController();

            _mapper.Setup(m => m.Map<Places>(placeModel)).Returns(place);

            var result = (ObjectResult)await instance.PostAsync(placeModel);

            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(1)]
        public async Task Should_be_Return_Put_Ok_Status(int id)
        {

            var placeModel = Fake.PlaceModel.Generate(1).FirstOrDefault();
            var place = new Places("teste", "teste", "teste", "teste");

            var instance = instanceController();

            _placeRepository.Setup(m => m.GetById(id)).Returns(place);

            var result = (ObjectResult)await instance.Put(id,placeModel);

            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(1)]
        public async Task Should_be_Return_Put_NotFound_Status(int id)
        {

            var placeModel = Fake.PlaceModel.Generate(1).FirstOrDefault();
            var place = new Places("teste", "teste", "teste", "teste");

            var instance = instanceController();

            var result = (ObjectResult)await instance.Put(id, placeModel);

            result.StatusCode.Should().Be(404);
        }

        [Theory]
        [InlineData(1)]
        public async Task Should_be_Return_Delete_Ok_Status(int id)
        {

            var place = new Places("teste", "teste", "teste", "teste");

            var instance = instanceController();

            _placeRepository.Setup(m => m.GetById(id)).Returns(place);

            var result = (ObjectResult)await instance.Delete(id);

            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(1)]
        public async Task Should_be_Return_Delete_NotFound_Status(int id)
        {

            var placeModel = Fake.PlaceModel.Generate(1).FirstOrDefault();
            var place = new Places("teste", "teste", "teste", "teste");

            var instance = instanceController();

            var result = (ObjectResult)await instance.Delete(id);

            result.StatusCode.Should().Be(404);
        }

        [Theory]
        [InlineData("teste")]
        public async Task Should_be_Return_GetName_Ok_Status(string name)
        {
            var place = new Places("teste", "teste", "teste", "teste");

            var instance = instanceController();

            _placeRepository.Setup(m => m.GetByName(name)).Returns(place);

            var result = (ObjectResult)await instance.Get(name);

            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData("teste")]
        public async Task Should_be_Return_GetName_NotFound_Status(string name)
        {
            var place = new Places("teste", "teste", "teste", "teste");

            var instance = instanceController();

            var result = (ObjectResult)await instance.Get(name);

            result.StatusCode.Should().Be(404);
        }

        [Fact]        
        public async Task Should_be_Return_Get_OK_Status()
        {
            var place = new Places("teste", "teste", "teste", "teste");
            var places = new List<Places>();
            places.Add(place);
            var instance = instanceController();

            _placeRepository.Setup(m => m.GetAll()).Returns(places);

            var result = (ObjectResult)await instance.Get();

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Should_be_Return_Get_NotFound_Status()
        {
            var places = new List<Places>();

            var instance = instanceController();

            _placeRepository.Setup(m => m.GetAll()).Returns(places);

            var result = (ObjectResult)await instance.Get();

            result.StatusCode.Should().Be(404);
        }


        private PlacesController instanceController()
        {
            _placeRepository = new Mock<IPlaceRepository>();

            _mapper = new Mock<IMapper>();

            _unitOfWork = new Mock<IUnitOfWork>();

            _domainNotificationHandler = new Mock<IDomainNotificationHandler>();


        var controller = new PlacesController(
                _placeRepository.Object,
                _mapper.Object,
                _unitOfWork.Object,
                _domainNotificationHandler.Object);

            return controller;
        }

    }
}
