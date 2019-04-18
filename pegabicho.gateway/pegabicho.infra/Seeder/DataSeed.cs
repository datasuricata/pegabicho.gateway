using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.infra.ORM;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.infra.Seeder {
    public static class DataSeed
    {
        public static async System.Threading.Tasks.Task InitializeAsync(IServiceProvider service)
        {
            try
            {
                using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>())) {
                    if (!context.Users.Any()) {

                        // Root
                        var user = User.Seeder("lucas.moraes@datasuricata.com.br", "m0raes@!!",
                            new General(GenderType.Male, "33333333", "41998623719", "Lucas Rocha", "de Moraes", new DateTime(1994, 09, 22)),
                            new Address("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040"),
                            new List<Pet>().Add(new Pet("Morgana", null, null, PetSize.Small, PetSpecie.Cat, new DateTime(2015, 09, 22), 2.3f)),
                            new List<Wallet>().Add(new Wallet(PaymentType.Credit, "0000", "0000", "09319765960", 15, true)),
                            new List<Access>() {
                                new Access(UserType.Admin) {
                                    Roles = new List<Role>();
                                }
                            }
                            );
                        
                        // # add default users
                        context.Users.AddRange(
                            );
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var msg = e.Message;
            }
        }
    }
}
