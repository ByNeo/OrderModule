﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ordering.Infrastructure;

namespace Ordering.Infrastructure.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20190601143809_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ordering.Domain.Data.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId")
                        .HasColumnName("ACCOUNT_ID");

                    b.Property<string>("Number")
                        .HasColumnName("NUMBER");

                    b.Property<bool?>("OnHold")
                        .HasColumnName("ON_HOLD");

                    b.Property<int?>("OrderQuantity")
                        .HasColumnName("ORDER_QUANTITY");

                    b.Property<long>("OrderTypeId")
                        .HasColumnName("ORDER_TYPE_ID");

                    b.Property<DateTime?>("PlannedDeliveryTime")
                        .HasColumnName("PLANNED_DELIVERY_TIME")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("PlannedShipmentTime")
                        .HasColumnName("PLANNED_SHIPMENT_TIME")
                        .HasColumnType("datetime");

                    b.Property<int>("RevisionNo")
                        .HasColumnName("REVISION_NO");

                    b.Property<DateTime>("Time")
                        .HasColumnName("TIME")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("OBOP_ORDER");
                });

            modelBuilder.Entity("Ordering.Domain.Data.Entities.OrderDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ItemMasterId")
                        .HasColumnName("ITEM_MASTER_ID");

                    b.Property<string>("LineNumber")
                        .HasColumnName("LINE_NUMBER");

                    b.Property<long>("OrderId")
                        .HasColumnName("ORDER_ID");

                    b.Property<int>("Quantity")
                        .HasColumnName("QUANTITY");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OBOP_ORDER_DETAIL");
                });

            modelBuilder.Entity("Ordering.Domain.Data.Entities.OrderDetail", b =>
                {
                    b.HasOne("Ordering.Domain.Data.Entities.Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}