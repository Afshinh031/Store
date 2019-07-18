﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopLearn.DataLayer.Context;

namespace TopLearn.DataLayer.Migrations
{
    [DbContext(typeof(TopLearnContext))]
    partial class TopLearnContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.Permissions", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName");

                    b.Property<string>("ControllerName");

                    b.Property<int?>("ParentID");

                    b.Property<string>("PermissionTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.RolePermissions", b =>
                {
                    b.Property<int>("RP_Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId");

                    b.Property<int>("RoleId");

                    b.HasKey("RP_Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Stores.Province", b =>
                {
                    b.Property<int>("ProvinceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("ProvinceID");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Stores.Store", b =>
                {
                    b.Property<int>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProvinceID");

                    b.Property<string>("StoreAbout")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<string>("StoreAddress")
                        .IsRequired()
                        .HasMaxLength(400);

                    b.Property<DateTime>("StoreDateTime");

                    b.Property<DateTime>("StoreEditeDateTime");

                    b.Property<string>("StoreImage")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("StoreIsActive");

                    b.Property<string>("StoreLogo")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int>("StoreTypeID");

                    b.Property<int>("UserEditorID");

                    b.Property<bool>("isDelete");

                    b.HasKey("StoreID");

                    b.HasIndex("ProvinceID");

                    b.HasIndex("StoreTypeID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Stores.StoreType", b =>
                {
                    b.Property<int>("StoreTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("StoreTypeDateTime");

                    b.Property<DateTime?>("StoreTypeEditeDateTime");

                    b.Property<string>("StoreTypeTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("UserEditorID");

                    b.Property<int>("UserID");

                    b.Property<bool>("isDelete");

                    b.HasKey("StoreTypeID");

                    b.ToTable("StoreTypes");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("RoleActive");

                    b.Property<DateTime>("RoleDateTime");

                    b.Property<DateTime?>("RoleEditeDateTime");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("UserEditorID");

                    b.Property<int>("UserID");

                    b.Property<bool>("isDelete");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserAbout")
                        .HasMaxLength(500);

                    b.Property<string>("UserBirthday")
                        .HasMaxLength(11);

                    b.Property<DateTime>("UserDateTime");

                    b.Property<string>("UserDescription")
                        .HasMaxLength(250);

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("UserEmailConfigurationCode");

                    b.Property<DateTime>("UserEmailConfigurationDateTime");

                    b.Property<string>("UserFristName")
                        .HasMaxLength(200);

                    b.Property<string>("UserImage");

                    b.Property<bool>("UserIsActive");

                    b.Property<string>("UserLastName")
                        .HasMaxLength(300);

                    b.Property<DateTime>("UserLastUpdateDateTime");

                    b.Property<string>("UserName")
                        .HasMaxLength(200);

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("isDelete");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.UserRole", b =>
                {
                    b.Property<int>("URID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleID");

                    b.Property<int>("UserID");

                    b.Property<int?>("UserRegisterID");

                    b.Property<DateTime>("UserRoleDateTime");

                    b.HasKey("URID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.Permissions", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Permissions.Permissions")
                        .WithMany("Permission")
                        .HasForeignKey("ParentID");
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Permissions.RolePermissions", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Permissions.Permissions", "Permission")
                        .WithMany("RolePermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TopLearn.DataLayer.Entities.User.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.Stores.Store", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.Stores.Province", "Province")
                        .WithMany("Stores")
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TopLearn.DataLayer.Entities.Stores.StoreType", "StoreType")
                        .WithMany("Stores")
                        .HasForeignKey("StoreTypeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TopLearn.DataLayer.Entities.User.UserRole", b =>
                {
                    b.HasOne("TopLearn.DataLayer.Entities.User.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TopLearn.DataLayer.Entities.User.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
