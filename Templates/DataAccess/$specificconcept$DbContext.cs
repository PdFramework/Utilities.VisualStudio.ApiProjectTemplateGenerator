using System.Data.Entity;

namespace $customnamespace$.DataAccess
{
  public class $specificconcept$DbContext : DbContext
  {
    public $specificconcept$DbContext(): base("$specificconcept$DbContext")
    {
    }

    public virtual DbSet<$specificconceptsingularized$Dto> $specificconcept$ { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<$specificconceptsingularized$Dto>()
                  .ToTable("$specificconcept$", "dbo");
    }
  }
}
