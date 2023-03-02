namespace RentRoomOfEquipment.Models.Contracts
{
    public class ContractDto
    {
        public string NameRoom { get; set; } = null!;
        public string NameEquipment { get; set; } = null!;

        public int CountEquipment { get; set; }
    }
}
