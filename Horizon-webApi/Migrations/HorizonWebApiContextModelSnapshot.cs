﻿// <auto-generated />
using HorizonWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HorizonWebApi.Migrations
{
    [DbContext(typeof(HorizonWebApiContext))]
    partial class HorizonWebApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HorizonWebApi.Models.Bill", b =>
                {
                    b.Property<int>("billId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("customerName");

                    b.Property<float>("total");

                    b.HasKey("billId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("HorizonWebApi.Models.BillItem", b =>
                {
                    b.Property<int>("BillId");

                    b.Property<int>("ItemId");

                    b.HasKey("BillId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("BillItem");
                });

            modelBuilder.Entity("HorizonWebApi.Models.Employee", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("firstName");

                    b.Property<string>("lastName");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("employeeId");

                    b.HasIndex("username")
                        .IsUnique()
                        .HasFilter("[username] IS NOT NULL");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("HorizonWebApi.Models.Item", b =>
                {
                    b.Property<int>("itemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("category");

                    b.Property<string>("name");

                    b.Property<int>("stock");

                    b.Property<float>("unitPrice");

                    b.HasKey("itemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("HorizonWebApi.Models.BillItem", b =>
                {
                    b.HasOne("HorizonWebApi.Models.Bill", "Bill")
                        .WithMany("BillItems")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HorizonWebApi.Models.Item", "Item")
                        .WithMany("BillItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
