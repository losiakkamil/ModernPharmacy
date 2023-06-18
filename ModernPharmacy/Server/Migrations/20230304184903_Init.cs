using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModernPharmacy.Server.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    PagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifferentProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifferentProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfTablets = table.Column<int>(type: "int", nullable: true),
                    MilligramsPerTablets = table.Column<int>(type: "int", nullable: true),
                    MilligramsForTheWholeDrug = table.Column<int>(type: "int", nullable: true),
                    LumpSumDrug = table.Column<bool>(type: "bit", nullable: false),
                    PrescriptionRequired = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPrescriptionDrugs = table.Column<bool>(type: "bit", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubstanceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstanceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Substances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Substances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DifferentProductId = table.Column<int>(type: "int", nullable: true),
                    DrugId = table.Column<int>(type: "int", nullable: true),
                    ProposedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShippingOption = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_DifferentProducts_DifferentProductId",
                        column: x => x.DifferentProductId,
                        principalTable: "DifferentProducts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PharmacyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugSubstance",
                columns: table => new
                {
                    DrugsId = table.Column<int>(type: "int", nullable: false),
                    SubstancesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugSubstance", x => new { x.DrugsId, x.SubstancesId });
                    table.ForeignKey(
                        name: "FK_DrugSubstance_Drugs_DrugsId",
                        column: x => x.DrugsId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugSubstance_Substances_SubstancesId",
                        column: x => x.SubstancesId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugSubstances",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    SubstanceId = table.Column<int>(type: "int", nullable: false),
                    DrugSubstanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugSubstances", x => new { x.SubstanceId, x.DrugId });
                    table.ForeignKey(
                        name: "FK_DrugSubstances_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugSubstances_Substances_SubstanceId",
                        column: x => x.SubstanceId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubstanceSubstanceCategories",
                columns: table => new
                {
                    SubstanceId = table.Column<int>(type: "int", nullable: false),
                    SubstanceCategoryId = table.Column<int>(type: "int", nullable: false),
                    SubstanceSubstanceCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstanceSubstanceCategories", x => new { x.SubstanceId, x.SubstanceCategoryId });
                    table.ForeignKey(
                        name: "FK_SubstanceSubstanceCategories_SubstanceCategories_SubstanceCategoryId",
                        column: x => x.SubstanceCategoryId,
                        principalTable: "SubstanceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubstanceSubstanceCategories_Substances_SubstanceId",
                        column: x => x.SubstanceId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubstanceSubstanceCategory",
                columns: table => new
                {
                    SubstanceCategoriesId = table.Column<int>(type: "int", nullable: false),
                    SubstancesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubstanceSubstanceCategory", x => new { x.SubstanceCategoriesId, x.SubstancesId });
                    table.ForeignKey(
                        name: "FK_SubstanceSubstanceCategory_SubstanceCategories_SubstanceCategoriesId",
                        column: x => x.SubstanceCategoriesId,
                        principalTable: "SubstanceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubstanceSubstanceCategory_Substances_SubstancesId",
                        column: x => x.SubstancesId,
                        principalTable: "Substances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ArticleTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ArticleTags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmacyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AmountOfProducts = table.Column<int>(type: "int", nullable: false),
                    PriceForOne = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HowMuchHasBeenSold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStates_Pharmacies_PharmacyId",
                        column: x => x.PharmacyId,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStates_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "ImagePath", "ModifiedById", "ModifiedDate", "PagePath", "ParentId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), "articleImages/antibiotics.jpg", null, null, "Antibiotics", 0, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Antibiotics" },
                    { 2, 1, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), "articleImages/nootropics.jpg", null, null, "Nootropics", 0, "<b>Lorem Ipsum is simply dummy text</b> of the printing<strong> and typesetting </strong> industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Nootropics" },
                    { 3, 1, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), "articleImages/painkillers.jpg", null, null, "Painkillers", 0, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Painkillers" },
                    { 4, 1, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), "articleImages/antiepileptic.jpg", null, null, "Antiepileptic", 0, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Antiepileptic" },
                    { 5, 1, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), "articleImages/sleep.jpg", null, null, "SleepHigiene", 0, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "SleepHigiene" },
                    { 6, 1, new DateTime(2023, 3, 4, 0, 0, 0, 0, DateTimeKind.Local), "articleImages/vitamins.jpg", null, null, "Vitamins", 0, "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Vitamins" }
                });

            migrationBuilder.InsertData(
                table: "DifferentProducts",
                columns: new[] { "Id", "Description", "Name", "ProductId" },
                values: new object[,]
                {
                    { 1, "Needle Description", "needle", 0 },
                    { 2, "Bandages Description", "bandages", 0 },
                    { 3, "Atomizer Description", "atomizer", 0 },
                    { 4, "Hydrogen Dioxide Description", "hydrogen dioxide", 0 },
                    { 5, "Bacteriostatic Water Description", "bacteriostatic water", 0 },
                    { 6, "Urine Cup Description", "urine cup", 0 }
                });

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "Description", "LumpSumDrug", "MilligramsForTheWholeDrug", "MilligramsPerTablets", "Name", "NumberOfTablets", "PrescriptionRequired", "ProductId" },
                values: new object[,]
                {
                    { 1, "Description Apap", false, null, 500, "Apap", 10, false, 0 },
                    { 2, "Description Apap", false, null, 500, "Apap", 5, false, 0 },
                    { 3, "Description Apap", false, null, 500, "Apap", 20, false, 0 },
                    { 4, "Description Tylenol", false, null, 500, "Tylenol", 100, false, 0 },
                    { 5, "Description Nurofen", false, null, 200, "Nurofen", 20, false, 0 },
                    { 6, "Description Ibuprom", false, null, 200, "Ibuprom", 10, false, 0 },
                    { 7, "Description Tramal Retard", true, null, 100, "Tramal retard", 50, true, 0 },
                    { 8, "Description Valeriana", false, null, 2500, "Valeriana", 60, false, 0 },
                    { 9, "Description Morfeo", false, null, 10, "Morfeo", 10, false, 0 },
                    { 10, "Description Sonata", false, null, 10, "Sonata", 10, false, 0 },
                    { 11, "Description Aviomarin", false, null, 500, "Aviomarin", 5, false, 0 },
                    { 12, "Description Zirtec", true, null, 10, "Zirtec", 20, true, 0 }
                });

            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "Id", "AddressId", "ContactEmail", "ContactNumber", "HasPrescriptionDrugs", "Name" },
                values: new object[,]
                {
                    { 1, 0, "slowik@apteka.pl", "723171222", true, "Slownik" },
                    { 2, 0, "drugaapteka@apteka.pl", "594034033", true, "DrugaApteka" },
                    { 3, 0, "szczecinska@apteka.pl", "660650444", false, "Szczecinska" },
                    { 4, 0, "gryficka@wp.pl", "594033222", false, "Gryficka" },
                    { 5, 0, "kamil-losiak@wp.pl", "730660434", true, "ModernPharmacy" }
                });

            migrationBuilder.InsertData(
                table: "SubstanceCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description Painkiller", "Painkiller" },
                    { 2, "Description Sleeping pills", "Sleeping pills" },
                    { 3, "Description Antihistamines", "Antihistamines" },
                    { 4, "Description Antipsychotic", "Antypsychotic" }
                });

            migrationBuilder.InsertData(
                table: "Substances",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description Paracetamol", "Paracetamol" },
                    { 2, "Description Ibuprofen", "Ibuprofen" },
                    { 3, "Description Tramadol", "Tramadol" },
                    { 4, "Description Valeriana", "Valeriana" },
                    { 5, "Description Zaleplon", "Zaleplon" },
                    { 6, "Description Eszopiclone", "Eszopiclone" },
                    { 7, "Description Cetirizine", "Cetirizine" },
                    { 8, "Description Clemastine", "Clemastine" },
                    { 9, "Description Dimenhydrinate", "Dimenhydrinate" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "drug" },
                    { 2, "sleep" },
                    { 3, "bacteria" },
                    { 4, "suplements" },
                    { 5, "hygiene" },
                    { 6, "children" },
                    { 7, "pain" },
                    { 8, "insonomia" },
                    { 9, "brain" },
                    { 10, "heart" },
                    { 11, "diabetes" },
                    { 12, "bow" },
                    { 13, "anxiety" },
                    { 14, "fatigue" },
                    { 15, "depression" },
                    { 16, "health" },
                    { 17, "cold" },
                    { 18, "flu" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "PharmacyId", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 1, "Międzylesie", 1, "57530", "Graniczna 7" },
                    { 2, "Wrocław", 2, "21599", "Wolności 22c" },
                    { 3, "Szczecin", 3, "35300", "Słowiańska 3" },
                    { 4, "Gryfice", 4, "64554", "Poniatowska 4" },
                    { 5, "Gryfice", 5, "72-300", "Grunwaldzka 3" }
                });

            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId", "ArticleTagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 3, 2 },
                    { 1, 16, 3 },
                    { 1, 18, 4 },
                    { 2, 1, 5 },
                    { 2, 4, 6 },
                    { 2, 9, 7 },
                    { 3, 1, 8 },
                    { 3, 7, 9 },
                    { 3, 18, 10 },
                    { 5, 1, 11 },
                    { 5, 2, 12 },
                    { 5, 8, 13 },
                    { 6, 4, 14 },
                    { 6, 16, 15 }
                });

            migrationBuilder.InsertData(
                table: "DrugSubstances",
                columns: new[] { "DrugId", "SubstanceId", "DrugSubstanceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 2, 4 },
                    { 5, 2, 5 },
                    { 6, 2, 6 },
                    { 7, 3, 7 },
                    { 8, 4, 8 },
                    { 9, 5, 9 },
                    { 10, 5, 10 },
                    { 11, 7, 12 },
                    { 12, 9, 11 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DifferentProductId", "DrugId", "ProposedPrice", "ShippingOption" },
                values: new object[,]
                {
                    { 1, null, 1, 17.99m, false },
                    { 2, null, 2, 15.20m, false },
                    { 3, null, 3, 12.59m, false },
                    { 4, null, 4, 10.99m, false },
                    { 5, null, 5, 2.39m, false },
                    { 6, null, 6, 10.99m, false },
                    { 7, null, 7, 20.29m, false },
                    { 8, null, 8, 34.99m, false },
                    { 9, null, 9, 23.99m, false },
                    { 10, null, 10, 7.99m, false }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DifferentProductId", "DrugId", "ProposedPrice", "ShippingOption" },
                values: new object[,]
                {
                    { 11, null, 11, 41.99m, false },
                    { 12, null, 12, 37.99m, false },
                    { 13, 1, null, 23.99m, false },
                    { 14, 2, null, 54.99m, false },
                    { 15, 3, null, 23.99m, false },
                    { 16, 4, null, 13.99m, false },
                    { 17, 5, null, 11.99m, false },
                    { 18, 6, null, 4.99m, false }
                });

            migrationBuilder.InsertData(
                table: "SubstanceSubstanceCategories",
                columns: new[] { "SubstanceCategoryId", "SubstanceId", "SubstanceSubstanceCategoryId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 1, 3, 3 },
                    { 2, 4, 4 },
                    { 4, 4, 12 },
                    { 2, 5, 5 },
                    { 2, 6, 6 },
                    { 4, 6, 11 },
                    { 3, 7, 7 },
                    { 4, 7, 10 },
                    { 3, 8, 8 },
                    { 3, 9, 9 }
                });

            migrationBuilder.InsertData(
                table: "ProductStates",
                columns: new[] { "Id", "AmountOfProducts", "HowMuchHasBeenSold", "PharmacyId", "PriceForOne", "ProductId" },
                values: new object[,]
                {
                    { 1, 12, 0, 1, 20.99m, 1 },
                    { 2, 32, 0, 1, 17.99m, 2 },
                    { 3, 23, 0, 1, 15.99m, 3 },
                    { 4, 66, 0, 1, 12.99m, 4 },
                    { 5, 11, 0, 1, 3.99m, 5 },
                    { 6, 3, 0, 1, 12.99m, 6 },
                    { 7, 3, 0, 1, 22.99m, 7 },
                    { 8, 55, 0, 1, 35.99m, 8 },
                    { 9, 33, 0, 1, 27.99m, 9 },
                    { 10, 21, 0, 1, 9.99m, 10 },
                    { 11, 11, 0, 1, 44.99m, 11 },
                    { 12, 32, 0, 1, 40.99m, 12 },
                    { 13, 12, 0, 1, 25.99m, 13 },
                    { 14, 34, 0, 1, 55.99m, 14 },
                    { 15, 11, 0, 1, 26.99m, 15 },
                    { 16, 3, 0, 1, 16.99m, 16 },
                    { 17, 4, 0, 1, 13.99m, 17 },
                    { 18, 5, 0, 1, 6.99m, 18 },
                    { 19, 24, 0, 2, 21.99m, 1 },
                    { 20, 22, 0, 2, 18.99m, 2 },
                    { 21, 23, 0, 2, 16.99m, 3 },
                    { 22, 53, 0, 2, 4.99m, 5 },
                    { 23, 22, 0, 2, 13.99m, 6 },
                    { 24, 4, 0, 2, 23.99m, 7 },
                    { 25, 4, 0, 2, 36.99m, 8 },
                    { 26, 33, 0, 2, 10.99m, 10 },
                    { 27, 0, 0, 2, 45.99m, 11 },
                    { 28, 12, 0, 2, 41.99m, 12 },
                    { 29, 22, 0, 2, 56.99m, 14 },
                    { 30, 53, 0, 2, 27.99m, 15 },
                    { 31, 2, 0, 2, 17.99m, 16 },
                    { 32, 2, 0, 2, 14.99m, 17 },
                    { 33, 7, 0, 2, 7.99m, 18 },
                    { 34, 8, 0, 3, 22.99m, 1 },
                    { 35, 5, 0, 3, 18.99m, 2 },
                    { 36, 4, 0, 3, 14.99m, 4 },
                    { 37, 4, 0, 3, 5.99m, 5 },
                    { 38, 7, 0, 3, 13.99m, 6 },
                    { 39, 34, 0, 3, 23.99m, 7 },
                    { 40, 64, 0, 3, 37.99m, 8 },
                    { 41, 33, 0, 3, 28.99m, 9 },
                    { 42, 5, 0, 3, 12.99m, 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductStates",
                columns: new[] { "Id", "AmountOfProducts", "HowMuchHasBeenSold", "PharmacyId", "PriceForOne", "ProductId" },
                values: new object[,]
                {
                    { 43, 1, 0, 3, 48.99m, 11 },
                    { 44, 34, 0, 3, 44.99m, 12 },
                    { 45, 54, 0, 3, 27.99m, 13 },
                    { 46, 0, 0, 3, 59.99m, 14 },
                    { 47, 0, 0, 3, 28.99m, 15 },
                    { 48, 0, 0, 3, 19.99m, 16 },
                    { 49, 7, 0, 3, 15.99m, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PharmacyId",
                table: "Addresses",
                column: "PharmacyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugSubstance_SubstancesId",
                table: "DrugSubstance",
                column: "SubstancesId");

            migrationBuilder.CreateIndex(
                name: "IX_DrugSubstances_DrugId",
                table: "DrugSubstances",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DifferentProductId",
                table: "Products",
                column: "DifferentProductId",
                unique: true,
                filter: "[DifferentProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DrugId",
                table: "Products",
                column: "DrugId",
                unique: true,
                filter: "[DrugId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStates_PharmacyId",
                table: "ProductStates",
                column: "PharmacyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStates_ProductId",
                table: "ProductStates",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubstanceSubstanceCategories_SubstanceCategoryId",
                table: "SubstanceSubstanceCategories",
                column: "SubstanceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubstanceSubstanceCategory_SubstancesId",
                table: "SubstanceSubstanceCategory",
                column: "SubstancesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.DropTable(
                name: "DrugSubstance");

            migrationBuilder.DropTable(
                name: "DrugSubstances");

            migrationBuilder.DropTable(
                name: "ProductStates");

            migrationBuilder.DropTable(
                name: "SubstanceSubstanceCategories");

            migrationBuilder.DropTable(
                name: "SubstanceSubstanceCategory");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SubstanceCategories");

            migrationBuilder.DropTable(
                name: "Substances");

            migrationBuilder.DropTable(
                name: "DifferentProducts");

            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}
