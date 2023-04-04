using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opts) : base(opts)
        {

        }
        public DbSet<Command> Commands { get; set; }
    }

}