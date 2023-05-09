﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UsersWebApiService.DataAccessLayer;

#nullable disable

namespace UsersWebApiService.DataAccessLayer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230509145020_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "group_code", new[] { "admin", "user" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "state_code", new[] { "active", "blocked" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UsersWebApiService.DataLayer.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Created_date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("User_group_id")
                        .HasColumnType("integer");

                    b.Property<int>("User_state_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("User_group_id");

                    b.HasIndex("User_state_id");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("c7607558-68f5-4429-b316-d59bbe78a0bc"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(7859),
                            Login = "Alex",
                            Password = "db74c940d447e877d119df613edd2700c4a84cd1cf08beb7cbc319bcfaeab97a",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("0f39e34d-932f-46da-a18a-5bdf01d1b066"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(7900),
                            Login = "Mary",
                            Password = "aebac53c46bbeff10fdd26ca0e2196a9bfc1d19bf88eb1efd65a36151c581051",
                            User_group_id = 2,
                            User_state_id = 2
                        },
                        new
                        {
                            Id = new Guid("c1f34963-e5d7-47d6-b020-6dd99a27ea5a"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(7924),
                            Login = "John",
                            Password = "a8cfcd74832004951b4408cdb0a5dbcd8c7e52d43f7fe244bf720582e05241da",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("579ab6eb-ee4d-4826-a10a-87c246d3ac22"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(7946),
                            Login = "Jane",
                            Password = "4f23798d92708359b734a18172c9c864f1d48044a754115a0d4b843bca3a5332",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("9bdcdbbc-5eb1-41e8-bc0d-4cf6cd2ee8a2"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(8346),
                            Login = "Jesse",
                            Password = "1ecb9e6bdf6cc8088693c11e366415fe5c73662ecdf08f3df337924d8ea26adc",
                            User_group_id = 2,
                            User_state_id = 2
                        },
                        new
                        {
                            Id = new Guid("dd93ad85-ff05-4bf9-88d8-0c005659645c"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9101),
                            Login = "Kate",
                            Password = "1a5d06a170dde413475957ca2b63396aa5e8fbecb7d379fcb668da3753fca5b6",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("988d00ed-66e7-4436-acbe-d506eb533486"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9213),
                            Login = "Ann",
                            Password = "17239b6e250110330eda64a29c610bf146f89883371fab093feda03bec61b646",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("6c0b000d-1ba5-484a-ab59-7245a989697b"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9240),
                            Login = "Wendy",
                            Password = "966b04e1166554524d9f310d3b0a7759ce74ce202fe04a9a51cd06fdc732d7fe",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("9d82c7c4-88e4-4b8c-a4b6-af354051c805"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9262),
                            Login = "Gwen",
                            Password = "0fded9fb37b9359e8e8ee8554f48acd12d762591738b1748db0e9231a0ff6588",
                            User_group_id = 2,
                            User_state_id = 2
                        },
                        new
                        {
                            Id = new Guid("b0f7176f-8d78-436d-9e17-939f5caadf59"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9290),
                            Login = "Joan",
                            Password = "2d0f4c4eb78ce93adc09b60c696c76d0476185983c956a6f2a5bbf0afb9dbc2e",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("aed5f9f4-4db2-4089-be24-0523422e0bfd"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9312),
                            Login = "Oliver",
                            Password = "7efa869d0364eea0cd0106a2ef4d1ae9eaec58fe62928c3f1af8fa8da9204ea0",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("ec85e537-ba8b-411f-a7bd-b4fdaf3fb3ce"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9471),
                            Login = "Jacob",
                            Password = "8141d2b17b7344d1c058e0cfaa031768e23bab8eb32613d3345655b37876436c",
                            User_group_id = 2,
                            User_state_id = 2
                        },
                        new
                        {
                            Id = new Guid("11258619-a353-4e33-b2cb-b59aecf86dcf"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9563),
                            Login = "Thomas",
                            Password = "5dfcf9ef1fb1ecbce32fefe37ae99aff68832a7e2ac74f52daa5a1bcd8038118",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("1c812204-0548-4d26-b7f9-e0ed2a3634c7"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9598),
                            Login = "George",
                            Password = "3d28271ec52e3d07fe14f5f16d01f2c09cbcac1949f9904b305136d0edbee12d",
                            User_group_id = 2,
                            User_state_id = 1
                        },
                        new
                        {
                            Id = new Guid("fe76b5bc-2e5e-4bea-9a09-a9e6282eadeb"),
                            Created_date = new DateTime(2023, 5, 9, 17, 50, 19, 732, DateTimeKind.Local).AddTicks(9620),
                            Login = "Oscar",
                            Password = "ca66a852a9e96c40f4cce7972d994914909b646b2564e8d25dd4003656b3dd63",
                            User_group_id = 2,
                            User_state_id = 1
                        });
                });

            modelBuilder.Entity("UsersWebApiService.DataLayer.Entities.User_group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("user_groups", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Description = "Администратор"
                        },
                        new
                        {
                            Id = 2,
                            Code = 2,
                            Description = "Пользователь"
                        });
                });

            modelBuilder.Entity("UsersWebApiService.DataLayer.Entities.User_state", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("");

                    b.HasKey("Id");

                    b.ToTable("user_states", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = 1,
                            Description = "Активный"
                        },
                        new
                        {
                            Id = 2,
                            Code = 2,
                            Description = "Заблокированный"
                        });
                });

            modelBuilder.Entity("UsersWebApiService.DataLayer.Entities.User", b =>
                {
                    b.HasOne("UsersWebApiService.DataLayer.Entities.User_group", "User_group")
                        .WithMany("Users")
                        .HasForeignKey("User_group_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UsersWebApiService.DataLayer.Entities.User_state", "User_state")
                        .WithMany("Users")
                        .HasForeignKey("User_state_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User_group");

                    b.Navigation("User_state");
                });

            modelBuilder.Entity("UsersWebApiService.DataLayer.Entities.User_group", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("UsersWebApiService.DataLayer.Entities.User_state", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
