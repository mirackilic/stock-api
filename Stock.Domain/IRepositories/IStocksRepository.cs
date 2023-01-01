using System.Linq.Expressions;
using Stock.Domain.Entities;
using Stock.Domain.Models;

namespace Stock.Domain.IRepositories;

public interface IStocksRepository
{
    Task<Stocks?> FindOneAsync(Expression<Func<Stocks, bool>> predicate);
    Task<List<Stocks>> FindAsync(Expression<Func<Stocks, bool>> predicate);
    Task<List<Stocks>> GetAllAsync();
    Task<Stocks> GetByIdAsync(int id);
    Task AddAsync(Stocks stock);
    Task BulkAddAsync(List<Stocks> stocks);
    Task UpdateAsync(Stocks stock);
    Task DeleteAsync(int id);
    Task<GetStockByVariantCodeResponseVM?> GetByVariantCodeAsync(string variantCode);
    Task<List<GetStockByProductCodeResponseVM>> GetByProductCodeAsync(char productCode);
}
