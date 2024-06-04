using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrafficSignal.Models
{
    public partial class MySqlContext : DbContext
    {
        public MySqlContext()
        {
        }

        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Device { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;userid=root;pwd=Fet007007;port=3306;database=traffic_signal;sslmode=none;AllowPublicKeyRetrieval=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("device");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CollectionState)
                    .IsRequired()
                    .HasColumnName("collection_state")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'未连接'");

                entity.Property(e => e.DeviceGroup)
                    .IsRequired()
                    .HasColumnName("device_group")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'UP'");

                entity.Property(e => e.DeviceName)
                    .IsRequired()
                    .HasColumnName("device_name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.DeviceType)
                    .IsRequired()
                    .HasColumnName("device_type")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'红绿灯'");

                entity.Property(e => e.DeviceVersion)
                    .HasColumnName("device_version")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LaneAddresses)
                    .HasColumnName("lane_addresses")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'01'");

                entity.Property(e => e.Port)
                    .HasColumnName("port")
                    .HasColumnType("int(6)");

                entity.Property(e => e.TestState)
                    .IsRequired()
                    .HasColumnName("test_state")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'否'");

            });
        }
    }
}
