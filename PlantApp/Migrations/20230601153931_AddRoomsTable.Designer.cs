﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PlantApp;

#nullable disable

namespace PlantApp.Migrations
{
    [DbContext(typeof(PlantTrackerContext))]
    [Migration("20230601153931_AddRoomsTable")]
    partial class AddRoomsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PlantApp.Plant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("purchase_date");

                    b.Property<int>("RoomId")
                        .HasColumnType("integer")
                        .HasColumnName("room_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_plants");

                    b.HasIndex("RoomId")
                        .HasDatabaseName("ix_plants_room_id");

                    b.ToTable("plants", (string)null);
                });

            modelBuilder.Entity("PlantApp.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("HasSunlight")
                        .HasColumnType("boolean")
                        .HasColumnName("has_sunlight");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_rooms");

                    b.ToTable("rooms", (string)null);
                });

            modelBuilder.Entity("PlantApp.Plant", b =>
                {
                    b.HasOne("PlantApp.Room", "Room")
                        .WithMany("Plants")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_plants_rooms_room_id");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("PlantApp.Room", b =>
                {
                    b.Navigation("Plants");
                });
#pragma warning restore 612, 618
        }
    }
}
