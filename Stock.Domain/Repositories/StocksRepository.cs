using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Stock.Domain.Context;
using Stock.Domain.Entities;
using Stock.Domain.IRepositories;
using Stock.Domain.Models;

namespace Stock.Domain.Repositories;

public class StocksRepository : IStocksRepository
{
    private readonly StocksDbContext _context;

    public StocksRepository(StocksDbContext context)
    {
        _context = context;
    }

    public async Task<Stocks?> FindOneAsync(Expression<Func<Stocks, bool>> predicate)
    {
        return await _context.Stocks.FirstOrDefaultAsync(predicate);
    }

    public async Task<List<Stocks>> FindAsync(Expression<Func<Stocks, bool>> predicate)
    {
        return await _context.Stocks.Where(predicate).ToListAsync();
    }

    public async Task<List<Stocks>> GetAllAsync()
    {
        return await _context.Stocks.ToListAsync();
    }

    public async Task<Stocks> GetByIdAsync(int id)
    {
        return await _context.Stocks.FindAsync(id);
    }

    public async Task AddAsync(Stocks stock)
    {
        stock.CreateTime = DateTime.UtcNow;
        _context.Stocks.Add(stock);
        await _context.SaveChangesAsync();
    }

    public async Task BulkAddAsync(List<Stocks> stocks)
    {
        stocks.ForEach(x => x.CreateTime = DateTime.UtcNow);

        _context.Stocks.AddRange(stocks);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Stocks stock)
    {
        stock.UpdateTime = DateTime.UtcNow;
        _context.Stocks.Update(stock);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var stock = await GetByIdAsync(id);
        _context.Stocks.Remove(stock);
        await _context.SaveChangesAsync();
    }

    public async Task<GetStockByVariantCodeResponseVM?> GetByVariantCodeAsync(string variantCode)
    {
        return await _context.Stocks
           .Where(s => s.VariantCode == variantCode).
            Select(x => new GetStockByVariantCodeResponseVM
            {
                Id = x.Id,
                VariantCode = x.VariantCode,
                Quantity = x.Quantity
            }).SingleOrDefaultAsync();
    }

    public async Task<List<GetStockByProductCodeResponseVM>> GetByProductCodeAsync(char productCode)
    {
        return await _context.Stocks
           .Where(s => s.ProductCode == productCode).
           Select(x => new GetStockByProductCodeResponseVM
           {
               Id = x.Id,
               ProductCode = x.ProductCode,
               Quantity = x.Quantity
           }).ToListAsync();
    }
}
