// <auto-generated />
using AsyncInnApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInnApp.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20220419010458_AddSeedData")]
    partial class AddSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInnApp.Models.Amenity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "amenity1"
                        },
                        new
                        {
                            id = 2,
                            name = "amenity2"
                        },
                        new
                        {
                            id = 3,
                            name = "amenity3"
                        });
                });

            modelBuilder.Entity("AsyncInnApp.Models.Hotel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phone")
                        .HasColumnType("int");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("streetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            id = 1,
                            city = "Amman",
                            country = "Jordan",
                            name = "AsyncInn1",
                            phone = 123,
                            state = "#",
                            streetAddress = "street a-1"
                        },
                        new
                        {
                            id = 2,
                            city = "Irbid",
                            country = "Jordan",
                            name = "AsyncInn2",
                            phone = 789,
                            state = "#",
                            streetAddress = "street a-2"
                        },
                        new
                        {
                            id = 3,
                            city = "Madaba",
                            country = "Jordan",
                            name = "AsyncInn3",
                            phone = 321,
                            state = "#",
                            streetAddress = "street a-3"
                        });
                });

            modelBuilder.Entity("AsyncInnApp.Models.Room", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("layout")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            id = 1,
                            layout = 1,
                            name = "room1"
                        },
                        new
                        {
                            id = 2,
                            layout = 2,
                            name = "room2"
                        },
                        new
                        {
                            id = 3,
                            layout = 3,
                            name = "room3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
