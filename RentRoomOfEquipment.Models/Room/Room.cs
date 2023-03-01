using RentRoomOfEquipment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentRoomOfEquipment.Models.Room
{
    public class Room : BaseId<int>
    {
        public string Name { get; set; } = null!;

        public int Area { get; set; }
    }
}
