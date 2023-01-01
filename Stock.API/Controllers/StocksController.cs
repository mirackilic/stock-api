using Microsoft.AspNetCore.Mvc;
using Stock.Domain.Entities;
using Stock.Domain.IRepositories;

namespace Stock.API.Controllers;

[ApiController]
[Route("[controller]")]
public class StocksController : ControllerBase
{
    private readonly IStocksRepository _stockRepository;

    public StocksController(IStocksRepository Stockervice)
    {
        _stockRepository = Stockervice;
    }

    // Post api/stocks/
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] List<Stocks> stocks)
    {
        await _stockRepository.BulkAddAsync(stocks);
        return Ok();
    }

    // Put api/stocks/{variantCode}?quantity=2
    [HttpPut("{variantCode}")]
    public async Task<IActionResult> PutAsync(string variantCode, [FromQuery] int quantity)
    {
        var stocks = await _stockRepository.GetByVariantCodeAsync(variantCode);

        if (stocks is null)
            throw new ApplicationException("Stock is not exist!");

        stocks.Quantity = quantity;

        await _stockRepository.UpdateAsync(stocks);
        return Ok();
    }

    // Get api/stocks/{variantCode}/variant
    [HttpGet("{variantCode}/variant")]
    public async Task<IActionResult> GetByVariantCodeAsync(string variantCode)
    {
        var stocks = await _stockRepository.GetByVariantCodeAsync(variantCode);

        if (stocks is null)
            throw new ApplicationException("Stock is not exist!");

        return Ok(stocks);
    }

    // Get api/stocks/{productCode}/product
    [HttpGet("{productCode}/product")]
    public async Task<IActionResult> GetByProductCodeAsync(char productCode)
    {
        var stocks = await _stockRepository.GetByProductCodeAsync(productCode);

        if (stocks is null)
            throw new ApplicationException("Stock is not exist!");

        return Ok(stocks);
    }
}
