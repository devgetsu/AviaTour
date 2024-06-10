using AviaTour.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AviaTour.Infrastructure.Configurations
{
    public class TourConfigurations : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.Property(x => x.Where)
                .HasMaxLength(80);

            builder.Property(x => x.WhereEx)
                .HasMaxLength(80);

            builder.Property(x => x.Subtitle)
                .HasColumnType("text");

            builder.Property(x => x.DeletedAt)
                .HasColumnType("text");


            builder.HasData(new List<Tour>{
                new Tour()
                {
                    Id = 1,
                    Where = "Luxury Dubai",
                    WhereEx = "Dubai",
                    Subtitle = "Dubai is the most populous city in the United Arab Emirates (UAE) and the capital of the " +
                    "Emirate of Dubai, the most populated of the country's seven emirates." +
                    " Founded in the 1800s as a fishing village, Dubai has emerged as a major" +
                    " center for regional and international trade since the early 20th century" +
                    " and early 21st centuries with a focus on tourism and luxury.",
                    Description = "The tour price includes:\r\n\r\nDirect flight Tashkent-Dubai-Tashkent (Fly Dubai flights)\r\n\r\n" +
                    "Accommodation in the selected hotel\r\n\r\nTransfer airport – hotel – airport\r\n\r\nMeals on board\r\n\r\n" +
                    "Luggage included in tour price\r\n\r\nBreakfast\r\n\r\nThe tour price does not include:\r\n\r\nAll COVID-19 tests" +
                    "\\r\n\r\nVISA (80 USD per person)\r\n\r\nMedical insurance\r\n\r\nTourism dirham (tourist tax)",
                    Price = 2000000,
                    CreatedAt = DateTimeOffset.UtcNow,
                    PicturePath = "/TourPhotos/f92cd6e4c9934fde980c7e9c7fbddbf2.jpg"
                },
                 new Tour()
                {
                    Id = 2,
                    Where = "The paradise islands of Tailand",
                    WhereEx = "Tailand",
                    Subtitle = "Tai peoples migrated from southwestern " +
                    "China to mainland Southeast Asia from the 6th to 11th centuries. " +
                    "Indianised kingdoms such as the Mon, Khmer Empire, and Malay states" +
                    " ruled the region, competing with Thai states such as the Kingdoms of" +
                    " Ngoenyang, Sukhothai, Lan Na, and Ayutthaya, which also rivalled each other. " +
                    "European contact began in 1511 with a Portuguese " +
                    "diplomatic mission to Ayutthaya, which became a regional power by the end of the 15th century.",
                    Description = "Paradise islands and beautiful beaches\r\n\r\n" +
                    "Sophisticated tourists have long realized that the best vacation " +
                    "in Thailand is on the islands. There are many of them here – Koh " +
                    "Samui, Phuket, Koh Chang, Koh Tao… And on each one there are beautiful" +
                    " beaches with snow–white sand and clear water, small picturesque coves, huge " +
                    "coconut palms, beautiful waterfalls, inviting jungles and neat rice fields.\r\n\r\n \r\n\r\nThe holiday season all year round Thailand is remarkable in that you can relax here almost all year round. The holiday season ends in one place of the country, you just need to plan a trip to another part of it. You can always find a region where there are no tropical downpours.\r\n\r\n \r\n\r\nA rich excursion program A variet" +
                    "y of sightseeing tours will give a lot of impressions. You will see clear rivers and majestic mountains, pristine jungles and magnificent ancient palaces. You can go by boat on the River Kwai, try your hand at elephant training, learn Thai massage or see the famous tr" +
                    "ansvestite show.\r\n\r\n \r\n\r\nDiverse outdoor activities Lovers of active spending time, as a rule, speak very warmly about their holidays in Thailand. Here you can do almost any kind of sport at your leisure. The most common type of active recreation in this " +
                    "country is diving. Thai resorts promise diving enthusiasts a vivid and varied experience. In addition to diving, golf," +
                    " windsurfing, fishing, yachting and snorkeling are popular in Thailand.\r\n\r\n \r\n\r\nInteresting places for diving Divers from " +
                    "all over the world go to Thailand for deep-sea dives. The best places for them are the Similan Islands, Phuket, Koh Tao and Pi-Pi. Beautiful underwater landscapes, mysterious grottoes, amazing colored water, unusual soft corals, fish of bizarre colors, " +
                    "giant water turtles – in general, there is something to see.\r\n\r\n \r\n\r\nExotic nature and animals the riot of nature in Thailand is amazing. There is lush vegetation everywhere, a lot of palm trees, magnificent orchids all around. In the national parks of the country, you can not only see elephants and monkeys, but also admire the delightful show of exotic butterflies, tickle your nerves with the spectacle of the da" +
                    "nce of poisonous snakes or visit a crocodile farm.\r\n\r\n \r\n\r\nAsian cuisine and tropical fruits you will want to taste local cuisine again and again. Unique seasonings give a special taste to meat, fish, vegetables. And the famous Tom Yam soup is a" +
                    " masterpiece of culinary art. The variety of delicious fruits is also striking. You probably have never heard of some of them, but  many people go to the country to taste them.\r\n\r\n \r\n\r\nHospitable Thais Travelers compose legends about the cordiality and goodwill of" +
                    " local residents. People on the streets sincerely smile and welcome guests like children. They will be happy to help you, tell you how to get through, offer any assistance. This is not surprising – the majority" +
                    " of the population professes Buddhism, and not in words, but in deeds.",
                    Price = 5000000,
                    CreatedAt = DateTimeOffset.UtcNow,
                    PicturePath = "/TourPhotos/1617289741_35-p-oboi-samui-ostrov-v-tailande-43.jpg"
                }
            });

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
