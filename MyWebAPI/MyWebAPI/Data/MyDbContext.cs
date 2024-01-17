using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        #region DbSet
        public DbSet<HangHoaEntity> HangHoas { get; set; }
        public DbSet<LoaiEntity> Loais { get; set; }
        public DbSet<DonHangEntity> DonHangs { get; set; }
        public DbSet<ChiTietDonHangEntity> ChiTietDonHangs { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DonHangEntity>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDonHang);
                e.Property(dh => dh.NgayDatHang).HasDefaultValueSql("getutcdate");
            });

            builder.Entity<ChiTietDonHangEntity>(e =>
            {
                e.ToTable("ChiTietDonHang");
                e.HasKey(e => new { e.MaHangHoa, e.MaDonHang });

                e.HasOne(e => e.HangHoa)
                .WithMany(e => e.ChiTietDonHangs)
                .HasForeignKey(e => e.MaHangHoa)
                .HasConstraintName("FK_CTDH_HangHoa");

                e.HasOne(e => e.DonHang)
                 .WithMany(e => e.ChiTietDonHangs)
                 .HasForeignKey(e => e.MaDonHang)
                 .HasConstraintName("FK_CTDH_DonHang");
            });

            
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DonHangEntity>(e =>
        //    {
        //        e.ToTable("DonHang");
        //        e.HasKey(dh => dh.MaDonHang);
        //        e.Property(dh => dh.NgayDatHang).HasDefaultValueSql("getutcdate()");
        //    });

        //    modelBuilder.Entity<ChiTietDonHangEntity>(e =>
        //    {
        //        e.ToTable("ChiTietDonHang");
        //        e.HasKey(e => new { e.MaHangHoa, e.MaDonHang });

        //        e.HasOne(e => e.DonHang)
        //        .WithMany(e => e.ChiTietDonHangs)
        //        .HasForeignKey(e => e.MaDonHang)
        //        .HasConstraintName("Fk_CTDH_DonHang");

        //        e.HasOne(e => e.HangHoa)
        //        .WithMany(e => e.ChiTietDonHangs)
        //        .HasForeignKey(e => e.MaHangHoa)
        //        .HasConstraintName("Fk_CTDH_HangHoa");
        //    });
        //}
    }
}
