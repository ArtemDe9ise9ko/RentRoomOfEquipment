using Microsoft.EntityFrameworkCore;
using RentRoomOfEquipment.Models.Contracts;
using RentRoomOfEquipment.Models.Equipments;
using RentRoomOfEquipment.Models.Rooms;

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
