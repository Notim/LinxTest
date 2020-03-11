using Microsoft.EntityFrameworkCore;

using testeLinx.Models;

namespace testeLinx.Services._core {

    public class MemContext : DbContext {

        public MemContext(DbContextOptions<MemContext> options) 
            : base(options) {
            
        }

        public DbSet<ProductEntity> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ProductEntityModelBuilder());
            
            base.OnModelCreating(modelBuilder);
        }
        
    }

}