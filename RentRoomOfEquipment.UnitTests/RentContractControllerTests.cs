﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using RentRoomOfEquipment.App.Controllers;
using RentRoomOfEquipment.Data.Contracts;
using RentRoomOfEquipment.Models.Contract;
using RentRoomOfEquipment.Models.Equipment;
using RentRoomOfEquipment.Models.Room;
using Xunit;

namespace RentRoomOfEquipment.UnitTests
{
    public class RentContractControllerTests
    {
        Mock<IRentRoomService> rentRoomServiceMock;
        Mock<ILogger<RentContractController>> loggerMock;

        RentContractController controller;
        public RentContractControllerTests()
        {
            rentRoomServiceMock = new Mock<IRentRoomService>();
            loggerMock =  new Mock<ILogger<RentContractController>>();

            controller = new RentContractController(rentRoomServiceMock.Object, loggerMock.Object);
        }

        [Fact]
        public void GetAllMethod()
        {
            rentRoomServiceMock.Setup(repo => repo.GetAllContracts()).Returns(GetContracts());

            var result = controller.GetAll();

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateMethod()
        {
            rentRoomServiceMock.Setup(repo => repo.TryCreateConract(1,1,2)).Returns(true);

            var result = controller.Create(1,1,2);

           Assert.IsType<OkResult>(result);
        }

        private List<Contract> GetContracts()
        {
            return new List<Contract>()
            {
                new Contract() 
                { 
                Id = 1,
                Room = new Room { Id = 1, Name = "Склад1", Area = 1100 }, 
                Equipment = new Equipment { Id = 1, Name = "Обладнання1", Area = 20 },
                CountOfEquipment = 2
                }
            };
        }
    }
}