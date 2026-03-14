using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetAdoptionMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adopters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasOtherPets = table.Column<bool>(type: "bit", nullable: false),
                    HasChildren = table.Column<bool>(type: "bit", nullable: false),
                    HasYard = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adopters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVaccinated = table.Column<bool>(type: "bit", nullable: false),
                    AdoptionFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsAdopted = table.Column<bool>(type: "bit", nullable: false),
                    HasSpecialCareNeeds = table.Column<bool>(type: "bit", nullable: false),
                    HasSpecialDiet = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanFly = table.Column<bool>(type: "bit", nullable: true),
                    IsHandTamed = table.Column<bool>(type: "bit", nullable: true),
                    IsGoodWithOtherBirds = table.Column<bool>(type: "bit", nullable: true),
                    IsGoodWithChildren = table.Column<bool>(type: "bit", nullable: true),
                    IsGoodWithOtherPets = table.Column<bool>(type: "bit", nullable: true),
                    NeedsLargeCage = table.Column<bool>(type: "bit", nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLitterTrained = table.Column<bool>(type: "bit", nullable: true),
                    Cat_IsGoodWithChildren = table.Column<bool>(type: "bit", nullable: true),
                    Cat_IsGoodWithOtherPets = table.Column<bool>(type: "bit", nullable: true),
                    IsIndoorOnly = table.Column<bool>(type: "bit", nullable: true),
                    IsFriendly = table.Column<bool>(type: "bit", nullable: true),
                    Dog_Breed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHouseTrained = table.Column<bool>(type: "bit", nullable: true),
                    Dog_IsGoodWithChildren = table.Column<bool>(type: "bit", nullable: true),
                    Dog_IsGoodWithOtherPets = table.Column<bool>(type: "bit", nullable: true),
                    Dog_IsFriendly = table.Column<bool>(type: "bit", nullable: true),
                    ExoticAnimal_Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimalFamily = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsHandleable = table.Column<bool>(type: "bit", nullable: true),
                    ExoticAnimal_IsGoodWithChildren = table.Column<bool>(type: "bit", nullable: true),
                    IsVenomous = table.Column<bool>(type: "bit", nullable: true),
                    IsAggressive = table.Column<bool>(type: "bit", nullable: true),
                    NeedsSpecialEnclosure = table.Column<bool>(type: "bit", nullable: true),
                    NeedsHeatLamp = table.Column<bool>(type: "bit", nullable: true),
                    NeedsHumidityControl = table.Column<bool>(type: "bit", nullable: true),
                    EatsLiveFood = table.Column<bool>(type: "bit", nullable: true),
                    FarmAnimal_Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FarmAnimal_IsGoodWithChildren = table.Column<bool>(type: "bit", nullable: true),
                    IsGoodWithOtherAnimals = table.Column<bool>(type: "bit", nullable: true),
                    NeedsOutdoorSpace = table.Column<bool>(type: "bit", nullable: true),
                    FarmAnimal_IsHouseTrained = table.Column<bool>(type: "bit", nullable: true),
                    NeedsCompanion = table.Column<bool>(type: "bit", nullable: true),
                    Fish_Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedsSaltwater = table.Column<bool>(type: "bit", nullable: true),
                    TankSizeInLiters = table.Column<double>(type: "float", nullable: true),
                    NeedsHeater = table.Column<bool>(type: "bit", nullable: true),
                    NeedsFilter = table.Column<bool>(type: "bit", nullable: true),
                    Fish_IsAggressive = table.Column<bool>(type: "bit", nullable: true),
                    IsCommunityFriendly = table.Column<bool>(type: "bit", nullable: true),
                    Reptile_Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reptile_IsHandleable = table.Column<bool>(type: "bit", nullable: true),
                    Reptile_IsGoodWithChildren = table.Column<bool>(type: "bit", nullable: true),
                    Reptile_IsGoodWithOtherPets = table.Column<bool>(type: "bit", nullable: true),
                    Reptile_NeedsHeatLamp = table.Column<bool>(type: "bit", nullable: true),
                    NeedsUVBLight = table.Column<bool>(type: "bit", nullable: true),
                    Reptile_NeedsHumidityControl = table.Column<bool>(type: "bit", nullable: true),
                    Reptile_EatsLiveFood = table.Column<bool>(type: "bit", nullable: true),
                    Reptile_IsVenomous = table.Column<bool>(type: "bit", nullable: true),
                    SmallAnimal_Species = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallAnimal_NeedsCompanion = table.Column<bool>(type: "bit", nullable: true),
                    SmallAnimal_IsGoodWithChildren = table.Column<bool>(type: "bit", nullable: true),
                    SmallAnimal_IsGoodWithOtherPets = table.Column<bool>(type: "bit", nullable: true),
                    NeedsLargeEnclosure = table.Column<bool>(type: "bit", nullable: true),
                    SmallAnimal_IsHandleable = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdoptionId = table.Column<int>(type: "int", nullable: true),
                    AdopterId = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastFourDigits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaypalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adoptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    AdopterId = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    AnimalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdoptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdoptionFee = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adoptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adoptions_Adopters_AdopterId",
                        column: x => x.AdopterId,
                        principalTable: "Adopters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdoptionId = table.Column<int>(type: "int", nullable: true),
                    AdopterId = table.Column<int>(type: "int", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAcknowledged = table.Column<bool>(type: "bit", nullable: false),
                    AcknowledgedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcknowledgedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warnings_Adoptions_AdoptionId",
                        column: x => x.AdoptionId,
                        principalTable: "Adoptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adoptions_AdopterId",
                table: "Adoptions",
                column: "AdopterId");

            migrationBuilder.CreateIndex(
                name: "IX_Warnings_AdoptionId",
                table: "Warnings",
                column: "AdoptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Warnings");

            migrationBuilder.DropTable(
                name: "Adoptions");

            migrationBuilder.DropTable(
                name: "Adopters");
        }
    }
}
