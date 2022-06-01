﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace WebProjekat.Migrations
{
    [DbContext(typeof(AutobuskaStanicaContext))]
    [Migration("20220525122553_VM1")]
    partial class VM1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Autobus", b =>
                {
                    b.Property<int>("BusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusID"), 1L, 1);

                    b.Property<string>("Destinacija")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NazivPrevoznika")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Registracija")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("datumm")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("BusID");

                    b.ToTable("Autobusi");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.Property<int>("KartaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KartaID"), 1L, 1);

                    b.Property<int?>("AutobusFKBusID")
                        .HasColumnType("int");

                    b.Property<int>("BrojSedista")
                        .HasColumnType("int");

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<int?>("PutnikFKputnikID")
                        .HasColumnType("int");

                    b.HasKey("KartaID");

                    b.HasIndex("AutobusFKBusID");

                    b.HasIndex("PutnikFKputnikID");

                    b.ToTable("Karte");
                });

            modelBuilder.Entity("Models.Putnik", b =>
                {
                    b.Property<int>("putnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("putnikID"), 1L, 1);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("putnikID");

                    b.ToTable("Putnici");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.HasOne("Models.Autobus", "AutobusFK")
                        .WithMany("ListaKarata")
                        .HasForeignKey("AutobusFKBusID");

                    b.HasOne("Models.Putnik", "PutnikFK")
                        .WithMany()
                        .HasForeignKey("PutnikFKputnikID");

                    b.Navigation("AutobusFK");

                    b.Navigation("PutnikFK");
                });

            modelBuilder.Entity("Models.Autobus", b =>
                {
                    b.Navigation("ListaKarata");
                });
#pragma warning restore 612, 618
        }
    }
}