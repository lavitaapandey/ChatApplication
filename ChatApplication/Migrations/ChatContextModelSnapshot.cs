﻿// <auto-generated />
using System;
using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChatApplication.Migrations
{
    [DbContext(typeof(ChatContext))]
    partial class ChatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChatApplication.Models.Group", b =>
                {
                    b.Property<int>("groupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("groupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("groupParticipants")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("groupId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("ChatApplication.Models.UserChat", b =>
                {
                    b.Property<long>("Chatid")
                        .HasColumnType("bigint");

                    b.Property<string>("Connectionid")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsGroup")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsMultiple")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Messagedate")
                        .HasColumnType("datetime");

                    b.Property<string>("Messagestatus")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Receiverid")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Senderid")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.HasKey("Chatid");

                    b.HasIndex("Senderid", "Receiverid")
                        .HasName("NonClusteredIndex-20200419-114105");

                    b.ToTable("UserChat");
                });

            modelBuilder.Entity("ChatApplication.Models.UserLogin", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnName("UserID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserPass")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.ToTable("UserLogin");
                });
#pragma warning restore 612, 618
        }
    }
}