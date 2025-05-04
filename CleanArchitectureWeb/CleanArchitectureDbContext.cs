using CleanArchitectureWeb.Domain.Abstractions;
using CleanArchitectureWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWeb;
public sealed class CleanArchitectureDbContext : DbContext, IUnitOfWork
{
    public CleanArchitectureDbContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("infor");
        modelBuilder.Entity<Customer>(builder =>
        {
            builder.ToTable(nameof(Customer));
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.FirstName)
            .HasConversion(
                customer => customer.Value,
                customer => new FirstName(customer));
            builder.Property(customer => customer.LastName)
           .HasConversion(
               customer => customer.Value,
               customer => new LastName(customer));
            builder.Property(customer => customer.Email)
           .HasConversion(
               customer => customer.Value,
               customer => new Email(customer));
            builder.Property(customer => customer.Address)
         .HasConversion(
             customer => customer.Value,
             customer => new Address(customer));
            builder.Property(customer => customer.PhoneNumber)
         .HasConversion(
             customer => customer.Value,
             customer => new PhoneNumber(customer));

        });
        base.OnModelCreating(modelBuilder);
    }
}
