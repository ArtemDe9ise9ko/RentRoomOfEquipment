using System.ComponentModel.DataAnnotations;

namespace RentRoomOfEquipment.Models.Base
{
    public abstract class BaseId<TKey>
    {
        [Key]
        public int Id { get; set; }
    }
}
