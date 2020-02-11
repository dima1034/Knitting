﻿﻿﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrderService.DataAccess;

namespace OrderService.DataAccess.Migrations
{
    [DbContext(typeof(OrderDbContext))]
    [Migration("20200201164311_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("order_schema")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OrderService.DataAccess.Entities.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("clothes_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("customer_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("finished_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("will_finished_at")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("worker_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("order","order_schema");
                });
#pragma warning restore 612, 618
        }
    }
}
