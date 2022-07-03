﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Schedulerry.Persistence.AppDbContext;

namespace Schedulerry.Persistence.Migrations
{
    [DbContext(typeof(SchedulerryDbContext))]
    [Migration("20210405101141_service-schedule-timeopen-timezone")]
    partial class servicescheduletimeopentimezone
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.ApplicationRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.ApplicationUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.Organization", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("varchar")
                        .HasMaxLength(400);

                    b.Property<bool>("IsVerified")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsVerified")
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar")
                        .HasMaxLength(200);

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("PhoneNumber")
                        .HasColumnType("varchar")
                        .HasMaxLength(32);

                    b.Property<Guid>("Uid")
                        .HasColumnName("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Organization","dbo");
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.Organizer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("ApplicationUserFk")
                        .HasColumnName("ApplicationUserFk")
                        .HasColumnType("bigint");

                    b.Property<long>("OrganizationFk")
                        .HasColumnName("OrganizationFk")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uid")
                        .HasColumnName("Uid")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VerificationCode")
                        .HasColumnName("VerificationCode")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("VerificationCodeExpiration")
                        .HasColumnName("VerificationCodeExpiration")
                        .HasColumnType("timestamp");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserFk")
                        .IsUnique();

                    b.HasIndex("OrganizationFk");

                    b.ToTable("Organizer","dbo");
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.Service", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("varchar")
                        .HasMaxLength(400);

                    b.Property<string>("ImageUrl")
                        .HasColumnName("ImageUrl")
                        .HasColumnType("varchar")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar")
                        .HasMaxLength(200);

                    b.Property<long>("OrganizationFk")
                        .HasColumnName("OrganizationFk")
                        .HasColumnType("bigint");

                    b.Property<Guid>("Uid")
                        .HasColumnName("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationFk");

                    b.ToTable("Service","dbo");
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.ServiceOption", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnName("Currency")
                        .HasColumnType("varchar")
                        .HasMaxLength(3);

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("varchar")
                        .HasMaxLength(400);

                    b.Property<string>("ImageUrl")
                        .HasColumnName("ImageUrl")
                        .HasColumnType("varchar")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar")
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("decimal");

                    b.Property<long>("ServiceFk")
                        .HasColumnName("ServiceFk")
                        .HasColumnType("bigint");

                    b.Property<short>("ServiceOptionTimeLength")
                        .HasColumnName("ServiceOptionTimeLength")
                        .HasColumnType("smallint");

                    b.Property<Guid>("Uid")
                        .HasColumnName("Uid")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ServiceFk");

                    b.ToTable("ServiceOption","dbo");
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.ServiceOptionSchedule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<short>("DayOfWeek")
                        .HasColumnName("DayOfWeek")
                        .HasColumnType("smallint");

                    b.Property<long>("ServiceOptionFk")
                        .HasColumnName("ServiceOptionFk")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("TimeOpen")
                        .HasColumnName("TimeOpen")
                        .HasColumnType("timestamptz");

                    b.Property<Guid>("Uid")
                        .HasColumnName("Uid")
                        .HasColumnType("uuid");

                    b.Property<int>("WorkingTimeMinutes")
                        .HasColumnName("WorkingTimeMinutes")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ServiceOptionFk");

                    b.ToTable("ServiceOptionSchedule","dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedulerry.Persistence.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.Organizer", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.ApplicationUser", "ApplicationUser")
                        .WithOne("Organizer")
                        .HasForeignKey("Schedulerry.Persistence.Entities.Organizer", "ApplicationUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Schedulerry.Persistence.Entities.Organization", "Organization")
                        .WithMany("Organizers")
                        .HasForeignKey("OrganizationFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.Service", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.Organization", "Organization")
                        .WithMany("Services")
                        .HasForeignKey("OrganizationFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.ServiceOption", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.Service", "Service")
                        .WithMany("ServiceOptions")
                        .HasForeignKey("ServiceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Schedulerry.Persistence.Entities.ServiceOptionSchedule", b =>
                {
                    b.HasOne("Schedulerry.Persistence.Entities.ServiceOption", "ServiceOption")
                        .WithMany("ServiceOptionSchedules")
                        .HasForeignKey("ServiceOptionFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
