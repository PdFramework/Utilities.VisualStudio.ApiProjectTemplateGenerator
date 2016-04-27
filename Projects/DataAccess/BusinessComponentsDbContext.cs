using System.Data.Entity;

namespace PeinearyDevelopment.Utilities.VisualStudio.ApiProjectTemplateGenerator.Projects.DataAccess
{
  public class BusinessComponentsDbContext : DbContext
  {
    public BusinessComponentsDbContext(): base("BusinessComponentsDbContext")
    {
    }

    public virtual DbSet<BusinessComponentDto> BusinessComponents { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<BusinessComponentDto>()
                  .ToTable("BusinessComponents", "dbo");
    }
  }
}
