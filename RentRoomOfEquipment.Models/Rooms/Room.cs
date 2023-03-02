
using RentRoomOfEquipment.Models.Base;

namespace RentRoomOfEquipment.Models.Rooms
{
    public class Room : BaseId<int>
    {
        public string Name { get; set; } = null!;

        public int Area { get; set; }
    }
}
