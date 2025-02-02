using MarketAnalyzerToolsExpert.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketAnalyzerToolsExpert.Data;

public partial class FinancialDataContext(DbContextOptions<FinancialDataContext> options) : DbContext(options)
{
    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<StockPrice> StockPrices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Companie__2D971CAC7D6DB4C5");

            entity.HasIndex(e => e.Ticker, "UQ__Companie__42AC12F01DAA0D56").IsUnique();

            entity.Property(e => e.CompanyName).HasMaxLength(255);
            entity.Property(e => e.Ticker).HasMaxLength(10);
        });

        modelBuilder.Entity<StockPrice>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__StockPri__49575BAF6DBADB51");

            entity.HasIndex(e => new { e.CompanyId, e.TradeDate }, "IX_StockPrices_CompanyId_TradeDate");

            entity.HasIndex(e => new { e.CompanyId, e.TradeDate }, "UQ_StockPrices_CompanyDate").IsUnique();

            entity.Property(e => e.AdjClose).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Close).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.High).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Low).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Open).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.Company).WithMany(p => p.StockPrices)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StockPrices_Companies");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
