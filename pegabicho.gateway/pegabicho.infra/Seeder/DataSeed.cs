﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pegabicho.domain.Entities.Core.Pets;
using pegabicho.domain.Entities.Core.Users;
using pegabicho.infra.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.infra.Seeder {
    public static class DataSeed {
        public static async Task InitializeAsync(IServiceProvider service) {
            using (var context = new AppDbContext(service.GetRequiredService<DbContextOptions<AppDbContext>>())) {
                if (!context.Users.Any()) {

                    var races = new List<Race> {
                        new Race("Affenpinscher", PetSpecie.Dog),
                        new Race("Afghan Hound", PetSpecie.Dog),
                        new Race("Airedale Terrier", PetSpecie.Dog),
                        new Race("Akita", PetSpecie.Dog),
                        new Race("Akita Americano", PetSpecie.Dog),
                        new Race("American Pit Bull Terrier", PetSpecie.Dog),
                        new Race("American Staffordshire Terrier", PetSpecie.Dog),
                        new Race("Australian Shepherd", PetSpecie.Dog),
                        new Race("Basenji", PetSpecie.Dog),
                        new Race("Basset Fulvo da Bretanha", PetSpecie.Dog),
                        new Race("Basset Hound", PetSpecie.Dog),
                        new Race("Beagle", PetSpecie.Dog),
                        new Race("Beagle-Harrier", PetSpecie.Dog),
                        new Race("Bearded Collie", PetSpecie.Dog),
                        new Race("Bedlington Terrier", PetSpecie.Dog),
                        new Race("Bernese Mountain Dog", PetSpecie.Dog),
                        new Race("Bichon Bolonhês", PetSpecie.Dog),
                        new Race("Bichon Frisé", PetSpecie.Dog),
                        new Race("Bichon Havanês", PetSpecie.Dog),
                        new Race("Boerboel", PetSpecie.Dog),
                        new Race("Boiadeiro de Entlebuch", PetSpecie.Dog),
                        new Race("Border Collie", PetSpecie.Dog),
                        new Race("Border Terrier", PetSpecie.Dog),
                        new Race("Borzoi", PetSpecie.Dog),
                        new Race("Boston Terrier", PetSpecie.Dog),
                        new Race("Bouvier de Flandres", PetSpecie.Dog),
                        new Race("Boxer", PetSpecie.Dog),
                        new Race("Braco Alemão Pelo Curto", PetSpecie.Dog),
                        new Race("Braco Alemão Pelo Duro", PetSpecie.Dog),
                        new Race("Braco Italiano", PetSpecie.Dog),
                        new Race("Buldogue Americano", PetSpecie.Dog),
                        new Race("Buldogue Francês", PetSpecie.Dog),
                        new Race("Buldogue Inglês", PetSpecie.Dog),
                        new Race("Bull Terrier", PetSpecie.Dog),
                        new Race("Bullmastiff", PetSpecie.Dog),
                        new Race("Cairn Terrier", PetSpecie.Dog),
                        new Race("Cane Corso", PetSpecie.Dog),
                        new Race("Cão de Crista Chinês", PetSpecie.Dog),
                        new Race("Cão de Santo Humberto", PetSpecie.Dog),
                        new Race("Cão D’água Espanhol", PetSpecie.Dog),
                        new Race("Cão D’água Português", PetSpecie.Dog),
                        new Race("Cão Lobo Checoslovaco", PetSpecie.Dog),
                        new Race("Cão Pelado Mexicano", PetSpecie.Dog),
                        new Race("Cão Pelado Peruano", PetSpecie.Dog),
                        new Race("Cavalier King Charles Spaniel", PetSpecie.Dog),
                        new Race("Cesky Terrier", PetSpecie.Dog),
                        new Race("Chesapeake Bay Retriever", PetSpecie.Dog),
                        new Race("Chihuahua", PetSpecie.Dog),
                        new Race("Chin", PetSpecie.Dog),
                        new Race("Chow-chow Pelo Curto", PetSpecie.Dog),
                        new Race("Chow-chow Pelo Longo", PetSpecie.Dog),
                        new Race("Cirneco do Etna", PetSpecie.Dog),
                        new Race("Clumber Spaniel", PetSpecie.Dog),
                        new Race("Cocker Spaniel Americano", PetSpecie.Dog),
                        new Race("Cocker Spaniel Inglês", PetSpecie.Dog),
                        new Race("Collie pelo longo", PetSpecie.Dog),
                        new Race("Coton de Tulear", PetSpecie.Dog),
                        new Race("Dachshund Teckel - Pelo Curto", PetSpecie.Dog),
                        new Race("Dálmata", PetSpecie.Dog),
                        new Race("Dandie Dinmont Terrier", PetSpecie.Dog),
                        new Race("Dobermann", PetSpecie.Dog),
                        new Race("Dogo Argentino", PetSpecie.Dog),
                        new Race("Dogo Canário", PetSpecie.Dog),
                        new Race("Dogue Alemão", PetSpecie.Dog),
                        new Race("Dogue de Bordeaux", PetSpecie.Dog),
                        new Race("Elkhound Norueguês Cinza", PetSpecie.Dog),
                        new Race("Fila Brasileiro", PetSpecie.Dog),
                        new Race("Flat-Coated Retriever", PetSpecie.Dog),
                        new Race("Fox Terrier Pelo Duro ", PetSpecie.Dog),
                        new Race("Fox Terrier Pelo Liso", PetSpecie.Dog),
                        new Race("Foxhound Inglês", PetSpecie.Dog),
                        new Race("Galgo Espanhol", PetSpecie.Dog),
                        new Race("Golden Retriever", PetSpecie.Dog),
                        new Race("Grande Münsterländer", PetSpecie.Dog),
                        new Race("Greyhound", PetSpecie.Dog),
                        new Race("Griffon Belga", PetSpecie.Dog),
                        new Race("Griffon de Bruxelas", PetSpecie.Dog),
                        new Race("Husky Siberiano", PetSpecie.Dog),
                        new Race("Ibizan Hound", PetSpecie.Dog),
                        new Race("Irish Soft Coated Wheaten Terrier", PetSpecie.Dog),
                        new Race("Irish Wolfhound", PetSpecie.Dog),
                        new Race("Jack Russell Terrier", PetSpecie.Dog),
                        new Race("Kerry Blue Terrier", PetSpecie.Dog),
                        new Race("Komondor", PetSpecie.Dog),
                        new Race("Kuvasz", PetSpecie.Dog),
                        new Race("Labrador Retriever", PetSpecie.Dog),
                        new Race("Lagotto Romagnolo", PetSpecie.Dog),
                        new Race("Lakeland Terrier", PetSpecie.Dog),
                        new Race("Leonberger", PetSpecie.Dog),
                        new Race("Lhasa Apso", PetSpecie.Dog),
                        new Race("Malamute do Alasca", PetSpecie.Dog),
                        new Race("Maltês", PetSpecie.Dog),
                        new Race("Mastiff", PetSpecie.Dog),
                        new Race("Mastim Espanhol", PetSpecie.Dog),
                        new Race("Mastino Napoletano", PetSpecie.Dog),
                        new Race("Mudi", PetSpecie.Dog),
                        new Race("Nordic Spitz", PetSpecie.Dog),
                        new Race("Norfolk Terrier", PetSpecie.Dog),
                        new Race("Norwich Terrier", PetSpecie.Dog),
                        new Race("Old English Sheepdog", PetSpecie.Dog),
                        new Race("Papillon", PetSpecie.Dog),
                        new Race("Parson Russell Terrier", PetSpecie.Dog),
                        new Race("Pastor Alemão", PetSpecie.Dog),
                        new Race("Pastor Beauceron", PetSpecie.Dog),
                        new Race("Pastor Belga", PetSpecie.Dog),
                        new Race("Pastor Bergamasco", PetSpecie.Dog),
                        new Race("Pastor Branco Suíço", PetSpecie.Dog),
                        new Race("Pastor Briard", PetSpecie.Dog),
                        new Race("Pastor da Ásia Central", PetSpecie.Dog),
                        new Race("Pastor de Shetland", PetSpecie.Dog),
                        new Race("Pastor dos Pirineus", PetSpecie.Dog),
                        new Race("Pastor Maremano Abruzês", PetSpecie.Dog),
                        new Race("Pastor Polonês", PetSpecie.Dog),
                        new Race("Pastor Polonês da Planície", PetSpecie.Dog),
                        new Race("Pequeno Basset Griffon da Vendéia", PetSpecie.Dog),
                        new Race("Pequeno Cão Leão", PetSpecie.Dog),
                        new Race("Pequeno Lebrel Italiano", PetSpecie.Dog),
                        new Race("Pequinês", PetSpecie.Dog),
                        new Race("Perdigueiro Português", PetSpecie.Dog),
                        new Race("Petit Brabançon", PetSpecie.Dog),
                        new Race("Pharaoh Hound", PetSpecie.Dog),
                        new Race("Pinscher Miniatura", PetSpecie.Dog),
                        new Race("Podengo Canário", PetSpecie.Dog),
                        new Race("Podengo Português", PetSpecie.Dog),
                        new Race("Pointer Inglês", PetSpecie.Dog),
                        new Race("Poodle Anão", PetSpecie.Dog),
                        new Race("Poodle Médio", PetSpecie.Dog),
                        new Race("Poodle Standard", PetSpecie.Dog),
                        new Race("Poodle Toy", PetSpecie.Dog),
                        new Race("Pug", PetSpecie.Dog),
                        new Race("Puli", PetSpecie.Dog),
                        new Race("Pumi", PetSpecie.Dog),
                        new Race("Rhodesian Ridgeback", PetSpecie.Dog),
                        new Race("Rottweiler", PetSpecie.Dog),
                        new Race("Saluki", PetSpecie.Dog),
                        new Race("Samoieda", PetSpecie.Dog),
                        new Race("São Bernardo", PetSpecie.Dog),
                        new Race("Schipperke", PetSpecie.Dog),
                        new Race("Schnauzer", PetSpecie.Dog),
                        new Race("Schnauzer Gigante", PetSpecie.Dog),
                        new Race("Schnauzer Miniatura", PetSpecie.Dog),
                        new Race("Scottish Terrier", PetSpecie.Dog),
                        new Race("Sealyham Terrier", PetSpecie.Dog),
                        new Race("Setter Gordon", PetSpecie.Dog),
                        new Race("Setter Inglês", PetSpecie.Dog),
                        new Race("Setter Irlandês Vermelho", PetSpecie.Dog),
                        new Race("Setter Irlandês Vermelho e Branco", PetSpecie.Dog),
                        new Race("Shar-pei", PetSpecie.Dog),
                        new Race("Shiba", PetSpecie.Dog),
                        new Race("Shih-Tzu", PetSpecie.Dog),
                        new Race("Silky Terrier Australiano", PetSpecie.Dog),
                        new Race("Skye Terrier", PetSpecie.Dog),
                        new Race("Smoushond Holandês", PetSpecie.Dog),
                        new Race("Spaniel Bretão", PetSpecie.Dog),
                        new Race("Spinone Italiano", PetSpecie.Dog),
                        new Race("Spitz Alemão Anão", PetSpecie.Dog),
                        new Race("Spitz Finlandês", PetSpecie.Dog),
                        new Race("Spitz Japonês Anão", PetSpecie.Dog),
                        new Race("Springer Spaniel Inglês", PetSpecie.Dog),
                        new Race("Stabyhoun", PetSpecie.Dog),
                        new Race("Staffordshire Bull Terrier", PetSpecie.Dog),
                        new Race("Terra Nova", PetSpecie.Dog),
                        new Race("Terrier Alemão de caça Jagd", PetSpecie.Dog),
                        new Race("Terrier Brasileiro", PetSpecie.Dog),
                        new Race("Terrier Irlandês de Glen do Imaal", PetSpecie.Dog),
                        new Race("Terrier Preto da Rússia", PetSpecie.Dog),
                        new Race("Tibetan Terrier", PetSpecie.Dog),
                        new Race("Tosa Inu", PetSpecie.Dog),
                        new Race("Vira-Latas", PetSpecie.Dog),
                        new Race("Vizsla", PetSpecie.Dog),
                        new Race("Volpino Italiano", PetSpecie.Dog),
                        new Race("Weimaraner", PetSpecie.Dog),
                        new Race("Welsh Corgi Cardigan", PetSpecie.Dog),
                        new Race("Welsh Corgi Pembroke", PetSpecie.Dog),
                        new Race("Welsh Springer Spaniel", PetSpecie.Dog),
                        new Race("Welsh Terrier", PetSpecie.Dog),
                        new Race("West Highland White Terrier", PetSpecie.Dog),
                        new Race("Whippet", PetSpecie.Dog),
                        new Race("Yorkshire Terrier", PetSpecie.Dog),
                        new Race("Abyssinian", PetSpecie.Cat),
                        new Race("American Bobtail Longhair", PetSpecie.Cat),
                        new Race("American Bobtail Shorthair", PetSpecie.Cat),
                        new Race("American Shorthair", PetSpecie.Cat),
                        new Race("American Wirehair", PetSpecie.Cat),
                        new Race("Arabian Mau", PetSpecie.Cat),
                        new Race("Asian Semi-long Hair", PetSpecie.Cat),
                        new Race("Australian Mist", PetSpecie.Cat),
                        new Race("Bengal", PetSpecie.Cat),
                        new Race("Bobtail Japonês", PetSpecie.Cat),
                        new Race("Bombaim", PetSpecie.Cat),
                        new Race("Brazilian Shorthair", PetSpecie.Cat),
                        new Race("British Longhair", PetSpecie.Cat),
                        new Race("Burmês", PetSpecie.Cat),
                        new Race("California Spangled Cat", PetSpecie.Cat),
                        new Race("Chausie", PetSpecie.Cat),
                        new Race("Cornish Rex", PetSpecie.Cat),
                        new Race("Curl Americano Pelo Curto", PetSpecie.Cat),
                        new Race("Curl Americano Pelo Longo", PetSpecie.Cat),
                        new Race("Cymric", PetSpecie.Cat),
                        new Race("Devon Rex", PetSpecie.Cat),
                        new Race("Domestic Long-Haired", PetSpecie.Cat),
                        new Race("Domestic Short-Haired", PetSpecie.Cat),
                        new Race("Don Sphynx", PetSpecie.Cat),
                        new Race("Egyptian Mau", PetSpecie.Cat),
                        new Race("European", PetSpecie.Cat),
                        new Race("Exotic Shorthair", PetSpecie.Cat),
                        new Race("German Rex", PetSpecie.Cat),
                        new Race("Havana", PetSpecie.Cat),
                        new Race("Himalaio", PetSpecie.Cat),
                        new Race("Khao Manee", PetSpecie.Cat),
                        new Race("Korat", PetSpecie.Cat),
                        new Race("Kurilian Bobtail Longhair", PetSpecie.Cat),
                        new Race("Kurilian Bobtail Shorthair", PetSpecie.Cat),
                        new Race("LaPerm Longhair", PetSpecie.Cat),
                        new Race("LaPerm Shorthair", PetSpecie.Cat),
                        new Race("Maine Coon", PetSpecie.Cat),
                        new Race("Manx", PetSpecie.Cat),
                        new Race("Mekong Bobtail", PetSpecie.Cat),
                        new Race("Munchkin Longhair", PetSpecie.Cat),
                        new Race("Munchkin Shorthair", PetSpecie.Cat),
                        new Race("Nebelung", PetSpecie.Cat),
                        new Race("Norwegian Forest Cat", PetSpecie.Cat),
                        new Race("Ocicat", PetSpecie.Cat),
                        new Race("Ojos Azules Shorthair", PetSpecie.Cat),
                        new Race("Oriental Longhair", PetSpecie.Cat),
                        new Race("Oriental Shorthair", PetSpecie.Cat),
                        new Race("Persa", PetSpecie.Cat),
                        new Race("Peterbald", PetSpecie.Cat),
                        new Race("Pixiebob Longhair", PetSpecie.Cat),
                        new Race("Pixiebob Shorthair", PetSpecie.Cat),
                        new Race("Ragamuffin", PetSpecie.Cat),
                        new Race("Ragdoll", PetSpecie.Cat),
                        new Race("Russo Azul", PetSpecie.Cat),
                        new Race("Sagrado da Birmânia", PetSpecie.Cat),
                        new Race("Savannah Cat", PetSpecie.Cat),
                        new Race("Scottish Fold", PetSpecie.Cat),
                        new Race("Selkirk Rex Longhair", PetSpecie.Cat),
                        new Race("Selkirk Rex Shorthair", PetSpecie.Cat),
                        new Race("Serengeti", PetSpecie.Cat),
                        new Race("Siamês", PetSpecie.Cat),
                        new Race("Siberian", PetSpecie.Cat),
                        new Race("Singapura", PetSpecie.Cat),
                        new Race("Snowshoe", PetSpecie.Cat),
                        new Race("Sokoke", PetSpecie.Cat),
                        new Race("Somali", PetSpecie.Cat),
                        new Race("Sphynx", PetSpecie.Cat),
                        new Race("Thai", PetSpecie.Cat),
                        new Race("Tonkinese Shorthair", PetSpecie.Cat),
                        new Race("Toyger", PetSpecie.Cat),
                        new Race("Turkish Angorá", PetSpecie.Cat),
                        new Race("Turkish Van", PetSpecie.Cat),
                        new Race("York Chocolate", PetSpecie.Cat),
                    };

                    // # user
                    var root1 = User.Seeder("lucas.moraes@datasuricata.br", "m0raes@123!!",
                        new General(GenderType.Male, "33333333", "41998623719", "Lucas Rocha", "de Moraes", new DateTime(1994, 09, 22)),
                        new Address("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040"),
                        new List<Pet> { new Pet("Morgana", null, PetSize.Small, new DateTime(2015, 09, 22), 2.3f, races[62]) },
                        new List<Wallet> { new Wallet(PaymentType.Credit, "0000", "0000", "50707255058", 15, true) },
                        new List<Access> { new Access(UserType.Root) },
                        new List<Document> { new Document("50707255058", null, DocumentType.CPF), new Document("432579564", null, DocumentType.RG) });

                    var root2 = User.Seeder("geovani.martinez@datasuricata.br", "$J92R90Li",
                        new General(GenderType.Male, "33333333", "41998623719", "Geovani", "Martinez", new DateTime(1996, 01, 16)),
                        new Address("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040"),
                        new List<Pet> { new Pet("Rosana", null, PetSize.Small, new DateTime(2014, 05, 11), 2.3f, races[4]),
                                        new Pet("Carlos", null, PetSize.Small, new DateTime(2013, 05, 11), 4.3f, races[12]) },
                        new List<Wallet> { new Wallet(PaymentType.Credit, "0000", "0000", "03259290095", 15, true) },
                        new List<Access> { new Access(UserType.Root) },
                        new List<Document> { new Document("03259290095", null, DocumentType.CPF), new Document("314621222", null, DocumentType.RG) });

                    var root3 = User.Seeder("leon.suckow@datasuricata.br", "Suck0w123!!",
                        new General(GenderType.Male, "33333333", "41998623719", "Leon", "Suckow", new DateTime(1996, 01, 16)),
                        new Address("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040"),
                        new List<Pet> { new Pet("Rosana", null, PetSize.Small, new DateTime(2014, 05, 11), 2.3f, races[25]) },
                        new List<Wallet> { new Wallet(PaymentType.Credit, "0000", "0000", "91247948056", 15, true) },
                        new List<Access> { new Access(UserType.Root) },
                        new List<Document> { new Document("91247948056", null, DocumentType.CPF), new Document("330067606", null, DocumentType.RG) });

                    var customer1 = User.Register(UserType.Customer, "customer1@datasuricata.br", "Cust0mer123!!");
                    customer1.AddGeneral(GenderType.Male, "33333333", "41998623719", "Customer", "Teste 1", new DateTime(1996, 01, 16));
                    customer1.AddDocument(new List<Document> { new Document("15667743060", null, DocumentType.CPF), new Document("243684484", null, DocumentType.RG) });
                    customer1.AddAddress("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040");
                    customer1.AddPets(new List<Pet> { new Pet("Carlito", null, PetSize.Small, new DateTime(2014, 05, 11), 2.3f, races[25]) });

                    var customer2 = User.Register(UserType.Customer, "customer2@datasuricata.br", "Cust0mer123!!");
                    customer2.AddGeneral(GenderType.Male, "33333333", "41998623719", "Customer", "Teste 2", new DateTime(1996, 01, 16));
                    customer2.AddDocument(new List<Document> { new Document("29656120094", null, DocumentType.CPF), new Document("283765768", null, DocumentType.RG) });
                    customer2.AddAddress("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040");
                    customer2.AddPets(new List<Pet> { new Pet("Mauricio", null, PetSize.Small, new DateTime(2014, 05, 11), 2.3f, races[25]) });

                    var provider1 = User.Register(UserType.Provider, "provider1@datasuricata.br", "Pr0vid3r123!!", new List<ModuleService> { ModuleService.Base, ModuleService.Transport });
                    provider1.AddGeneral(GenderType.Male, "33333333", "41998623719", "Motorista", "Teste 1", new DateTime(1996, 01, 16));
                    provider1.AddDocument(new List<Document> { new Document("29656120094", null, DocumentType.CPF), new Document("283765768", null, DocumentType.RG) });
                    provider1.AddAddress("Rua Roberto Lobo", 4, BuildingType.Townhouse, 266, "Guabirutuba", "Curitiba", "Paraná", "Brasil", "80610040");
                    provider1.AddBussines("Transportador", "000000", "000000", "Provider LTDA.");

                    context.Races.AddRange(races);
                    await context.Users.AddRangeAsync(root1, root2, root3, customer1, customer2, provider1);
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
