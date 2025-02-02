using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAnalyzerToolsExpert.Models;

public class StockPrice
{
    [Key]
    public long PriceId { get; set; }

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public DateTime TradeDate { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Open { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal High { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Low { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Close { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal AdjClose { get; set; }

    public long Volume { get; set; }

    [ForeignKey("CompanyId")]
    public virtual Company Company { get; set; } = null!;
}
