using Microsoft.Extensions.Logging;
using RentRoomOfEquipment.Entity;
using RentRoomOfEquipment.Models.Contract;
using RentRoomOfEquipment.Models.Equipment;
using RentRoomOfEquipment.Models.Room;

namespace RentRoomOfEquipment.Data.Contracts
{
    public class RentRoomService : IRentRoomService
    {
        private readonly IRepository<Contract> contracts;
        private readonly IRepository<Room> rooms;
        private readonly IRepository<Equipment> equipments;
        private readonly ILogger<RentRoomService> _logger;
        public RentRoomService(IRepository<Contract> contracts, IRepository<Room> rooms, 
            IRepository<Equipment> equipments, ILogger<RentRoomService> logger)
        {
            this.contracts = contracts;
            this.rooms = rooms;
            this.equipments = equipments;

            _logger = logger;
        }
        public List<Contract> GetAllContracts()
        {
            return this.contracts.GetAll().ToList();
        }
        public bool TryCreateConract(int roomId, int equipmentId, int countOfEquipment)
        {
            Room? room = this.rooms.GetById(roomId);
            Equipment? equipment = this.equipments.GetById(equipmentId);

            if(room == null || equipment == null)
            {
                _logger.LogDebug("DB hasn't value for area or equipment");
                return false;
            }

            int area = CalculateArea(room, equipment, countOfEquipment);

            if(area >= 0)
            {
                room.Area = area;
                rooms.Update(room);

                Contract contract = new();
                contract.Equipment = equipment;
                contract.Room = room;
                contract.CountOfEquipment = countOfEquipment;

                this.contracts.Add(contract);

                _logger.LogDebug($"DB has new contract for placement:{room.Name}, remains area: {area}");
                return true;
            }

            _logger.LogDebug($"{room.Name} doesn't have area for that equipment. " +
                $"Free area: {room.Area}, needed: {equipment.Area * countOfEquipment}");
            return false;
        }
        private int CalculateArea(Room room, Equipment equipment, int countOfEquipment)
        {
            return room.Area - equipment.Area * countOfEquipment;
        }
    }

    public interface IRentRoomService
    {
        bool TryCreateConract(int roomId, int equipmentId, int countOfEquipment);
        List<Contract> GetAllContracts();
    }
}
