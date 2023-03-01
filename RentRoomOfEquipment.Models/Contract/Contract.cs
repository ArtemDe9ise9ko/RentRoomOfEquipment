using RentRoomOfEquipment.Models.Base;

namespace RentRoomOfEquipment.Models.Contract
{
    public class Contract : BaseId<int>
    {
        public Room.Room Room { get; set; } = null!;

        public Equipment.Equipment Equipment { get; set; } = null!;

        public int CountOfEquipment { get; set; }
    }
}
