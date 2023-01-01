using Microsoft.EntityFrameworkCore;
using Stock.Domain.Entities;

namespace Stock.Domain.Context;

public class StocksDbContext : DbContext, IDisposable, IStocksDbContext
{
    public StocksDbContext(DbContextOptions<StocksDbContext> options)
       : base(options)
    { }

    public DbSet<Stocks> Stocks { get; set; }
}
