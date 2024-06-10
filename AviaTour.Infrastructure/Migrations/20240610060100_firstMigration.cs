using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AviaTour.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WhereEx = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Where = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Subtitle = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PicturePath = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Door = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<long>(type: "bigint", nullable: false),
                    Longitude = table.Column<long>(type: "bigint", nullable: false),
                    Latitude = table.Column<long>(type: "bigint", nullable: false),
                    AboutUsModelId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AboutUs_AboutUsModelId",
                        column: x => x.AboutUsModelId,
                        principalTable: "AboutUs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    AboutUsModelId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_AboutUs_AboutUsModelId",
                        column: x => x.AboutUsModelId,
                        principalTable: "AboutUs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    AboutUsModelId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_AboutUs_AboutUsModelId",
                        column: x => x.AboutUsModelId,
                        principalTable: "AboutUs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "character varying(240)", maxLength: 240, nullable: false),
                    TourId = table.Column<long>(type: "bigint", nullable: false),
                    isDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tours",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "IsDeleted", "ModifiedAt", "PicturePath", "Price", "Subtitle", "Where", "WhereEx" },
                values: new object[,]
                {
                    { 1L, new DateTimeOffset(new DateTime(2024, 6, 10, 6, 0, 59, 463, DateTimeKind.Unspecified).AddTicks(5169), new TimeSpan(0, 0, 0, 0, 0)), "0001-01-01 00:00:00+00:00", "The tour price includes:\r\n\r\nDirect flight Tashkent-Dubai-Tashkent (Fly Dubai flights)\r\n\r\nAccommodation in the selected hotel\r\n\r\nTransfer airport – hotel – airport\r\n\r\nMeals on board\r\n\r\nLuggage included in tour price\r\n\r\nBreakfast\r\n\r\nThe tour price does not include:\r\n\r\nAll COVID-19 tests\\r\n\r\nVISA (80 USD per person)\r\n\r\nMedical insurance\r\n\r\nTourism dirham (tourist tax)", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/TourPhotos/f92cd6e4c9934fde980c7e9c7fbddbf2.jpg", 2000000L, "Dubai is the most populous city in the United Arab Emirates (UAE) and the capital of the Emirate of Dubai, the most populated of the country's seven emirates. Founded in the 1800s as a fishing village, Dubai has emerged as a major center for regional and international trade since the early 20th century and early 21st centuries with a focus on tourism and luxury.", "Luxury Dubai", "Dubai" },
                    { 2L, new DateTimeOffset(new DateTime(2024, 6, 10, 6, 0, 59, 463, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 0, 0, 0, 0)), "0001-01-01 00:00:00+00:00", "Paradise islands and beautiful beaches\r\n\r\nSophisticated tourists have long realized that the best vacation in Thailand is on the islands. There are many of them here – Koh Samui, Phuket, Koh Chang, Koh Tao… And on each one there are beautiful beaches with snow–white sand and clear water, small picturesque coves, huge coconut palms, beautiful waterfalls, inviting jungles and neat rice fields.\r\n\r\n \r\n\r\nThe holiday season all year round Thailand is remarkable in that you can relax here almost all year round. The holiday season ends in one place of the country, you just need to plan a trip to another part of it. You can always find a region where there are no tropical downpours.\r\n\r\n \r\n\r\nA rich excursion program A variety of sightseeing tours will give a lot of impressions. You will see clear rivers and majestic mountains, pristine jungles and magnificent ancient palaces. You can go by boat on the River Kwai, try your hand at elephant training, learn Thai massage or see the famous transvestite show.\r\n\r\n \r\n\r\nDiverse outdoor activities Lovers of active spending time, as a rule, speak very warmly about their holidays in Thailand. Here you can do almost any kind of sport at your leisure. The most common type of active recreation in this country is diving. Thai resorts promise diving enthusiasts a vivid and varied experience. In addition to diving, golf, windsurfing, fishing, yachting and snorkeling are popular in Thailand.\r\n\r\n \r\n\r\nInteresting places for diving Divers from all over the world go to Thailand for deep-sea dives. The best places for them are the Similan Islands, Phuket, Koh Tao and Pi-Pi. Beautiful underwater landscapes, mysterious grottoes, amazing colored water, unusual soft corals, fish of bizarre colors, giant water turtles – in general, there is something to see.\r\n\r\n \r\n\r\nExotic nature and animals the riot of nature in Thailand is amazing. There is lush vegetation everywhere, a lot of palm trees, magnificent orchids all around. In the national parks of the country, you can not only see elephants and monkeys, but also admire the delightful show of exotic butterflies, tickle your nerves with the spectacle of the dance of poisonous snakes or visit a crocodile farm.\r\n\r\n \r\n\r\nAsian cuisine and tropical fruits you will want to taste local cuisine again and again. Unique seasonings give a special taste to meat, fish, vegetables. And the famous Tom Yam soup is a masterpiece of culinary art. The variety of delicious fruits is also striking. You probably have never heard of some of them, but  many people go to the country to taste them.\r\n\r\n \r\n\r\nHospitable Thais Travelers compose legends about the cordiality and goodwill of local residents. People on the streets sincerely smile and welcome guests like children. They will be happy to help you, tell you how to get through, offer any assistance. This is not surprising – the majority of the population professes Buddhism, and not in words, but in deeds.", false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "/TourPhotos/1617289741_35-p-oboi-samui-ostrov-v-tailande-43.jpg", 5000000L, "Tai peoples migrated from southwestern China to mainland Southeast Asia from the 6th to 11th centuries. Indianised kingdoms such as the Mon, Khmer Empire, and Malay states ruled the region, competing with Thai states such as the Kingdoms of Ngoenyang, Sukhothai, Lan Na, and Ayutthaya, which also rivalled each other. European contact began in 1511 with a Portuguese diplomatic mission to Ayutthaya, which became a regional power by the end of the 15th century.", "The paradise islands of Tailand", "Tailand" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AboutUsModelId",
                table: "Address",
                column: "AboutUsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TourId",
                table: "Comments",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AboutUsModelId",
                table: "Contacts",
                column: "AboutUsModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_AboutUsModelId",
                table: "Emails",
                column: "AboutUsModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "AboutUs");
        }
    }
}
