using Client_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Client_Management.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}

    public DbSet<Client> Clients{get;set;}
}