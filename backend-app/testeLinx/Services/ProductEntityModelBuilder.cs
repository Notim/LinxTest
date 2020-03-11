using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using testeLinx.Models;

namespace testeLinx.Services {

    sealed class ProductEntityModelBuilder : IEntityTypeConfiguration<ProductEntity> {

        public void Configure(EntityTypeBuilder<ProductEntity> builder) {
            // builder.("tb_product");

            builder.HasKey(model => model.id);

            builder.Property(c => c.id).ValueGeneratedOnAdd();
        }

    }

}