using Microsoft.EntityFrameworkCore;
using RentRoomOfEquipment.Models.Contract;
using RentRoomOfEquipment.Models.Equipment;
using RentRoomOfEquipment.Models.Room;

namespace RentRoomOfEquipment.Entity
{
    public class ROEContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        public ROEContext(DbContextOptions<ROEContext> options): base(options) { }


    }
}
