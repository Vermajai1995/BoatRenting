﻿// <auto-generated />
using System;
using BoatProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoatProject.Migrations
{
    [DbContext(typeof(BoatProjectContext))]
    [Migration("20200905101139_BoatProject.Data.BoatProjectNewContext")]
    partial class BoatProjectDataBoatProjectNewContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoatProject.Models.Boat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BoatName")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("HourlyRate");

                    b.Property<string>("RentedByCustomerName");

                    b.Property<bool>("isCurrentlyRented");

                    b.HasKey("Id");

                    b.ToTable("Boat");
                });
#pragma warning restore 612, 618
        }
    }
}