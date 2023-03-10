// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApp_ServerAPI.Data;

#nullable disable

namespace TodoAppServerAPI.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230123200228_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("TodoApp_ServerAPI.Model.TodoItem", b =>
                {
                    b.Property<int>("TodoItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TodoStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoItemId");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            TodoItemId = 1,
                            Description = "Task 1 to do",
                            TodoStatus = 0
                        },
                        new
                        {
                            TodoItemId = 2,
                            Description = "Task 2 to do",
                            TodoStatus = 0
                        },
                        new
                        {
                            TodoItemId = 3,
                            Description = "Task 3 to do",
                            TodoStatus = 0
                        },
                        new
                        {
                            TodoItemId = 4,
                            Description = "Task 4 to do",
                            TodoStatus = 0
                        });
                });

            modelBuilder.Entity("TodoApp_ServerAPI.Model.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserName = "admin"
                        },
                        new
                        {
                            UserId = 2,
                            UserName = "Johan"
                        },
                        new
                        {
                            UserId = 3,
                            UserName = "Nikolai"
                        },
                        new
                        {
                            UserId = 4,
                            UserName = "Johannes"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
