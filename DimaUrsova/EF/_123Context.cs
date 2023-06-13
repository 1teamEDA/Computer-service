using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DimaUrsova.EF
{
    public partial class _123Context : DbContext
    {
        public _123Context()
        {
        }
        public _123Context(DbContextOptions<_123Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Detail> Details { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Ordersss> Orderssses { get; set; } = null!;
        public virtual DbSet<Positionnn> Positionnns { get; set; } = null!;
        public virtual DbSet<Stock> Stocks { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=123.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerCode);

                entity.ToTable("customers");

                entity.Property(e => e.CustomerCode).HasColumnName("customer_code");

                entity.Property(e => e.CustomerAddress).HasColumnName("customer_address");

                entity.Property(e => e.CustomerDocument).HasColumnName("customer_document");

                entity.Property(e => e.CustomerNomer).HasColumnName("customer_nomer");

                entity.Property(e => e.CustomerPib).HasColumnName("customer_pib");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasKey(e => e.DetailsCode);

                entity.ToTable("details");

                entity.Property(e => e.DetailsCode).HasColumnName("details_code");

                entity.Property(e => e.CostDetails).HasColumnName("cost_details");

                entity.Property(e => e.CostService).HasColumnName("cost_service");

                entity.Property(e => e.NameDetails).HasColumnName("name_details");

                entity.Property(e => e.QuantityInstock).HasColumnName("quantity_instock");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.LoiginCode);

                entity.ToTable("Login");

                entity.Property(e => e.LoiginCode).HasColumnName("loigin_code");

                entity.Property(e => e.Login1).HasColumnName("login");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.PositionWorker).HasColumnName("position_worker");
            });

            modelBuilder.Entity<Ordersss>(entity =>
            {
                entity.HasKey(e => e.OrdersCode);

                entity.ToTable("ordersss");

                entity.Property(e => e.OrdersCode).HasColumnName("orders_code");

                entity.Property(e => e.AllSum).HasColumnName("all_sum");

                entity.Property(e => e.Appearance).HasColumnName("appearance_");

                entity.Property(e => e.Breaking).HasColumnName("breaking");

                entity.Property(e => e.CustomerCode).HasColumnName("customer_code");

                entity.Property(e => e.DateOrder).HasColumnName("date_order");

                entity.Property(e => e.NameDevice).HasColumnName("name_device");

                entity.Property(e => e.Status).HasColumnName("status_");

                entity.Property(e => e.WorkerCodeMas).HasColumnName("worker_code_mas");

                entity.Property(e => e.WorkerCodeMen).HasColumnName("worker_code_men");

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.Orderssses)
                    .HasForeignKey(d => d.CustomerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.WorkerCodeMasNavigation)
                    .WithMany(p => p.OrdersssWorkerCodeMasNavigations)
                    .HasForeignKey(d => d.WorkerCodeMas);

                entity.HasOne(d => d.WorkerCodeMenNavigation)
                    .WithMany(p => p.OrdersssWorkerCodeMenNavigations)
                    .HasForeignKey(d => d.WorkerCodeMen);
            });

            modelBuilder.Entity<Positionnn>(entity =>
            {
                entity.HasKey(e => e.PositionCode);

                entity.ToTable("positionnn");

                entity.Property(e => e.PositionCode).HasColumnName("position_code");

                entity.Property(e => e.PositionP).HasColumnName("position_p");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.StockCode);

                entity.ToTable("stock");

                entity.Property(e => e.StockCode).HasColumnName("stock_code");

                entity.Property(e => e.DetailsCode).HasColumnName("details_code");

                entity.Property(e => e.OrdersCode).HasColumnName("orders_code");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.DetailsCodeNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.DetailsCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.OrdersssCodeNavigation)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.OrdersCode);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.WorkerCode);

                entity.ToTable("worker");

                entity.Property(e => e.WorkerCode).HasColumnName("worker_code");

                entity.Property(e => e.PositionCode).HasColumnName("position_code");

                entity.Property(e => e.WorkerDocument).HasColumnName("worker_document");

                entity.Property(e => e.WorkerNumber).HasColumnName("worker_number");

                entity.Property(e => e.WorkerPib).HasColumnName("worker_pib");

                entity.HasOne(d => d.PositionCodeNavigation)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.PositionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
