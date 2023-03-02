using RentRoomOfEquipment.Models.Base;

namespace RentRoomOfEquipment.Models.Equipments
{
    public class Equipment : BaseId<int>
    {
        public string Name { get; set; } = null!;
        public int Area { get; set; }
    }
}
