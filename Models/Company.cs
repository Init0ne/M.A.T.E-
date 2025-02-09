using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketAnalyzerToolsExpert.Models;

public partial class Company
{
    [Key]
    public int CompanyId { get; set; }

    [Required]
    [StringLength(10)]
    [Display(Name = "Ticker Symbol")]
    public string Ticker { get; set; } = null!;

    [Display(Name = "Company Name")]
    public string? CompanyName { get; set; }

    public virtual ICollection<StockPrice> StockPrices { get; set; } = new List<StockPrice>();
}
