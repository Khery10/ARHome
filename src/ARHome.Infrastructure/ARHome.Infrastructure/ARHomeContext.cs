using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ARHome.Infrastructure
{
    internal sealed class ARHomeContext : DbContext
    {
        public ARHomeContext(DbContextOptions<ARHomeContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Assembly[] assembliesWithConfigurations = {GetType().Assembly};

            foreach (var assemblyWithConfigurations in assembliesWithConfigurations)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
            }
        }
    }
}