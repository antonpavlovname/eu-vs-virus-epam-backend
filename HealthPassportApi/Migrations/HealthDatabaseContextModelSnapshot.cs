﻿// <auto-generated />

using System;
using ImmunisationPass.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using NetTopologySuite.Geometries;

namespace ImmunisationPass.Migrations
{
    [DbContext(typeof(HealthDatabaseContext))]
    partial class HealthDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HealthPassportApi.DataModels.DiseaseDescription", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symptoms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vaccination")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("DiseaseDescriptions");
                });

            modelBuilder.Entity("HealthPassportApi.DataModels.DiseaseUsefulUrl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DiseaseDescriptionName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseDescriptionName");

                    b.ToTable("UsefulReferences");
                });

            modelBuilder.Entity("HealthPassportApi.DataModels.ImmuntisationStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CertBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CertDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CertExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImmuneType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Tested")
                        .HasColumnType("bit");

                    b.Property<Guid>("Uuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ImmuntisationStatus");
                });

            modelBuilder.Entity("HealthPassportApi.DataModels.InteractionTracking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckInTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CheckInType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CheckoutTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InteractionEntity")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Point>("LatLong")
                        .HasColumnType("geography");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("InteractionTracking");
                });

            modelBuilder.Entity("HealthPassportApi.DataModels.DiseaseUsefulUrl", b =>
                {
                    b.HasOne("HealthPassportApi.DataModels.DiseaseDescription", null)
                        .WithMany("UsefulReferences")
                        .HasForeignKey("DiseaseDescriptionName");
                });
#pragma warning restore 612, 618
        }
    }
}
