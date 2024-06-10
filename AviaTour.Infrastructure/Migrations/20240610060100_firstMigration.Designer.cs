﻿// <auto-generated />
using System;
using AviaTour.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AviaTour.Infrastructure.Migrations
{
    [DbContext(typeof(AviaTourDbContext))]
    [Migration("20240610060100_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AviaTour.Domain.Entities.AboutUsModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AboutUs");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AboutUsModelId")
                        .HasColumnType("bigint");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Door")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Latitude")
                        .HasColumnType("bigint");

                    b.Property<long>("Longitude")
                        .HasColumnType("bigint");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("ZipCode")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AboutUsModelId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("DeletedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(240)
                        .HasColumnType("character varying(240)");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("TourId")
                        .HasColumnType("bigint");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.ContactModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AboutUsModelId")
                        .HasColumnType("bigint");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AboutUsModelId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.EmailAddressModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AboutUsModelId")
                        .HasColumnType("bigint");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AboutUsModelId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.Tour", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedAt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("ModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PicturePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Where")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("WhereEx")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("Id");

                    b.ToTable("Tours");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 6, 10, 6, 0, 59, 463, DateTimeKind.Unspecified).AddTicks(5169), new TimeSpan(0, 0, 0, 0, 0)),
                            DeletedAt = "0001-01-01 00:00:00+00:00",
                            Description = "The tour price includes:\r\n\r\nDirect flight Tashkent-Dubai-Tashkent (Fly Dubai flights)\r\n\r\nAccommodation in the selected hotel\r\n\r\nTransfer airport – hotel – airport\r\n\r\nMeals on board\r\n\r\nLuggage included in tour price\r\n\r\nBreakfast\r\n\r\nThe tour price does not include:\r\n\r\nAll COVID-19 tests\\r\n\r\nVISA (80 USD per person)\r\n\r\nMedical insurance\r\n\r\nTourism dirham (tourist tax)",
                            IsDeleted = false,
                            ModifiedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PicturePath = "/TourPhotos/f92cd6e4c9934fde980c7e9c7fbddbf2.jpg",
                            Price = 2000000L,
                            Subtitle = "Dubai is the most populous city in the United Arab Emirates (UAE) and the capital of the Emirate of Dubai, the most populated of the country's seven emirates. Founded in the 1800s as a fishing village, Dubai has emerged as a major center for regional and international trade since the early 20th century and early 21st centuries with a focus on tourism and luxury.",
                            Where = "Luxury Dubai",
                            WhereEx = "Dubai"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTimeOffset(new DateTime(2024, 6, 10, 6, 0, 59, 463, DateTimeKind.Unspecified).AddTicks(5179), new TimeSpan(0, 0, 0, 0, 0)),
                            DeletedAt = "0001-01-01 00:00:00+00:00",
                            Description = "Paradise islands and beautiful beaches\r\n\r\nSophisticated tourists have long realized that the best vacation in Thailand is on the islands. There are many of them here – Koh Samui, Phuket, Koh Chang, Koh Tao… And on each one there are beautiful beaches with snow–white sand and clear water, small picturesque coves, huge coconut palms, beautiful waterfalls, inviting jungles and neat rice fields.\r\n\r\n \r\n\r\nThe holiday season all year round Thailand is remarkable in that you can relax here almost all year round. The holiday season ends in one place of the country, you just need to plan a trip to another part of it. You can always find a region where there are no tropical downpours.\r\n\r\n \r\n\r\nA rich excursion program A variety of sightseeing tours will give a lot of impressions. You will see clear rivers and majestic mountains, pristine jungles and magnificent ancient palaces. You can go by boat on the River Kwai, try your hand at elephant training, learn Thai massage or see the famous transvestite show.\r\n\r\n \r\n\r\nDiverse outdoor activities Lovers of active spending time, as a rule, speak very warmly about their holidays in Thailand. Here you can do almost any kind of sport at your leisure. The most common type of active recreation in this country is diving. Thai resorts promise diving enthusiasts a vivid and varied experience. In addition to diving, golf, windsurfing, fishing, yachting and snorkeling are popular in Thailand.\r\n\r\n \r\n\r\nInteresting places for diving Divers from all over the world go to Thailand for deep-sea dives. The best places for them are the Similan Islands, Phuket, Koh Tao and Pi-Pi. Beautiful underwater landscapes, mysterious grottoes, amazing colored water, unusual soft corals, fish of bizarre colors, giant water turtles – in general, there is something to see.\r\n\r\n \r\n\r\nExotic nature and animals the riot of nature in Thailand is amazing. There is lush vegetation everywhere, a lot of palm trees, magnificent orchids all around. In the national parks of the country, you can not only see elephants and monkeys, but also admire the delightful show of exotic butterflies, tickle your nerves with the spectacle of the dance of poisonous snakes or visit a crocodile farm.\r\n\r\n \r\n\r\nAsian cuisine and tropical fruits you will want to taste local cuisine again and again. Unique seasonings give a special taste to meat, fish, vegetables. And the famous Tom Yam soup is a masterpiece of culinary art. The variety of delicious fruits is also striking. You probably have never heard of some of them, but  many people go to the country to taste them.\r\n\r\n \r\n\r\nHospitable Thais Travelers compose legends about the cordiality and goodwill of local residents. People on the streets sincerely smile and welcome guests like children. They will be happy to help you, tell you how to get through, offer any assistance. This is not surprising – the majority of the population professes Buddhism, and not in words, but in deeds.",
                            IsDeleted = false,
                            ModifiedAt = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            PicturePath = "/TourPhotos/1617289741_35-p-oboi-samui-ostrov-v-tailande-43.jpg",
                            Price = 5000000L,
                            Subtitle = "Tai peoples migrated from southwestern China to mainland Southeast Asia from the 6th to 11th centuries. Indianised kingdoms such as the Mon, Khmer Empire, and Malay states ruled the region, competing with Thai states such as the Kingdoms of Ngoenyang, Sukhothai, Lan Na, and Ayutthaya, which also rivalled each other. European contact began in 1511 with a Portuguese diplomatic mission to Ayutthaya, which became a regional power by the end of the 15th century.",
                            Where = "The paradise islands of Tailand",
                            WhereEx = "Tailand"
                        });
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.Address", b =>
                {
                    b.HasOne("AviaTour.Domain.Entities.AboutUsModel", null)
                        .WithMany("Addresses")
                        .HasForeignKey("AboutUsModelId");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.Comment", b =>
                {
                    b.HasOne("AviaTour.Domain.Entities.Tour", "Tour")
                        .WithMany("Comments")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.ContactModel", b =>
                {
                    b.HasOne("AviaTour.Domain.Entities.AboutUsModel", null)
                        .WithMany("Contacts")
                        .HasForeignKey("AboutUsModelId");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.EmailAddressModel", b =>
                {
                    b.HasOne("AviaTour.Domain.Entities.AboutUsModel", null)
                        .WithMany("Emails")
                        .HasForeignKey("AboutUsModelId");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.AboutUsModel", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Contacts");

                    b.Navigation("Emails");
                });

            modelBuilder.Entity("AviaTour.Domain.Entities.Tour", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}