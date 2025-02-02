namespace MarketAnalyzerToolsExpert.Models;

public partial class Company
{
    public int CompanyId { get; set; }

    public string Ticker { get; set; } = null!;

    public string? CompanyName { get; set; }

    public virtual ICollection<StockPrice> StockPrices { get; set; } = [];
}
