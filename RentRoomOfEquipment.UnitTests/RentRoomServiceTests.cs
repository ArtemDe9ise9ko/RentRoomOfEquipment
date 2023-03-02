using Microsoft.Extensions.Logging;
using Moq;
using RentRoomOfEquipment.Data.Contracts;
using RentRoomOfEquipment.Entity;
using RentRoomOfEquipment.Models.Contracts;
using RentRoomOfEquipment.Models.Equipments;
using RentRoomOfEquipment.Models.Rooms;
using Xunit;

namespace RentRoomOfEquipment.UnitTests
{
    public class RentRoomServiceTests
    {
        Mock<IRepository<Contract>> contractsMock;
        Mock<IRepository<Room>> roomsMock;
        Mock<IRepository<Equipment>> equipmentsMock;
        Mock<ILogger<RentRoomService>> loggerMock;

        RentRoomService service;
        public RentRoomServiceTests()
        {
            contractsMock = new Mock<IRepository<Contract>>();
            roomsMock = new Mock<IRepository<Room>>();
            equipmentsMock = new Mock<IRepository<Equipment>>();
            loggerMock = new Mock<ILogger<RentRoomService>>();

            service = new RentRoomService(contractsMock.Object, roomsMock.Object, equipmentsMock.Object, loggerMock.Object);
        }

        Room room1 = new Room { Id = 1, Name = "Склад1", Area = 1100 };
        Room room2 = new Room { Id = 2, Name = "Склад2", Area = 240 };

        Equipment equipment1 = new Equipment { Id = 1, Name = "Обладнання1", Area = 20 };
        Equipment equipment2 = new Equipment { Id = 2, Name = "Обладнання2", Area = 60 };

        [Fact]
        public void GetAllContractsTest()
        {
            contractsMock.Setup(repo => repo.GetAll()).Returns(GetContracts());
            roomsMock.Setup(repo => repo.GetById(1)).Returns(room1);
            equipmentsMock.Setup(repo => repo.GetById(1)).Returns(equipment1);

            List<ContractDto> result = service.GetAllContracts() as List<ContractDto>;

            Assert.NotNull(result);
        }
        [Fact]
        public void CreateContractTest()
        {
            roomsMock.Setup(repo => repo.GetById(1)).Returns(room1);
            equipmentsMock.Setup(repo => repo.GetById(1)).Returns(equipment1);

            var result = service.TryCreateConract(1,1,2);

            Assert.True(result);
        }

        [Fact]
        public void CreateContractWithErrorTest()
        {
            roomsMock.Setup(repo => repo.GetById(2)).Returns(room2);
            equipmentsMock.Setup(repo => repo.GetById(2)).Returns(equipment2);

            var result = service.TryCreateConract(2,2,5);

            Assert.False(result);
        }

        private List<Contract> GetContracts()
        {
            return new List<Contract>()
            {
                new Contract() 
                { 
                Id = 1,
                RoomId = 1,
                EquipmentId = 1,
                CountOfEquipment = 2
                }
            };
        }
    }
}
