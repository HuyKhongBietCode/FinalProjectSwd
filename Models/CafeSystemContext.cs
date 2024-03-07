using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace FinalProjectSwd.Models
{
    public partial class CafeSystemContext : DbContext
    {
        public CafeSystemContext()
        {
        }

        public CafeSystemContext(DbContextOptions<CafeSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<AttendanceDay> AttendanceDays { get; set; } = null!;
        public virtual DbSet<Commodity> Commoditys { get; set; } = null!;
        public virtual DbSet<CommodityCategory> CommodityCategorys { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<SigningSalary> SigningSalarys { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;
        public virtual DbSet<WorkingTime> WorkingTimes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                string connectionString = config.GetConnectionString("value");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasIndex(e => e.AreaName, "UQ__Areas__8EB6AF57F70BDACC")
                    .IsUnique();

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AreaID");

                entity.Property(e => e.AreaName).HasMaxLength(200);

                entity.Property(e => e.Description).HasColumnType("ntext");
            });

            modelBuilder.Entity<AttendanceDay>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.WtimeId, e.DateWork })
                    .HasName("PK__Attendan__76AAA87C2A178D0C");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.WtimeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WTimeID");

                entity.Property(e => e.DateWork).HasColumnType("datetime");

                entity.Property(e => e.Attendance).HasDefaultValueSql("((0))");

                entity.Property(e => e.Note)
                    .HasColumnType("ntext")
                    .HasColumnName("note");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AttendanceDays)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Employees_AttenDay");

                entity.HasOne(d => d.Wtime)
                    .WithMany(p => p.AttendanceDays)
                    .HasForeignKey(d => d.WtimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_WTime_AttendanceDay");
            });

            modelBuilder.Entity<Commodity>(entity =>
            {
                entity.Property(e => e.CommodityId).HasColumnName("CommodityID");

                entity.Property(e => e.CcategoryId).HasColumnName("CCategoryID");

                entity.Property(e => e.CommodityName).HasMaxLength(200);

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.PriceCommodity).HasColumnType("money");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Ccategory)
                    .WithMany(p => p.Commodities)
                    .HasForeignKey(d => d.CcategoryId)
                    .HasConstraintName("FK_CommodityCategory_Commodity");
            });

            modelBuilder.Entity<CommodityCategory>(entity =>
            {
                entity.HasKey(e => e.CcategoryId)
                    .HasName("PK__Commodit__F112D34B558D5D3B");

                entity.HasIndex(e => e.CcategoryName, "UQ__Commodit__8511627F496160EC")
                    .IsUnique();

                entity.Property(e => e.CcategoryId).HasColumnName("CCategoryID");

                entity.Property(e => e.CcategoryName)
                    .HasMaxLength(200)
                    .HasColumnName("CCategoryName");

                entity.Property(e => e.Description).HasColumnType("ntext");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AccumulatedPoints).HasDefaultValueSql("((0))");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.EmployeeName).HasMaxLength(200);

                entity.Property(e => e.Gender).HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PositionID");

                entity.Property(e => e.StartDayOfWork).HasColumnType("datetime");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Position_Employees");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.OrtherMoney).HasColumnType("money");

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.Property(e => e.TotalMoney).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("Fk_Orders_Customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Fk_Employees_Orders");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TableId)
                    .HasConstraintName("FK_Tables_Orders");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.CommodityId, e.DateTimeOrder })
                    .HasName("PK__OrderDet__35537723A10455C1");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CommodityId).HasColumnName("CommodityID");

                entity.Property(e => e.DateTimeOrder).HasColumnType("datetime");

                entity.HasOne(d => d.Commodity)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.CommodityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Commodity_OrderDetails");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_Orders_OrderDetails");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PositionID");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.PositionName).HasMaxLength(100);
            });

            modelBuilder.Entity<SigningSalary>(entity =>
            {
                entity.HasKey(e => e.SsalaryId)
                    .HasName("PK__SigningS__EA0DCC5F4D1E94A4");

                entity.Property(e => e.SsalaryId).HasColumnName("SSalaryID");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.SigningSalary1)
                    .HasMaxLength(100)
                    .HasColumnName("SigningSalary");

                entity.Property(e => e.TotalSalary).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.SigningSalaries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("Fk_E_SigSalary");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasIndex(e => e.TableName, "UQ__Tables__733652EE9B9703DF")
                    .IsUnique();

                entity.Property(e => e.TableId).HasColumnName("TableID");

                entity.Property(e => e.AreaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AreaID");

                entity.Property(e => e.TableName).HasMaxLength(200);

                entity.Property(e => e.TableStatus).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Tables_Areas");
            });

            modelBuilder.Entity<WorkingTime>(entity =>
            {
                entity.HasKey(e => e.WtimeId)
                    .HasName("PK__WorkingT__BD8AC999CB9424BD");

                entity.Property(e => e.WtimeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WTimeID");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.WtimeName)
                    .HasMaxLength(200)
                    .HasColumnName("WTimeName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
