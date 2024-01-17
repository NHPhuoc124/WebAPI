using Microsoft.EntityFrameworkCore;

namespace MyWebAPI.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        #region DbSet
        public DbSet<HangHoaEntity> HangHoas { get; set; }
        public DbSet<LoaiEntity> Loais { get; set; }
        #endregion
    }
}
