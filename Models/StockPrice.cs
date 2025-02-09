namespace MarketAnalyzerToolsExpert.Models;

public partial class StockPrice
{
    public long PriceId { get; set; }

    public int CompanyId { get; set; }

    public DateOnly TradeDate { get; set; }

    public decimal Open { get; set; }

    public decimal High { get; set; }

    public decimal Low { get; set; }

    public decimal Close { get; set; }

    public decimal AdjClose { get; set; }

    public long Volume { get; set; }

    public virtual Company Company { get; set; } = null!;
}
