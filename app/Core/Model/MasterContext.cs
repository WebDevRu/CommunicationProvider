using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace app.Core.Model;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Abonent> Abonents { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Balance> Balances { get; set; }

    public virtual DbSet<Limit> Limits { get; set; }

    public virtual DbSet<MoneyTransaction> MoneyTransactions { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PackageTarif> PackageTarifs { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    public virtual DbSet<TariffTvChannel> TariffTvChannels { get; set; }

    public virtual DbSet<Tvchannel> Tvchannels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=master;User Id=sa; Password=YourStrong!Passw0rd;Trusted_Connection=False; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Abonent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("id");

            entity.ToTable("Abonent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("datetime")
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.IsPasswordTemporary).HasColumnName("isPasswordTemporary");
            entity.Property(e => e.LastLoginAt)
                .HasColumnType("datetime")
                .HasColumnName("lastLoginAt");
            entity.Property(e => e.LastName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registeredAt");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Admin_pk");

            entity.ToTable("Admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.LastLoginAt)
                .HasColumnType("datetime")
                .HasColumnName("lastLoginAt");
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("registeredAt");
        });

        modelBuilder.Entity<Balance>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Balance_pk");

            entity.ToTable("Balance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbonentId).HasColumnName("abonentId");
            entity.Property(e => e.IsSystem).HasColumnName("isSystem");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Abonent).WithMany(p => p.Balances)
                .HasForeignKey(d => d.AbonentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Abonent_Balance_fk");
        });

        modelBuilder.Entity<Limit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("limit_pk");

            entity.ToTable("Limit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CableInternetSpeedMbs).HasColumnName("cableInternetSpeedMBs");
            entity.Property(e => e.IsSystem).HasColumnName("isSystem");
            entity.Property(e => e.MobileCallsMinutes).HasColumnName("mobileCallsMinutes");
            entity.Property(e => e.MobileInternetLimitMb).HasColumnName("mobileInternetLimitMB");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("serviceType");
        });

        modelBuilder.Entity<MoneyTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MoneyTransaction_pk");

            entity.ToTable("MoneyTransaction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BalanceId).HasColumnName("balanceId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Credits).HasColumnName("credits");
            entity.Property(e => e.EndCredits).HasColumnName("endCredits");
            entity.Property(e => e.PurchaseId).HasColumnName("purchaseId");
            entity.Property(e => e.StartCredits).HasColumnName("startCredits");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Balance).WithMany(p => p.MoneyTransactions)
                .HasForeignKey(d => d.BalanceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Balance_MoneyTransaction_fk");

            entity.HasOne(d => d.Purchase).WithMany(p => p.MoneyTransactions)
                .HasForeignKey(d => d.PurchaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Purchase_MoneyTransaction_fk");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("package_pk");

            entity.ToTable("Package");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false);
            entity.Property(e => e.InitialPaymentAmount).HasColumnName("initialPaymentAmount");
            entity.Property(e => e.PeriodPaymentAmount).HasColumnName("periodPaymentAmount");
            entity.Property(e => e.PeriodSeconds).HasColumnName("periodSeconds");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("serviceType");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<PackageTarif>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.TariffId, e.PackageId }).HasName("packageTarifs_pk");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.TariffId).HasColumnName("tariffId");
            entity.Property(e => e.PackageId).HasColumnName("packageId");

            entity.HasOne(d => d.Package).WithMany(p => p.PackageTarifs)
                .HasForeignKey(d => d.PackageId)
                .HasConstraintName("Package_PackageTarifs_fk");

            entity.HasOne(d => d.Tariff).WithMany(p => p.PackageTarifs)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tariff_PackageTarifs_fk");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("purchase_pk");

            entity.ToTable("Purchase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AbonentId).HasColumnName("abonentId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.PackageId).HasColumnName("packageId");
            entity.Property(e => e.TariffId).HasColumnName("tariffId");

            entity.HasOne(d => d.Abonent).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.AbonentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Abonent_Purchase_fk");

            entity.HasOne(d => d.Package).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Package_Purchase_fk");

            entity.HasOne(d => d.Tariff).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tariff_Purchase_fk");
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tariff_pk");

            entity.ToTable("Tariff");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.InitialPaymentAmount).HasColumnName("initialPaymentAmount");
            entity.Property(e => e.LimitId).HasColumnName("limitId");
            entity.Property(e => e.PeriodPaymentAmount).HasColumnName("periodPaymentAmount");
            entity.Property(e => e.PeriodSeconds).HasColumnName("periodSeconds");
            entity.Property(e => e.ServiceType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("serviceType");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Limit).WithMany(p => p.Tariffs)
                .HasForeignKey(d => d.LimitId)
                .HasConstraintName("Limit_Tariff_fk");
        });

        modelBuilder.Entity<TariffTvChannel>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.TvChannelId, e.TariffId }).HasName("tariff_tvChannels_pk");

            entity.ToTable("Tariff_tvChannels");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.TvChannelId).HasColumnName("tvChannelId");
            entity.Property(e => e.TariffId).HasColumnName("tariffId");

            entity.HasOne(d => d.Tariff).WithMany(p => p.TariffTvChannels)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tariff_Tariff_tvChannels_fk");

            entity.HasOne(d => d.TvChannel).WithMany(p => p.TariffTvChannels)
                .HasForeignKey(d => d.TvChannelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TVChannel_Tariff_tvChannels_fk");
        });

        modelBuilder.Entity<Tvchannel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TVChannel_pk");

            entity.ToTable("TVChannel");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
