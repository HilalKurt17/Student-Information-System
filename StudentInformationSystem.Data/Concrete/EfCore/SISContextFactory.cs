
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentInformationSystem.Data.Concrete.EfCore
{
    public class SISContextFactory : IDesignTimeDbContextFactory<SISContext>
    {
        public SISContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SISContext>();
            optionsBuilder.UseSqlite(@"Data Source=C:\VS_ASP.NET\SIS\StudentInformationSystem.WEBUI\SISDb.db",
b => b.MigrationsAssembly("StudentInformationSystem.WEBUI"));

            return new SISContext(optionsBuilder.Options);
        }
    }

}
