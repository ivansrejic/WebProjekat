﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace WebProjekat.Migrations
{
    [DbContext(typeof(AutobuskaStanicaContext))]
    [Migration("20220312132454_V6")]
    partial class V6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Autobus", b =>
                {
                    b.Property<int>("BusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Destinacija")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NazivPrevoznika")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("datumm")
                        .HasColumnType("datetime2");

                    b.HasKey("BusID");

                    b.ToTable("Autobusi");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.Property<int>("KartaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AutobusBusID")
                        .HasColumnType("int");

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

                    b.HasIndex("AutobusBusID");

                    b.ToTable("Putnici");
                });

            modelBuilder.Entity("Models.Karta", b =>
                {
                    b.HasOne("Models.Autobus", "AutobusFK")
                        .WithMany("ListaKarata")
                        .HasForeignKey("AutobusFKBusID");

                    b.HasOne("Models.Putnik", "PutnikFK")
                        .WithMany("KartaPutnik")
                        .HasForeignKey("PutnikFKputnikID");

                    b.Navigation("AutobusFK");

                    b.Navigation("PutnikFK");
                });

            modelBuilder.Entity("Models.Putnik", b =>
                {
                    b.HasOne("Models.Autobus", null)
                        .WithMany("ListaPutnika")
                        .HasForeignKey("AutobusBusID");
                });

            modelBuilder.Entity("Models.Autobus", b =>
                {
                    b.Navigation("ListaKarata");

                    b.Navigation("ListaPutnika");
                });

            modelBuilder.Entity("Models.Putnik", b =>
                {
                    b.Navigation("KartaPutnik");
                });
#pragma warning restore 612, 618
        }
    }
}
