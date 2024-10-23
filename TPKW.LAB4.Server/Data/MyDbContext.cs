using Microsoft.EntityFrameworkCore;
using TPKW.LAB4.Server.Models;

namespace TPKW.LAB4.Server.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public string DbPath { get; }

        public MyDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "MyDb.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={DbPath}");
    }

}
