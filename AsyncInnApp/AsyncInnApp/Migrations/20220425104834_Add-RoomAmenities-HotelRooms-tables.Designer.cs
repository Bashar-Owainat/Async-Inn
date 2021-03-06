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
    [Migration("20220425104834_Add-RoomAmenities-HotelRooms-tables")]
    partial class AddRoomAmenitiesHotelRoomstables
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

            modelBuilder.Entity("AsyncInnApp.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("HotelId", "RoomId");

                    b.HasIndex("RoomId");

                    b.ToTable("HotelRooms");
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

            modelBuilder.Entity("AsyncInnApp.Models.RoomAmenities", b =>
                {
                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("AmenityId")
                        .HasColumnType("int");

                    b.HasKey("RoomId", "AmenityId");

                    b.HasIndex("AmenityId");

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInnApp.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInnApp.Models.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInnApp.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("AsyncInnApp.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInnApp.Models.Amenity", "Amenity")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("AmenityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncInnApp.Models.Room", "Room")
                        .WithMany("RoomAmenities")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Amenity");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("AsyncInnApp.Models.Amenity", b =>
                {
                    b.Navigation("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInnApp.Models.Room", b =>
                {
                    b.Navigation("RoomAmenities");
                });
#pragma warning restore 612, 618
        }
    }
}
