using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.infra.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.infra.Seeder {
    public static class DataSeed {
        public static async System.Threading.Tasks.Task InitializeAsync(IServiceProvider service) {
            try {
                using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>())) {
                    if (!context.Users.Any()) {

                        // # root users
                        var root1 = User.Seeder("lucas.moraes@datasuricata.br", "m0raes@123!!",
                            new General(GenderType.Male, "33333333", "41998623719", "Lucas Rocha", "de Moraes", new DateTime(1994, 09, 22)),
                            new Address("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040"),
                            new List<Pet> {
                                new Pet("Morgana", null, null, PetSize.Small, PetSpecie.Cat, new DateTime(2015, 09, 22), 2.3f, new Race("Sem raça definida"))
                            },
                            new List<Wallet> {
                                new Wallet(PaymentType.Credit, "0000", "0000", "09319765960", 15, true)
                            },
                            new List<Access> {
                                new Access(UserType.Root)
                            },
                            new List<Document> {
                                new Document("09319765960", null, DocumentType.CPF), new Document("5243516", null, DocumentType.RG)
                            });

                        var root2 = User.Seeder("geovani.martinez@datasuricata.br", "$J92R90Li",
                            new General(GenderType.Male, "33333333", "41998623719", "Geovani", "Martinez", new DateTime(1996, 01, 16)),
                            new Address("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040"),
                            new List<Pet> {
                                new Pet("Rosana", null, null, PetSize.Small, PetSpecie.Cat, new DateTime(2014, 05, 11), 2.3f, new Race("Persa")),
                                new Pet("Carlos", null, null, PetSize.Small, PetSpecie.Dog, new DateTime(2013, 05, 11), 4.3f, new Race("Bulldog"))
                            },
                            new List<Wallet> {
                                new Wallet(PaymentType.Credit, "0000", "0000", "07732404971", 15, true)
                            },
                            new List<Access> {
                                new Access(UserType.Root)
                            },
                            new List<Document> {
                                new Document("07732404971", null, DocumentType.CPF), new Document("110890800", null, DocumentType.RG)
                            });

                        context.Users.AddRange(
                    );
                    }

                    await context.SaveChangesAsync();
                }
            } catch (Exception e) {
                var msg = e.Message;
            }
        }
    }
}
