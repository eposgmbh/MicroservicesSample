using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql.EntityFrameworkCore;

namespace Notes.Persistence
{
    public class NoteContextFactory : IDesignTimeDbContextFactory<NoteContext>
    {
        public NoteContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<NoteContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Database=notes;User ID=postgres;Password=JklM8765");

            return new NoteContext(optionsBuilder.Options);
        }
    }
}
