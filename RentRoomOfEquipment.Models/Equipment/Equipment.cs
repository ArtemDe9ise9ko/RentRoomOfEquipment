using RentRoomOfEquipment.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentRoomOfEquipment.Models.Equipment
{
    public class Equipment : BaseId<int>
    {
        public string Name { get; set; } = null!;
        public int Area { get; set; }
    }
}
