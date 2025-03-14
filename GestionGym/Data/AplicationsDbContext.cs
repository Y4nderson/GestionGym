using Microsoft.EntityFrameworkCore;

namespace GestionGym.Data
{
    public class AplicationsDbContext:DbContext
    {


        public AplicationsDbContext(DbContextOptions<AplicationsDbContext> options): base(options)
        {
            
        }
    }
}
