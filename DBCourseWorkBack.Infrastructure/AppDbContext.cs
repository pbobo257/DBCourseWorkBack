using DBCourseWorkBack.Domain.Models;
using DBCourseWorkBack.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBCourseWorkBack.Infrastructure
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(x => x.Id);
            builder.Entity<Product>().Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Entity<Product>().Property(x => x.Price).HasColumnType("money").IsRequired();
            builder.Entity<Product>().Property(x => x.Amount).HasDefaultValue(0);

            builder.Entity<Employee>().HasKey(x => x.Id);
            builder.Entity<Employee>().Property(x => x.Status).HasMaxLength(50);
            builder.Entity<Employee>().Property(x => x.Salary).HasColumnType("money");
            builder.Entity<Employee>().Property(x => x.DateOfEmployment).HasDefaultValueSql("getdate()");

            builder.Entity<Customer>().HasKey(x => x.Id);
            builder.Entity<Customer>().Property(x => x.Bonuses).HasDefaultValue(0);
            builder.Entity<Customer>().Property(x => x.BonusCardNumber).HasDefaultValueSql("newid()");
        }
    }
}
