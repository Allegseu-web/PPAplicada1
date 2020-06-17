﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PPAplicada1.DAL;

namespace PPAplicada1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("PPAplicada1.Entidades.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencias")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ValorInventario")
                        .HasColumnType("REAL");

                    b.HasKey("ArticuloId");

                    b.ToTable("articulos");
                });
#pragma warning restore 612, 618
        }
    }
}
