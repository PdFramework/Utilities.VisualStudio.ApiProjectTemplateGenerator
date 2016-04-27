using System.Collections.Generic;
using System.Threading.Tasks;

namespace $customnamespace$.Contracts
{
  public interface I$specificconcept$Client
  {
    Task<IEnumerable<$specificconceptsingularized$>> GetAll$specificconcept$();
    Task<$specificconceptsingularized$> Get$specificconceptsingularized$(int id);
    Task<$specificconceptsingularized$> Create$specificconceptsingularized$($specificconceptsingularized$ $pascalspecificconceptsingularized$);
    Task<$specificconceptsingularized$> Update$specificconceptsingularized$($specificconceptsingularized$ $pascalspecificconceptsingularized$);
    Task Delete$specificconceptsingularized$(int id);
  }
}
