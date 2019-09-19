﻿// <auto-generated />
using System;
using Fateblade.Haushaltsbuch.Data.DataStoring.SqLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fateblade.Haushaltsbuch.Data.DataStoring.SqLite.Migrations.ItemHistorySqLiteRepositoryMigrations
{
    [DbContext(typeof(ItemHistorySqLiteRepository))]
    partial class ItemHistorySqLiteRepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Fateblade.Haushaltsbuch.CrossCutting.DataClasses.ItemHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateOfChange");

                    b.Property<int>("ItemId");

                    b.Property<DateTime>("LastBuyDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Note");

                    b.Property<decimal>("PricePerUnit");

                    b.HasKey("Id");

                    b.ToTable("ItemHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
