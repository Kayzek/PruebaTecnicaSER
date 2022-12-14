// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaBackend.Data;

#nullable disable

namespace PruebaBackend.Migrations.TasaCambioDb
{
    [DbContext(typeof(TasaCambioDbContext))]
    partial class TasaCambioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PruebaBackend.Models.TasaCambio", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("cordobaDolar")
                        .HasColumnType("float");

                    b.Property<double>("dolarCordoba")
                        .HasColumnType("float");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("TasaCambios");
                });
#pragma warning restore 612, 618
        }
    }
}
