using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentRoomOfEquipment.Models.Equipments;
using RentRoomOfEquipment.Models.Rooms;

namespace RentRoomOfEquipment.Entity
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ROEContext(serviceProvider.GetRequiredService<DbContextOptions<ROEContext>>()))
            {
                if (context.Rooms.Any() || context.Equipments.Any())
                {
                    return;
                }

                AddRooms(context);
                AddEquipment(context);

                context.SaveChanges();
            }
        }
        private static void AddRooms(ROEContext context)
        {
            context.Rooms.AddRange(
                new Room { Name = "Склад1", Area = 1100 },
                new Room { Name = "Склад2", Area = 800 },
                new Room { Name = "Склад3", Area = 600 },
                new Room { Name = "Склад4", Area = 280 },
                new Room { Name = "Склад5", Area = 360 }
            );
        }
        private static void AddEquipment(ROEContext context)
        {
            context.Equipments.AddRange(
                new Equipment { Name = "Обладнання1", Area = 20 },
                new Equipment { Name = "Обладнання2", Area = 30 },
                new Equipment { Name = "Обладнання3", Area = 15 },
                new Equipment { Name = "Обладнання5", Area = 40 },
                new Equipment { Name = "Обладнання4", Area = 60 }
            );
        }
    }
}
