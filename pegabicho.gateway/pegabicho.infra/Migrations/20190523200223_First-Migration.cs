using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pegabicho.infra.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.CreateTable(
                name: "LogApp",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    Event = table.Column<string>(nullable: true),
                    Ticket = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Service = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogApp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogCore",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Ip = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Service = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogCore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogKernel",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Payload = table.Column<string>(nullable: true),
                    Fixed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogKernel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Race",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Specie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Race", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Access",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Stage = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Access_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Building = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Complement = table.Column<int>(nullable: false),
                    AddressLine = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    StateProvince = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ImageUri = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "General",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Activity = table.Column<string>(nullable: true),
                    InscEstadual = table.Column<string>(nullable: true),
                    InscMunicipal = table.Column<string>(nullable: true),
                    Representation = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_General", x => x.Id);
                    table.ForeignKey(
                        name: "FK_General_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    ProviderId = table.Column<string>(nullable: true),
                    DateDue = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_User_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "Core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_User_ProviderId",
                        column: x => x.ProviderId,
                        principalSchema: "Core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ImageUri = table.Column<string>(nullable: true),
                    ImageThumbsUri = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    RaceId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Race_RaceId",
                        column: x => x.RaceId,
                        principalSchema: "Core",
                        principalTable: "Race",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pet_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wallet",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Agency = table.Column<string>(nullable: true),
                    Account = table.Column<string>(nullable: true),
                    Document = table.Column<string>(nullable: true),
                    DateDue = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Core",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Module = table.Column<int>(nullable: false),
                    ProfileId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Role_Access_ProfileId",
                        column: x => x.ProfileId,
                        principalSchema: "Core",
                        principalTable: "Access",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Siege",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AddressId = table.Column<string>(nullable: true),
                    Range = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Altitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siege_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "Core",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Travel",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    OrderId = table.Column<string>(nullable: true),
                    FromLongitude = table.Column<double>(nullable: false),
                    FromLatitude = table.Column<double>(nullable: false),
                    ToLongitude = table.Column<double>(nullable: false),
                    ToLatitude = table.Column<double>(nullable: false),
                    Scheduled = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travel_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Core",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    DateDue = table.Column<DateTimeOffset>(nullable: false),
                    TravelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_Travel_TravelId",
                        column: x => x.TravelId,
                        principalSchema: "Core",
                        principalTable: "Travel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageSurvey",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ImageUri = table.Column<string>(nullable: true),
                    ImageThumbsUri = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    SurveyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSurvey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageSurvey_Survey_SurveyId",
                        column: x => x.SurveyId,
                        principalSchema: "Core",
                        principalTable: "Survey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_UserId",
                schema: "Core",
                table: "Access",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                schema: "Core",
                table: "Address",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserId",
                schema: "Core",
                table: "Document",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_General_UserId",
                schema: "Core",
                table: "General",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSurvey_SurveyId",
                schema: "Core",
                table: "ImageSurvey",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                schema: "Core",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProviderId",
                schema: "Core",
                table: "Order",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_RaceId",
                schema: "Core",
                table: "Pet",
                column: "RaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_UserId",
                schema: "Core",
                table: "Pet",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_ProfileId",
                schema: "Core",
                table: "Role",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Siege_AddressId",
                schema: "Core",
                table: "Siege",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_TravelId",
                schema: "Core",
                table: "Survey",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Travel_OrderId",
                schema: "Core",
                table: "Travel",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Wallet_UserId",
                schema: "Core",
                table: "Wallet",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "General",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "ImageSurvey",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "LogApp",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "LogCore",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "LogKernel",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Pet",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Siege",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Wallet",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Survey",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Race",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Access",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Travel",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Core");
        }
    }
}
