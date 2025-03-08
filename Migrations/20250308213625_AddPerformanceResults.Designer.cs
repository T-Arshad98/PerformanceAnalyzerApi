﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PerformanceAnalyzerApi.Data;

#nullable disable

namespace PerformanceAnalyzerApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250308213625_AddPerformanceResults")]
    partial class AddPerformanceResults
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PerformanceAnalyzerApi.Models.PerformanceResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AnalyzedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("LoadTime")
                        .HasColumnType("float");

                    b.Property<int>("ResourceCount")
                        .HasColumnType("int");

                    b.Property<long>("TotalSize")
                        .HasColumnType("bigint");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PerformanceResults");
                });
#pragma warning restore 612, 618
        }
    }
}
