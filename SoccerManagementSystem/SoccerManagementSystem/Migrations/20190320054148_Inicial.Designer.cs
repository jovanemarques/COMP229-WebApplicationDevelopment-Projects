﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoccerManagementSystem.Models;

namespace SoccerManagementSystem.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20190320054148_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoccerManagementSystem.Models.Club", b =>
                {
                    b.Property<int>("ClubID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("CresteLinkAddress");

                    b.Property<DateTime>("Foundation");

                    b.Property<string>("Name");

                    b.HasKey("ClubID");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("SoccerManagementSystem.Models.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClubID");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.HasKey("PlayerID");

                    b.HasIndex("ClubID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SoccerManagementSystem.Models.Player", b =>
                {
                    b.HasOne("SoccerManagementSystem.Models.Club")
                        .WithMany("Players")
                        .HasForeignKey("ClubID");
                });
#pragma warning restore 612, 618
        }
    }
}
