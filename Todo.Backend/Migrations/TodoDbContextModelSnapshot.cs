﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todo.Backend.Context;

#nullable disable

namespace Todo.Backend.Migrations
{
    [DbContext(typeof(TodoDbContext))]
    partial class TodoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Todo.Backend.Models.ToDoTask", b =>
                {
                    b.Property<int>("idTask")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_task");

                    b.Property<bool>("Completed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("completed");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("description");

                    b.HasKey("idTask");

                    b.ToTable("ToDoTask");
                });
#pragma warning restore 612, 618
        }
    }
}
