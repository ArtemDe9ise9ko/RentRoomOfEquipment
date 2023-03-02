
using RentRoomOfEquipment.Models.Base;
using RentRoomOfEquipment.Models.Equipments;
using RentRoomOfEquipment.Models.Rooms;

namespace RentRoomOfEquipment.Models.Contracts
{
    public class Contract : BaseId<int>
    {
        public int RoomId { get; set; }

        public int EquipmentId { get; set; }

        public int CountOfEquipment { get; set; }
    }
}
